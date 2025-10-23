using Microsoft.EntityFrameworkCore;
using Survay.Contracts.RepositoryContracts;
using Survay.Contracts.ServiceContracts;
using Survay.Domain.Entities;
using Survay.Infrastructure.AppDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Infrastructure.Repositories
{
    public class Poll_NUserRepository:IPoll_NUserRepository
    {
        private readonly AppDbContext _dbcontext;
        public Poll_NUserRepository()
        {
            _dbcontext = new AppDbContext();
        }
        public bool CreatePollForUser(int pollId,int UserId)
        {
            Poll_NUser newpnuser = new Poll_NUser()
            {
                PollId = pollId,
                VotedId = UserId
            };
            _dbcontext.Poll_NUsers.Add(newpnuser);
            _dbcontext.SaveChanges();
            return true;
        }
        public bool DoesNUserVotedThis(int pollId, int userId)
        {
            return _dbcontext.Poll_NUsers.AsNoTracking().Any(pn => pn.PollId == pollId && pn.VotedId==userId);

        }
        public bool DeletePollForUser(int pollId)
        {
            _dbcontext.Poll_NUsers.Where(pn => pn.PollId == pollId)
                .ExecuteDelete();
            return true;
        }

    }
}
