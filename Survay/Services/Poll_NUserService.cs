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
    public class Poll_NUserService:IPoll_NUserService
    {
        private readonly IPoll_NUserRepository _pnuser;
        public Poll_NUserService()
        {
            _pnuser = new Poll_NUserRepository();
        }

        public bool DoesUserVoted(int pollId,int userId)
        {
            return _pnuser.DoesNUserVotedThis(pollId, userId);
        }
        public bool DeletePollForUser(int pollId)
        {
            return _pnuser.DeletePollForUser(pollId);
        }
        public bool CreatePollForUser(int pollId, int UserId)
        {
            return _pnuser.CreatePollForUser(pollId, UserId);
        }
    }
}
