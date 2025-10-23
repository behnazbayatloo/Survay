using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Domain.Entities
{
    public class NormalUser:User
    {
        public List<Vote>? Votes { get; set; }

        public List<Poll_NUser> Polls { get; set; }
    }
}
