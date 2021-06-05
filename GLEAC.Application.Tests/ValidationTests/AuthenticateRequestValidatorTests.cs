using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.TestHelper;
using GLEAC.Application.Authentication;
using GLEAC.Application.LevenshteinDistance;
using Xunit;

namespace GLEAC.Application.UnitTests.ValidationTests
{
    public class AuthenticateRequestValidatorTests
    {
        private AuthenticateRequestValidator _validator;

        public AuthenticateRequestValidatorTests()
        {
            _validator = new AuthenticateRequestValidator();
        }

        [Fact]
        public void ShouldThrowErrorWhenUsernameIsNull()
        {
            var authenticateRequest = new AuthenticateRequest();
            authenticateRequest.Username = null;

            var result = _validator.TestValidate(authenticateRequest);

            result.ShouldHaveValidationErrorFor(cur => cur.Username);
        }

        [Fact]
        public void ShouldThrowErrorWhenUsernameIsEmpty()
        {
            var authenticateRequest = new AuthenticateRequest();
            authenticateRequest.Username = "";

            var result = _validator.TestValidate(authenticateRequest);

            result.ShouldHaveValidationErrorFor(cur => cur.Username);
        }

        [Fact]
        public void ShouldThrowErrorWhenPasswordIsNull()
        {
            var authenticateRequest = new AuthenticateRequest();
            authenticateRequest.Password = null;

            var result = _validator.TestValidate(authenticateRequest);

            result.ShouldHaveValidationErrorFor(cur => cur.Password);
        }

        [Fact]
        public void ShouldThrowErrorWhenPasswordIsEmpty()
        {
            var authenticateRequest = new AuthenticateRequest();
            authenticateRequest.Password = "";

            var result = _validator.TestValidate(authenticateRequest);

            result.ShouldHaveValidationErrorFor(cur => cur.Password);
        }
    }
}
