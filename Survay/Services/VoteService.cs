using Survay.Contracts.RepositoryContracts;
using Survay.Contracts.ServiceContracts;
using Survay.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Services
{
    public class VoteService:IVoteService
    {
        private readonly IVoteRepository _vote;
        public VoteService()
        {
            _vote = new VoteRepository();
        }

        public bool AddVote(int userId, int answerId, bool isCorrect)
        {
            return _vote.CreateVote(userId, answerId, isCorrect);
        }
    }
}
