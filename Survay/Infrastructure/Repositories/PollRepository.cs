using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Survay.Contracts.RepositoryContracts;
using Survay.Domain.Dto;
using Survay.Domain.Entities;
using Survay.Infrastructure.AppDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Infrastructure.Repositories
{
    public class PollRepository : IPollRepository
    {
        private readonly AppDbContext _dbcontext;
        public PollRepository()
        {
            _dbcontext = new AppDbContext();
        }

        public int CreatePoll(int adminId, string title,int count)
        {
            Poll newpoll = new Poll()
            {
                AdminId = adminId,
                Titel = title,
                TotalQuestionCount = count

            };
            _dbcontext.Add(newpoll);
            _dbcontext.SaveChanges();
            return newpoll.Id;

        }
        public List<GetPollDto> GetAllPolls()
        {
            return _dbcontext.Polls.AsNoTracking().Include(p => p.CreatedBy).
                Select(p=> new GetPollDto
                {
                          Id = p.Id,
                          Title= p.Titel,
                          CreatedBy=p.CreatedBy.UserName
                }).ToList();

        }
        public List<GetPollDto> GetAlPollsThatCreateByCurrentUser(int userid)
        {
            return _dbcontext.Polls.AsNoTracking().Where(p => p.AdminId==userid).
                Select(p => new GetPollDto
                {
                    Id = p.Id,
                    Title = p.Titel
                  
                }).ToList();

        }


        public int GetQuestionCount(int pollId)
        {
            return _dbcontext.Polls.AsNoTracking().Where(p => p.Id == pollId)
                .Select(p => p.TotalQuestionCount)
                .FirstOrDefault();
        }

        public bool DletePoll(int pollId)
        {
            _dbcontext.Polls.Where(p => p.Id == pollId)
                .ExecuteDelete();
            return true;
        }

       
    }
}
