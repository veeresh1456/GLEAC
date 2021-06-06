using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace GLEAC.Application.LevenshteinDistance
{
    public class GetLevenshteinDistanceRequestValidator : AbstractValidator<GetLevenshteinDistanceRequest>
    {
        public GetLevenshteinDistanceRequestValidator()
        {
            RuleFor(cur => cur.String1)
                .NotNull().WithMessage("String1 is required.");

            RuleFor(cur => cur.String2)
                .NotNull().WithMessage("String2 is required.");

            RuleFor(cur => cur.String1)
                .Matches("^[a-zA-Z0-9]*$").WithMessage("String1 should not contains special characters.");

            RuleFor(cur => cur.String2)
                .Matches("^[a-zA-Z0-9]*$").WithMessage("String2 should not contains special characters.");
        }
    }
}
