using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Contracts.ServiceContracts
{
    public interface IPoll_NUserService
    {
        bool DoesUserVoted(int pollId, int userId);
    }
}
