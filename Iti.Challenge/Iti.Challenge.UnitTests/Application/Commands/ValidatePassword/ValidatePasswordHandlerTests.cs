using FluentAssertions;
using Iti.Challenge.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Iti.Challenge.UnitTests.Application.Commands.ValidatePassword
{
    public class ValidatePasswordHandlerTests
    {
        [Fact(DisplayName = "Password should be valid")]
        public void PasswordShouldBeValid()
        {
            var result = GetResultFromHandler("AbTp9!fok");

            result.Result.Message.Should().Be("Senha válida!");
            result.Result.IsValid.Should().BeTrue();
        }

        [Fact(DisplayName = "Should be invalid with empty password")]
        public void ShouldBeInvalidWithEmptyPassword()
        {
            var result = GetResultFromHandler("");

            result.Result.IsValid.Should().BeFalse();
        }

        [Fact(DisplayName = "Should be invalid without letters")]
        public void ShouldBeInvalidWithoutLetters()
        {
            var result = GetResultFromHandler("123456789");

            result.Result.IsValid.Should().BeFalse();
        }

        [Fact(DisplayName = "Should be invalid without numbers")]
        public void ShouldBeInvalidWithoutNumbers()
        {
            var result = GetResultFromHandler("AAAbbbCcc");

            result.Result.IsValid.Should().BeFalse();
        }

        [Fact(DisplayName = "Should be invalid without uppercase letters")]
        public void ShouldBeInvalidWithoutUppercaseLetters()
        {
            var result = GetResultFromHandler("abc123456789");

            result.Result.IsValid.Should().BeFalse();
        }

        [Fact(DisplayName = "Should be invalid with nine or less caracteres")]
        public void ShouldBeInvalidWithNineOrLessCaracteres()
        {
            var result = GetResultFromHandler("AAAbbbCc");

            result.Result.IsValid.Should().BeFalse();
        }

        [Fact(DisplayName = "Should be invalid without special charactere")]
        public void ShouldBeInvalidWithoutSpecialCharactere()
        {
            var result = GetResultFromHandler("AbTp9 fok");
            
            result.Result.IsValid.Should().BeFalse();
        }

        [Fact(DisplayName = "Should be invalid with repeated characteres")]
        public void ShouldBeInvalidWithRepeatedCharacteres()
        {
            var result = GetResultFromHandler("AbTp9!foo");

            result.Result.IsValid.Should().BeFalse();
        }

        private static Task<ValidatePasswordResponse> GetResultFromHandler(string password)
        {
            var handler = new ValidatePasswordHandler();
            var request = new ValidatePasswordRequest
            {
                Password = password
            };
            var cancelationToken = new CancellationToken();

            return handler.Handle(request, cancelationToken);
        }
    }
}
