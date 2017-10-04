using FluentAssertions;
using Infra.Data.Seedwork.Tests.Mocks;
using Moq;
using Ritter.Domain.Seedwork;
using Ritter.Infra.Data.Seedwork;
using Xunit;

namespace Infra.Data.Seedwork.Tests.Repositories
{
    public class Repository_Dispose
    {
        [Fact]
        public void CallDisposeTimesOnceGivenSimpleRepository()
        {
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Dispose());

            IRepository testRepository = new TestRepository(mockUnitOfWork.Object);
            testRepository.Dispose();
            testRepository.Dispose();

            mockUnitOfWork.Verify(x => x.Dispose(), Times.Once);
            testRepository.UnitOfWork.Should().BeNull();
        }

        [Fact]
        public void CallDisposeTimesOnceGivenGenericRepository()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Dispose());

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            testRepository.Dispose();

            mockUnitOfWork.Verify(x => x.Dispose(), Times.Exactly(2));
            testRepository.UnitOfWork.Should().BeNull();
        }

        [Fact]
        public void CallDisposeTwoTimesGivenGenericRepository()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Dispose());

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            testRepository.Dispose();
            testRepository.Dispose();

            mockUnitOfWork.Verify(x => x.Dispose(), Times.Exactly(2));
            testRepository.UnitOfWork.Should().BeNull();
        }
    }
}
