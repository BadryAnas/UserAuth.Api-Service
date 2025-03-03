using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAuth.Core.Dtos;
using UserAuth.Core.Entities;

namespace UserAuth.Core.ServicesContract
{
    public interface IUserService
    {
        Task<AuthenticationResponse?> Login(LoginDto loginDto);
        Task<AuthenticationResponse?> Register(RegisterDto registerDto);
    }
}
