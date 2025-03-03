using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuth.Core.Entities
{
    public class AuthenticationResponse
    {
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Gender { get; set; }
        public string? PersonName { get; set; }
        public string? Token  { get; set; }
        public bool Success { get; set; }
    }
}
