using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Contracts.RepositoryContracts
{
    public interface IPoll_NUserRepository
    {
        bool CreatePollForUser(int pollId, int UserId);
        bool DeletePollForUser(int pollId);
        bool DoesNUserVotedThis(int pollId, int userId);
    }
}
