using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAuth.Core.Dtos;
using UserAuth.Core.Entities;
using UserAuth.Core.RepositoryContracts;
using UserAuth.Core.ServicesContract;

namespace UserAuth.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository , IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse?> Login(LoginDto loginDto)
        {
            var user =  await _userRepository.GetUserByEmailAndPassword(loginDto.Email, loginDto.Password);

            //var AuthResponse = new AuthenticationResponse
            //{
            //    Gender = user.Gender.ToString(),
            //    Email = user.Email,
            //    Password = user.Password,
            //    PersonName = user.PersonName,
            //    Success = true
            //};

            var AuthResponse = _mapper.Map<AuthenticationResponse>(user);


            return AuthResponse;

        }

        public async Task<AuthenticationResponse> Register(RegisterDto registerDto)
        {

            var appUser = new ApplicationUser
            {
                Email = registerDto.Email,
                Password = registerDto.Password,
                Gender = registerDto.Gender.ToString(),
                UserId = Guid.NewGuid(),
                PersonName = registerDto.PersonName,
            };

            var user = await  _userRepository.AddUser(appUser);

            return _mapper.Map<AuthenticationResponse>(user);
        }
    }
}
