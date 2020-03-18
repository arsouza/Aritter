using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Ritter.Domain;
using Ritter.Infra.Data.Tests.Extensions;
using Ritter.Infra.Data.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ritter.Infra.Data.Tests.Repositories
{
    public class Repository_Add
    {
        [Fact]
        public void CallSaveChangesSuccessfullyGivenOneEntity()
        {
            List<Test> mockedTests = new List<Test>();

            Mock<DbSet<Test>> mockDbSet = mockedTests.AsQueryable().BuildMockDbSet();

            Mock<IEFUnitOfWork> mockUnitOfWork = new Mock<IEFUnitOfWork>();
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

            Mock<DbSet<Test>> mockDbSet = mockedTests.AsQueryable().BuildMockDbSet();

            Mock<IEFUnitOfWork> mockUnitOfWork = new Mock<IEFUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);
            mockUnitOfWork.Setup(p => p.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(It.IsAny<int>()));

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            Test test = new Test();
            testRepository.AddAsync(test).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullEntity()
        {
            Mock<IEFUnitOfWork> mockUnitOfWork = new Mock<IEFUnitOfWork>();

            Action act = () =>
            {
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.Add((Test)null);
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("entity");
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullEntityAsync()
        {
            Mock<IEFUnitOfWork> mockUnitOfWork = new Mock<IEFUnitOfWork>();

            Action act = () =>
            {
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.AddAsync((Test)null).GetAwaiter().GetResult();
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("entity");
        }

        [Fact]
        public void CallSaveChangesSuccessfullyGivenManyEntities()
        {
            List<Test> mockedTests = new List<Test>();

            Mock<DbSet<Test>> mockDbSet = mockedTests.AsQueryable().BuildMockDbSet();

            Mock<IEFUnitOfWork> mockUnitOfWork = new Mock<IEFUnitOfWork>();
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
            Mock<IEFUnitOfWork> mockUnitOfWork = new Mock<IEFUnitOfWork>();

            Action act = () =>
            {
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.Add((IEnumerable<Test>)null);
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("entities");
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullEntityEnumerableAsync()
        {
            Mock<IEFUnitOfWork> mockUnitOfWork = new Mock<IEFUnitOfWork>();

            Action act = () =>
            {
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.AddAsync((IEnumerable<Test>)null).GetAwaiter().GetResult();
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("entities");
        }

        [Fact]
        public void CallSaveChangesSuccessfullyGivenManyEntitiesAsync()
        {
            List<Test> mockedTests = new List<Test>();

            Mock<DbSet<Test>> mockDbSet = mockedTests.AsQueryable().BuildMockDbSet();

            Mock<IEFUnitOfWork> mockUnitOfWork = new Mock<IEFUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);
            mockUnitOfWork.Setup(p => p.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(It.IsAny<int>()));

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            List<Test> tests = MockTests();
            testRepository.AddAsync(tests).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
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
