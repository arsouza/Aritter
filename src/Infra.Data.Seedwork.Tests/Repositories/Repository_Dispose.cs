using Infra.Data.Seedwork.Tests.Repositories.Mock;
using Moq;
using Ritter.Domain.Seedwork;
using Ritter.Infra.Data.Seedwork;
using Xunit;

namespace Infra.Data.Seedwork.Tests.Repositories
{
    public class Repository_Dispose
    {
        [Fact]
        public void SimpleRepositoryDisposeSuccessfully()
        {
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Dispose());

            TestRepository testRepository = new TestRepository(mockUnitOfWork.Object);
            testRepository.Dispose();

            mockUnitOfWork.Verify(x => x.Dispose(), Times.Once);
            Assert.Null(testRepository.UnitOfWork);
        }

        [Fact]
        public void SimpleRepositoryDisposeMustBeCalledOnlyOnce()
        {
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Dispose());

            TestRepository testRepository = new TestRepository(mockUnitOfWork.Object);
            testRepository.Dispose();
            testRepository.Dispose();

            mockUnitOfWork.Verify(x => x.Dispose(), Times.Once);
            Assert.Null(testRepository.UnitOfWork);
        }

        [Fact]
        public void GenericRepositoryDisposeSuccessfully()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Dispose());

            GenericTestRepository testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            testRepository.Dispose();

            mockUnitOfWork.Verify(x => x.Dispose(), Times.Exactly(2));
            Assert.Null(testRepository.UnitOfWork);
        }

        [Fact]
        public void GenericRepositoryDisposeMustBeCalledExactlyTwoTimes()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Dispose());

            GenericTestRepository testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            testRepository.Dispose();
            testRepository.Dispose();

            mockUnitOfWork.Verify(x => x.Dispose(), Times.Exactly(2));
            Assert.Null(testRepository.UnitOfWork);
        }
    }
}
