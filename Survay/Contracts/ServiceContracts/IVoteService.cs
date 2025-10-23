using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Contracts.ServiceContracts
{
    public interface IVoteService
    {
        bool AddVote(int userId, int answerId);
        bool DeleteVote(List<int> answerIdlist);
    }
}
