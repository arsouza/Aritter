using FluentAssertions;
using Ritter.Infra.Crosscutting.Extensions;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Ritter.Infra.Crosscutting.Tests.Extensions
{
    public class Enumerable_ForEach
    {
        [Fact]
        public void NotThrowExceptionGivenNotEmptyEnumerable()
        {
            IEnumerable<TestObject1> source = new List<TestObject1>
            {
                new TestObject1 { Id = 1 },
                new TestObject1 { Id = 2 }
            };

            source.ForEach(p =>
            {
                p.Value = p.Id.ToString();
            });

            source.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            source.ElementAt(0).Value.Should().Be("1");
            source.ElementAt(1).Value.Should().Be("2");
        }

        [Fact]
        public void NotThrowExceptionGivenEmptyEnumerable()
        {
            IEnumerable<TestObject1> source = new List<TestObject1>();
            source.ForEach(p => { });

            source.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void ThrowArgumentNullExceptionGivenNull()
        {
            Action act = () =>
            {
                IEnumerable<TestObject1> source = null;
                source.ForEach(p => { });
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("source");
        }

        [Fact]
        public void ThrowArgumentNullExceptionGivenNullAction()
        {
            Action act = () =>
            {
                IEnumerable<TestObject1> source = new List<TestObject1>();
                source.ForEach(null);
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("action");
        }
    }
}
