using FluentAssertions;
using Moq;
using Ritter.Domain;
using Ritter.Infra.Data;
using Ritter.Infra.Data.Tests.Mocks;
using System;
using Xunit;

namespace Ritter.Infra.Data.Tests.Repositories
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
            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("unitOfWork");
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenGenericRepository()
        {
            Action act = () => { new GenericTestRepository(null); };
            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("unitOfWork");
        }
    }
}