using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Ritter.Domain;
using Ritter.Infra.Data;
using Ritter.Infra.Data.Tests.Extensions;
using Ritter.Infra.Data.Tests.Mocks;
using System.Collections.Generic;
using Xunit;

namespace Ritter.Infra.Data.Tests.Repositories
{
    public class Repository_Get
    {
        [Fact]
        public void ReturnsAnEntityGivenId()
        {
            List<Test> tests = MockTests();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(tests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            Test test = testRepository.Get(1);

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            test.Should().NotBeNull();
            test.Id.Should().Be(1);
        }

        [Fact]
        public void ReturnsNullGivenId()
        {
            List<Test> tests = MockTests();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();

            mockDbSet.SetupAsQueryable(tests);
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            Test test = testRepository.Get(6);

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            test.Should().BeNull();
        }

        [Fact]
        public void ReturnsAnEntityGivenIdAsync()
        {
            List<Test> tests = MockTests();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();

            mockDbSet.SetupAsQueryableAsync(tests);
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            Test test = testRepository.GetAsync(1).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            test.Should().NotBeNull();
            test.Id.Should().Be(1);
        }

        [Fact]
        public void ReturnsNullGivenIdAsync()
        {
            List<Test> tests = MockTests();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();

            mockDbSet.SetupAsQueryableAsync(tests);
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            Test test = testRepository.GetAsync(6).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            test.Should().BeNull();
        }

        private static List<Test> MockTests()
        {
            return new List<Test>
            {
                new Test(1),
                new Test(2),
                new Test(3),
                new Test(4),
                new Test(5)
            };
        }
    }
}