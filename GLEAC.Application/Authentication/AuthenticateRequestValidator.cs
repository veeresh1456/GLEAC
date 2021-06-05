using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using FluentValidation;

namespace GLEAC.Application.Authentication
{
    public class AuthenticateRequestValidator : AbstractValidator<AuthenticateRequest>
    {
        public AuthenticateRequestValidator()
        {
            RuleFor(cur => cur.Username)
                .NotEmpty().WithMessage("Username is required.");

            RuleFor(cur => cur.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
