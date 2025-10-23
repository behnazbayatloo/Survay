using Survay.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Contracts.ServiceContracts
{
    public interface IPollService
    {
        int AddPoll(int adminId, string title , int count);
        List<GetPollDto> ShowPolls();
        int ShowTotalQuestion(int pollId);
    }
}
