using FluentAssertions;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Tests.Mocks;
using System.Collections;
using System.Linq;
using Xunit;

namespace Infra.Crosscutting.Tests.Paginng
{
    public class PagedList_Constructor
    {
        [Fact]
        public void ReturnNewPagedListGivenValidParameters()
        {
            var items = Enumerable.Repeat(new TestObject1(), 20);

            var pagging = new PagedList<TestObject1>(items, 10, items.Count());

            pagging.TotalCount.Should().Be(20);
            pagging.PageCount.Should().Be(2);
            pagging.PageSize.Should().Be(10);
            pagging.Count().Should().Be(20);
        }

        [Fact]
        public void ReturnNewPagedListGivenNullList()
        {            
            var pagging = new PagedList<TestObject1>(null, 10, 20);

            pagging.TotalCount.Should().Be(20);
            pagging.PageCount.Should().Be(2);
            pagging.PageSize.Should().Be(10);
            pagging.Count().Should().Be(0);
        }

        [Fact]
        public void ReturnNewPagedListGivenEmptyPageSize()
        {
            var pagging = new PagedList<TestObject1>(null, 0, 20);

            pagging.TotalCount.Should().Be(20);
            pagging.PageCount.Should().Be(0);
            pagging.PageSize.Should().Be(0);
            pagging.Count().Should().Be(0);
        }

        [Fact]
        public void ReturnExplicitEnumeratorGivenAnyValue()
        {
            var items = Enumerable.Repeat(new TestObject1(), 20);
            var pagging = new PagedList<TestObject1>(items, 0, 20);
            
            var enumerableEnumerator = (pagging as IEnumerable).GetEnumerator();

            enumerableEnumerator.Should().NotBeNull();
        }
    }
}
