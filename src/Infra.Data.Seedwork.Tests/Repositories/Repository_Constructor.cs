using Infra.Data.Seedwork.Tests.Repositories.Mock;
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
        public void CreateSimpleRepository()
        {
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            TestRepository testRepository = new TestRepository(mockUnitOfWork.Object);

            Assert.Equal(mockUnitOfWork.Object, testRepository.UnitOfWork);
        }

        [Fact]
        public void CreateGenericRepository()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            GenericTestRepository testRepository = new GenericTestRepository(mockUnitOfWork.Object);

            Assert.Equal(mockUnitOfWork.Object, testRepository.UnitOfWork);
        }

        [Fact]
        public void CreateSimpleRepositoryThrowsArgumentNullException()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            {
                TestRepository testRepository = new TestRepository(null);
            });

            Assert.NotNull(exception);
            Assert.Equal("unitOfWork", exception.ParamName);
        }

        [Fact]
        public void CreateGenericRepositoryThrowsArgumentNullException()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            {
                GenericTestRepository testRepository = new GenericTestRepository(null);
            });

            Assert.NotNull(exception);
            Assert.Equal("unitOfWork", exception.ParamName);
        }
    }
}
