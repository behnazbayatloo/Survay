using Microsoft.EntityFrameworkCore;
using Survay.Contracts.RepositoryContracts;
using Survay.Domain.Entities;
using Survay.Infrastructure.AppDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Infrastructure.Repositories
{
    public class VoteRepository: IVoteRepository
    {
        private readonly AppDbContext _dbcontext;
        public VoteRepository()
        {
            _dbcontext = new AppDbContext();
        }

        public bool CreateVote(int userId,int answerId )
        {
            Vote newVote = new Vote()
            {
                NormalUserId=userId,
                AnswerId=answerId
                
                
            };
            _dbcontext.Votes.Add(newVote);
            _dbcontext.SaveChanges();
            return true;
        }

     public bool DeleteVote(List<int> answerIdlist)
        {
            foreach ( var item in answerIdlist)
            {
                _dbcontext.Votes.Where(v => v.AnswerId == item)
                    .ExecuteDelete();
            }
            return true;
        }
    }
}
