using FluentAssertions;
using Infra.Data.Seedwork.Tests.Mocks;
using Moq;
using Ritter.Domain.Seedwork;
using Ritter.Infra.Data.Seedwork;
using System;
using Xunit;

namespace Infra.Data.Seedwork.Tests.Repositories
{
    public class Repository_Constructor
    {
        [Fact]
        public void NotThrowsAnyExceptionGivenSimpleRepository()
        {
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            TestRepository testRepository = new TestRepository(mockUnitOfWork.Object);

            testRepository.UnitOfWork.Should().NotBeNull().And.Be(mockUnitOfWork.Object);
        }

        [Fact]
        public void NotThrowsAnyExceptionGivenGenericRepository()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            GenericTestRepository testRepository = new GenericTestRepository(mockUnitOfWork.Object);

            testRepository.UnitOfWork.Should().NotBeNull().And.Be(mockUnitOfWork.Object);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenSimpleRepository()
        {
            Action act = () => { TestRepository testRepository = new TestRepository(null); };
            act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("unitOfWork");
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenGenericRepository()
        {
            Action act = () => { GenericTestRepository testRepository = new GenericTestRepository(null); };
            act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("unitOfWork");
        }
    }
}
