using Microsoft.EntityFrameworkCore;
using Survay.Contracts.RepositoryContracts;
using Survay.Domain.Dto;
using Survay.Domain.Entities;
using Survay.Infrastructure.AppDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Infrastructure.Repositories
{
    public class AnswerRepository: IAnswerRepository
    {
        private readonly AppDbContext _dbcontext;
        public AnswerRepository()
        {
            _dbcontext= new AppDbContext();
        }

        public bool CreateAnswer(int questionId ,string text,int answernum)
        {
            Answer newanswer = new Answer()
            {
                QuestionId = questionId,
                TextAnswer = text,
                AnswerNumber = answernum
                
            };
            _dbcontext.Add(newanswer);
            _dbcontext.SaveChanges();
            return true;
        }

        public void ChangeAnswerToCorrectOne(int qId, int answernum)
        {
            _dbcontext.Answers.Where(a => a.QuestionId == qId && a.AnswerNumber == answernum)
                .ExecuteUpdate(set => set.SetProperty(a => a.IsCorrectAnswer, true));
        }

        public bool IsAnswerCorrect(int qId,int answerId)
        {
            return _dbcontext.Answers.Any(a => a.QuestionId == qId && a.Id == answerId && a.IsCorrectAnswer == true);
        }
        public List<AnswerDto> GetAnswerByQuestion(int questionId)
        {
            return _dbcontext.Answers.Where(a=>a.QuestionId==questionId)
                .Select(a=> new AnswerDto
                {
                    Id=a.Id,
                    Number=a.AnswerNumber,
                    Text=a.TextAnswer
                }).OrderBy(a=>a.Number).ToList();
        }

        public int GetAnswerId (int qId,int answernum)
        {
            return _dbcontext.Answers.Where(a => a.QuestionId == qId && a.AnswerNumber == answernum)
                .Select(a => a.Id).FirstOrDefault();

        }
    }
}
