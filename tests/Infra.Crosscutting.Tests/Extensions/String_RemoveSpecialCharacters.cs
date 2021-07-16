using System;
using FluentAssertions;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Extensions
{
    public class String_RemoveSpecialCharacters
    {
        [Theory]
        [InlineData("abcdefGHIJKLM0123434!@#$%¨&*()_+-=", "abcdefGHIJKLM0123434")]
        [InlineData("abcdefGHIJKLM0123434´`[{~^]};:/?,<.>", "abcdefGHIJKLM0123434")]
        public void RemoveRemoveSpecialCharactersGivenNotEmptyString(string test, string expected)
        {
            test.RemoveSpecialCharacters()
                .Should()
                .NotBeNullOrWhiteSpace()
                .And.Be(expected);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void RemoveRemoveSpecialCharactersGivenEmptyOrNullString(string test)
        {
            test.RemoveSpecialCharacters()
                .Should()
                .BeNullOrWhiteSpace();
        }
    }
}
