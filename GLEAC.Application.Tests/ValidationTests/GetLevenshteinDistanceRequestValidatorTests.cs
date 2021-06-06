using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.TestHelper;
using GLEAC.Application.LevenshteinDistance;
using Xunit;

namespace GLEAC.Application.UnitTests.ValidationTests
{
    public class GetLevenshteinDistanceRequestValidatorTests
    {
        private GetLevenshteinDistanceRequestValidator _validator;

        public GetLevenshteinDistanceRequestValidatorTests()
        {
            _validator = new GetLevenshteinDistanceRequestValidator();
        }

        [Fact]
        public void ShouldThrowErrorWhenString1IsNull()
        {
            var getLevenshteinDistanceRequest = new GetLevenshteinDistanceRequest();
            getLevenshteinDistanceRequest.String1 = null;
            getLevenshteinDistanceRequest.String2 = "veeresh";

            var result = _validator.TestValidate(getLevenshteinDistanceRequest);

            result.ShouldHaveValidationErrorFor(cur => cur.String1);
        }

        [Fact]
        public void ShouldThrowErrorWhenString2IsNull()
        {
            var getLevenshteinDistanceRequest = new GetLevenshteinDistanceRequest();
            getLevenshteinDistanceRequest.String1 = "veeresh";
            getLevenshteinDistanceRequest.String2 = null;

            var result = _validator.TestValidate(getLevenshteinDistanceRequest);

            result.ShouldHaveValidationErrorFor(cur => cur.String2);
        }


        [Fact]
        public void ShouldThrowErrorWhenString1ContainsSpecialChars()
        {
            var getLevenshteinDistanceRequest = new GetLevenshteinDistanceRequest();
            getLevenshteinDistanceRequest.String1 = "veeresh$";
            getLevenshteinDistanceRequest.String2 = "veeresh";

            var result = _validator.TestValidate(getLevenshteinDistanceRequest);

            result.ShouldHaveValidationErrorFor(cur => cur.String1);
        }

        [Fact]
        public void ShouldThrowErrorWhenString2ContainsSpecialChars()
        {
            var getLevenshteinDistanceRequest = new GetLevenshteinDistanceRequest();
            getLevenshteinDistanceRequest.String1 = "veeresh";
            getLevenshteinDistanceRequest.String2 = "veeresh$";

            var result = _validator.TestValidate(getLevenshteinDistanceRequest);

            result.ShouldHaveValidationErrorFor(cur => cur.String2);
        }
    }
}
