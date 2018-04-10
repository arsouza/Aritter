using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Ritter.Domain.Seedwork;
using Ritter.Infra.Data.Seedwork.Tests.Extensions;
using Ritter.Infra.Data.Seedwork.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Ritter.Infra.Data.Seedwork.Tests.Repositories
{
    public class Repository_Add
    {
        [Fact]
        public void CallSaveChangesSuccessfullyGivenOneEntity()
        {
            List<Test> mockedTests = new List<Test>();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);
            mockUnitOfWork.Setup(p => p.SaveChanges());

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            Test test = new Test();
            testRepository.Add(test);

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void CallSaveChangesSuccessfullyGivenOneEntityAsync()
        {
            List<Test> mockedTests = new List<Test>();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryableAsync(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);
            mockUnitOfWork.Setup(p => p.SaveChangesAsync()).Returns(Task.FromResult(It.IsAny<int>()));

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            Test test = new Test();
            testRepository.AddAsync(test).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullEntity()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();

            Action act = () =>
            {
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.Add((Test) null);
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("entity");
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullEntityAsync()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();

            Action act = () =>
            {
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.AddAsync((Test) null).GetAwaiter().GetResult();
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("entity");
        }

        [Fact]
        public void CallSaveChangesSuccessfullyGivenManyEntities()
        {
            List<Test> mockedTests = new List<Test>();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);
            mockUnitOfWork.Setup(p => p.SaveChanges());

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            List<Test> tests = MockTests();
            testRepository.Add(tests);

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullEntityEnumerable()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();

            Action act = () =>
            {
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.Add((IEnumerable<Test>) null);
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("entities");
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullEntityEnumerableAsync()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();

            Action act = () =>
            {
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.AddAsync((IEnumerable<Test>) null).GetAwaiter().GetResult();
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("entities");
        }

        [Fact]
        public void CallSaveChangesSuccessfullyGivenManyEntitiesAsync()
        {
            List<Test> mockedTests = new List<Test>();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);
            mockUnitOfWork.Setup(p => p.SaveChangesAsync()).Returns(Task.FromResult(It.IsAny<int>()));

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            List<Test> tests = MockTests();
            testRepository.AddAsync(tests).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        private static List<Test> MockTests(int count)
        {
            List<Test> tests = new List<Test>();

            for (int i = 1; i <= count; i++)
            {
                tests.Add(new Test(i));
            }

            return tests;
        }

        private static List<Test> MockTests()
        {
            return MockTests(5);
        }
    }
}
