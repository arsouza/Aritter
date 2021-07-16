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
        public void RemoveRemoveSpecialCharactersSuccessfully(string test, string expected)
        {
            string cleanedValue = test.RemoveSpecialCharacters();
            cleanedValue.Should().NotBeNullOrWhiteSpace().And.Be(expected);
        }
    }
}
