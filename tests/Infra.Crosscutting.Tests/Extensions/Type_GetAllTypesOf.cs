using System.Linq;
using FluentAssertions;
using Ritter.Infra.Crosscutting.Extensions;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Extensions
{
    public class Type_GetAllTypesOf
    {
        [Fact]
        public void ReturnAllNonAbstractClasses()
        {
            var types = GetType().Assembly
                .GetAllTypesOf<BaseClass>()
                .ToList();

            types
                .Should().NotBeNullOrEmpty()
                .And.HaveCount(2);

            types[0].Should().BeAssignableTo(typeof(ExtendedClass1));
            types[1].Should().BeAssignableTo(typeof(ExtendedClass2));
        }
    }

    internal abstract class BaseClass
    {

    }

    internal class ExtendedClass1 : BaseClass
    {

    }

    internal class ExtendedClass2 : BaseClass
    {

    }

    internal abstract class ExtendedClass3 : BaseClass
    {

    }
}
