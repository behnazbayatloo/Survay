using Microsoft.EntityFrameworkCore;
using Survay.Contracts.RepositoryContracts;
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
        public bool DoesNUserVotedThis(int pollId, int userId)
        {
            return _dbcontext.Poll_NUsers.AsNoTracking().Any(pn => pn.PollId == pollId && pn.VotedId==userId);

        }

    }
}
