using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Contracts.RepositoryContracts
{
    public interface IPoll_NUserRepository
    {
        bool DoesNUserVotedThis(int pollId, int userId);
    }
}
