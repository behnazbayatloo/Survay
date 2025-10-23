using Microsoft.EntityFrameworkCore.ChangeTracking;
using Survay.Contracts.RepositoryContracts;
using Survay.Contracts.ServiceContracts;
using Survay.Domain.Dto;
using Survay.Domain.Entities;
using Survay.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Services
{
    public class PollService : IPollService
    {
        private readonly IPollRepository _poll;
        public PollService()
        {
            _poll= new PollRepository();
        }

        public int AddPoll(int adminId, string title, int count)
        {
            return _poll.CreatePoll(adminId, title, count);
        }
        public List<GetPollDto> ShowPolls()
        {
            return _poll.GetAllPolls();
        }

        public int ShowTotalQuestion(int pollId)
        {
            return _poll.GetQuestionCount(pollId);
        }
       
     
    }
}
