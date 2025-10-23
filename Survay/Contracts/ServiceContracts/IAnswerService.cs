using Survay.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Contracts.ServiceContracts
{
    public interface IAnswerService
    {
        bool AddAnswer(int questionId, string text, int answernum);
   
        List<AnswerDto> GetANswerByQuestion(int questionId);
       
        int ShowAnswerId(int qId, int answernum);
    }
}
