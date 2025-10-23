using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Domain.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public int AnswerNumber { get; set; }
        public string TextAnswer { get; set;}
        
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public List<Vote> Votes { get; set; }


    }
}
