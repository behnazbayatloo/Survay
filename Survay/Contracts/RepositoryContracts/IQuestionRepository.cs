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
        List<QuestionDto> GetQuestions(int pollId);
    }
}
