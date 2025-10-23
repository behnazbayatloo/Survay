using Microsoft.EntityFrameworkCore;
using Survay.Contracts.RepositoryContracts;
using Survay.Domain.Dto;
using Survay.Domain.Entities;
using Survay.Infrastructure.AppDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        public List<AnswerVoteDto> GetAnswerVoted(int questionId)
        {
            return _dbcontext.Answers.Where(a => a.QuestionId == questionId)
                .Include(a => a.Votes)
                .Select(a => new AnswerVoteDto
                {
                    Number = a.AnswerNumber,
                    Text = a.TextAnswer,
                    Vote=a.Votes.Count
                }).OrderBy(a => a.Number).ToList();
        }
        public int GetAnswerId (int qId,int answernum)
        {
            return _dbcontext.Answers.Where(a => a.QuestionId == qId && a.AnswerNumber == answernum)
                .Select(a => a.Id).FirstOrDefault();

        }
        public List<int> GetAnswerId(List<int> list)
        {
            List<int> idList = [];
            foreach (var item in list)
            {
                List<int> ids = _dbcontext.Answers.Where(a => a.QuestionId == item)
                      .Select(a => a.Id).ToList();
                idList.AddRange(ids);
            }
            return idList;
        }
        public bool DeleteAnswers(List<int> list)
        {
            foreach (var item in list)
            {
                _dbcontext.Answers.Where(a => a.QuestionId == item)
                    .ExecuteDelete();
            }
            return true;
        }
    }
}
