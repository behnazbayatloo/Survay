using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Domain.Entities
{
    public class Admin:User
    {
        public List<Poll>? Polls { get; set; }

    }
}
