using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Domain.Dto
{
    public class AnswerVoteDto
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public int Vote { get; set; }
    }
}
