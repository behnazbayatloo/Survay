using Survay.Domain.Dto;
using Survay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Contracts.RepositoryContracts
{
    public interface IQuestionRepository
    {
        int CreateQuestion(string txt, int pollId, int questionNum);
        bool DeleteQuestions(int pollId);
        List<int> GetQuestionId(int pollId);
        List<QuestionDto> GetQuestions(int pollId);
    }
}
