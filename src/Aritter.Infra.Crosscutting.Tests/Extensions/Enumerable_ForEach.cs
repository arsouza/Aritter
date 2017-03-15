using Aritter.Infra.Crosscutting.Extensions;
using Aritter.Infra.Crosscutting.Tests.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Aritter.Infra.Crosscutting.Tests.Extensions
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

            Assert.NotNull(source);
            Assert.NotEmpty(source);
            Assert.Equal(2, source.Count());
            Assert.Equal("1", source.ElementAt(0).Value);
            Assert.Equal("2", source.ElementAt(1).Value);
        }

        [Fact]
        public void NotThrowExceptionGivenEmptyEnumerable()
        {
            IEnumerable<TestObject1> source = new List<TestObject1>();

            source.ForEach(p =>
            {
                p.Value = p.Id.ToString();
            });

            Assert.NotNull(source);
            Assert.Empty(source);
        }

        [Fact]
        public void ThrowArgumentNullExceptionGivenNull()
        {
            IEnumerable<TestObject1> source = null;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            {
                source.ForEach(p =>
                {
                    p.Value = p.Id.ToString();
                });
            });
            
            Assert.Equal("source", exception.ParamName);
        }

        [Fact]
        public void ThrowArgumentNullExceptionGivenNullAction()
        {
            IEnumerable<TestObject1> source = new List<TestObject1>();

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            {
                source.ForEach(null);
            });
            
            Assert.Equal("action", exception.ParamName);
        }
    }
}