using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Contracts.RepositoryContracts
{
    public interface IVoteRepository
    {
        bool CreateVote(int userId, int answerId);
    }
}
