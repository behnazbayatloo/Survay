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
        private readonly IAnswerRepository _answer;
        private readonly IVoteRepository _vote;
        private readonly IQuestionRepository _question;
        public PollService()
        {
            _poll= new PollRepository();
            _answer= new AnswerRepository();
            _vote= new VoteRepository();
            _question= new QuestionRepository();
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
       
        public bool DeletePoll(int pollId)
        {
          return _poll.DletePoll(pollId);
        }
        public List<GetPollDto> GetAlPollsThatCreateByCurrentUser(int userid)
        {
            return _poll.GetAlPollsThatCreateByCurrentUser(userid);
        }
        public List<ResultDto> ShowResults(int pollId)
        {
            var questions = _question.GetQuestions(pollId);
            List<ResultDto> Results = [];
            foreach (var question in questions)
            {
                var answers = _answer.GetAnswerVoted(question.Id);
                ResultDto result = new ResultDto()
                {
                    QuestionNumber=question.QuestionNumber,
                    QuestionText=question.Text,
                    Answers=answers
                };
                Results.Add(result);                  
            }
            return Results;
        }
    }
}
