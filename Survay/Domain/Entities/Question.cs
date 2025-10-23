using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public int QuestionNumber { get; set;}
        public string Text { get; set; }
        public List< Answer> Answers { get; set; }
        //public Answer Answer2 { get; set; }
        //public Answer Answer3 { get; set; }
        //public Answer Answer4 { get; set; }
        public Poll Poll { get; set; }
        public int PollId { get; set; } 

        //public int CorrectAnswerNumber { get; set; }
        public const  int MaxAnswer = 4;
    }
}
