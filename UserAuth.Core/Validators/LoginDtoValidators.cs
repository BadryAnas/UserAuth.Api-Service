using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAuth.Core.Dtos;

namespace UserAuth.Core.Validators
{
    public class LoginDtoValidators : AbstractValidator<LoginDto>
    {
        public LoginDtoValidators() 
        {
            RuleFor(temp => temp.Password).NotEmpty()
                .WithMessage("Password is Required");

            RuleFor(temp => temp.Email)
                .NotEmpty().WithMessage("Email is Required")
                .EmailAddress().WithMessage("Ivalid Email");
        }
    }
}
