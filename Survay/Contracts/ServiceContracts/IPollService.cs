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
        bool DeletePoll(int pollId);
        List<GetPollDto> GetAlPollsThatCreateByCurrentUser(int userid);
        List<GetPollDto> ShowPolls();
        List<ResultDto> ShowResults(int pollId);
        int ShowTotalQuestion(int pollId);
    }
}
