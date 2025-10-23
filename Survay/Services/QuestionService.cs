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
    public class QuestionService:IQuestionService
    {
        private readonly IQuestionRepository _question;
        public QuestionService()
        {
            _question = new QuestionRepository();
        }
        public int AddQuestion(string txt, int pollId, int questionNum)
        {
            return _question.CreateQuestion(txt, pollId, questionNum);
        }

        public List<QuestionDto> ShowQuestions(int pollid)
        {
            return _question.GetQuestions(pollid);
        }

        public List<int> GetQuestionId(int pollId)
        {
            return _question.GetQuestionId(pollId);
        }


        public bool DeleteQuestions(int pollId)
        {
            return _question.DeleteQuestions(pollId);
        }
    }
}
