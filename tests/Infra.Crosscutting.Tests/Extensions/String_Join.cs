using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Extensions
{
    public class String_Join
    {
        [Fact]
        public void ReturnJoinedStringGivenValidStringArray()
        {
            string[] stringArray = new string[] { "test", "test1" };
            string joinedArray = stringArray.Join(", ");

            joinedArray.Should().NotBeNull().And.Be("test, test1");
        }

        [Fact]
        public void ReturnJoinedStringGivenValidObjectArray()
        {
            object[] stringArray = new object[] { "test", 1, true };
            string joinedArray = stringArray.Join(", ");

            joinedArray.Should().NotBeNull().And.Be("test, 1, True");
        }
    }
}
