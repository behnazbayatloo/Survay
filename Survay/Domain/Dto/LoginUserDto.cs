using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survay.Domain.Dto
{
    public  class LoginUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}
