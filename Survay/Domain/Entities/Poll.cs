using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Domain.Entities
{
    public class Poll
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public int TotalQuestionCount { get; set; }
        public List<Question>? Questions { get; set; }
        public Admin CreatedBy { get; set; }
        public int AdminId { get; set; }
        
        public List<Poll_NUser> Voted { get; set; }


    }
}
