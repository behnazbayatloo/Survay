using Survay.Domain.Dto;
using Survay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Contracts.ServiceContracts
{
    public interface IQuestionService
    {
        int AddQuestion(string txt, int pollId, int questionNum);
        List<QuestionDto> ShowQuestions(int pollid);
    }
}
