using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Domain.Dto
{
    public class ResultDto
    {
        public string QuestionText { get; set; }
        public int QuestionNumber {  get; set; }
        public List<AnswerVoteDto> Answers { get; set; }
        //public int ItemNum1 { get; set; }
        //public string Item1 {  get; set; }
        //public int Item1Vote { get; set; }
        //public int ItemNum2 { get; set; }
        //public string Item2 { get; set; }
        //public int Item2Vote { get; set; }
        //public int ItemNum3 { get; set; }
        //public string Item3 { get; set; }
        //public int Item3Vote { get; set; }
        //public int ItemNum4 { get; set; }
        //public string Item4 { get; set; }
        //public int Item4Vote { get; set; }
    }
}
