using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class UserRegisterDto
    {
        public required string Email { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}