﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Models
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}