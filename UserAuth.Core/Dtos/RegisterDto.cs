using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAuth.Core.Entities;

namespace UserAuth.Core.Dtos
{
    public class RegisterDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public GenderOptions? Gender { get; set; }
        public string? PersonName { get; set; }
    }
}
