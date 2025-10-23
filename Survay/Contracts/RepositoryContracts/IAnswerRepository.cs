using Survay.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Contracts.RepositoryContracts
{
    public interface IAnswerRepository
    {
   
        bool CreateAnswer(int questionId, string text, int answernum);
        List<AnswerDto> GetAnswerByQuestion(int questionId);
        int GetAnswerId(int qId, int answernum);
       
    }
}
