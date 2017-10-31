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
            IRepository testRepository = new TestRepository(mockUnitOfWork.Object);

            testRepository.UnitOfWork.Should().NotBeNull().And.Be(mockUnitOfWork.Object);
        }

        [Fact]
        public void NotThrowsAnyExceptionGivenGenericRepository()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);

            testRepository.UnitOfWork.Should().NotBeNull().And.Be(mockUnitOfWork.Object);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenSimpleRepository()
        {
            Action act = () => { new TestRepository(null); };
            act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("unitOfWork");
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenGenericRepository()
        {
            Action act = () => { new GenericTestRepository(null); };
            act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("unitOfWork");
        }
    }
}
