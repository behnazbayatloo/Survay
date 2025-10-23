using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Domain.Entities
{
    public class Vote
    {
        public int Id { get; set; } 
        public Answer Answer { get; set; }
        public int AnswerId { get; set; }
        public NormalUser AnsweredBy { get; set; }
        public int NormalUserId { get; set; } 
        
        public bool IsVoteCorrect { get; set; }
    }
}
