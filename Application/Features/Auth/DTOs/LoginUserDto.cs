using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.DTOs
{
    public class LoginUserDto
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
