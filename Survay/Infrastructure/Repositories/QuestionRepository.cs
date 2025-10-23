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
    public class QuestionRepository: IQuestionRepository
    {
        private readonly AppDbContext _dbcontext;
        public QuestionRepository()
        {
            _dbcontext = new AppDbContext();    
        }
        public int CreateQuestion(string txt,int pollId,int questionNum)
        {
            Question question = new Question()
            {
                PollId = pollId,
                QuestionNumber = questionNum,
                Text = txt
            };
            _dbcontext.Add(question);
            _dbcontext.SaveChanges();
            return question.Id;
        }

        public List<QuestionDto> GetQuestions(int pollId)
        {
            return _dbcontext.Questions.Where(q=> q.PollId == pollId).
                Select(q=> new QuestionDto
                {
                    Id = q.Id,
                    Text = q.Text,
                    QuestionNumber=q.QuestionNumber

                }).OrderBy(q=>q.QuestionNumber).ToList();
        }

        public List<int> GetQuestionId(int pollId)
        {
            return _dbcontext.Questions.Where(q=> q.PollId==pollId)
                .Select(q=> q.Id
                ).ToList();
        }
        public bool DeleteQuestions(int pollId)
        {
            _dbcontext.Questions.Where(q => q.PollId == pollId)
                .ExecuteDelete();
            return true;
        }
    }
}
