using Survay.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Contracts.RepositoryContracts
{
    public interface IPollRepository
    {
        int CreatePoll(int adminId, string title , int count);
        bool DletePoll(int pollId);
        List<GetPollDto> GetAllPolls();
        List<GetPollDto> GetAlPollsThatCreateByCurrentUser(int userid);
        int GetQuestionCount(int pollId);
    }
}
