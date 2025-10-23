using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Domain.Entities
{
    public class Poll_NUser
    {
        public int Id { get; set; }
        public Poll Poll { get; set; }
        public int PollId { get; set; }
        public NormalUser Voted {  get; set; }
        public int VotedId { get; set; }
    }
}
