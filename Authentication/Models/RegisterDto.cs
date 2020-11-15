using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Models
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

}