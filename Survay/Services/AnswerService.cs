using Microsoft.EntityFrameworkCore.Query;
using Survay.Contracts.RepositoryContracts;
using Survay.Contracts.ServiceContracts;
using Survay.Domain.Dto;
using Survay.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Services
{
    public class AnswerService:IAnswerService
    {
        private readonly IAnswerRepository _answer;
        public AnswerService()
        {
            _answer = new AnswerRepository();
        }
        public bool AddAnswer(int questionId, string text, int answernum)
        {
            return _answer.CreateAnswer(questionId, text, answernum);  
        }
        public void ChangeToCorrectOne(int qId, int answernum)
        {
           _answer.ChangeAnswerToCorrectOne(qId, answernum);    
        }
        public List<AnswerDto> GetANswerByQuestion(int questionId)
        { 
            return _answer.GetAnswerByQuestion(questionId);
        }

        public bool IsCorrectAnswer(int qId,int answerId)
        {
            return _answer.IsAnswerCorrect(qId, answerId);
        }
        public int ShowAnswerId(int qId,int answernum)
        {
            var result =_answer.GetAnswerId(qId, answernum);
            if (result!=null)
            {
                return result;  
            }
            else
            {
                throw new Exception("Answer Not Found");
            }
        }
    }
}

