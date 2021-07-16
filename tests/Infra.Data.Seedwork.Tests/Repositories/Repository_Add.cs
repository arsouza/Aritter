using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Ritter.Domain;
using Ritter.Infra.Data.Tests.Extensions;
using Ritter.Infra.Data.Tests.Mocks;
using Xunit;

namespace Ritter.Infra.Data.Tests.Repositories
{
    public class Repository_Add
    {
        [Fact]
        public void CallSaveChangesSuccessfullyGivenOneEntity()
        {
            var mockedTests = new List<Test>();

            Mock<DbSet<Test>> mockDbSet = mockedTests.AsQueryable().BuildMockDbSet();

            var mockUnitOfWork = new Mock<IEFUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);
            mockUnitOfWork.Setup(p => p.SaveChanges());

            ISqlRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            var test = new Test();
            testRepository.Add(test);

            mockUnitOfWork.Verify(x => x.Set<Test>().Add(It.IsAny<Test>()), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void CallSaveChangesSuccessfullyGivenOneEntityAsync()
        {
            var mockedTests = new List<Test>();

            Mock<DbSet<Test>> mockDbSet = mockedTests.AsQueryable().BuildMockDbSet();

            var mockUnitOfWork = new Mock<IEFUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);
            mockUnitOfWork.Setup(p => p.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(It.IsAny<int>()));

            ISqlRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            var test = new Test();
            testRepository.AddAsync(test).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>().AddAsync(It.IsAny<Test>(), It.IsAny<CancellationToken>()), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullEntity()
        {
            var mockUnitOfWork = new Mock<IEFUnitOfWork>();

            Action act = () =>
            {
                ISqlRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.Add((Test)null);
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("entity");
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullEntityAsync()
        {
            var mockUnitOfWork = new Mock<IEFUnitOfWork>();

            Action act = () =>
            {
                ISqlRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.AddAsync((Test)null).GetAwaiter().GetResult();
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("entity");
        }

        [Fact]
        public void CallSaveChangesSuccessfullyGivenManyEntities()
        {
            var mockedTests = new List<Test>();

            Mock<DbSet<Test>> mockDbSet = mockedTests.AsQueryable().BuildMockDbSet();

            var mockUnitOfWork = new Mock<IEFUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);
            mockUnitOfWork.Setup(p => p.SaveChanges());

            ISqlRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            List<Test> tests = MockTests();
            testRepository.Add(tests);

            mockUnitOfWork.Verify(x => x.Set<Test>().AddRange(It.IsAny<IEnumerable<Test>>()), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullEntityEnumerable()
        {
            var mockUnitOfWork = new Mock<IEFUnitOfWork>();

            Action act = () =>
            {
                ISqlRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.Add((IEnumerable<Test>)null);
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("entities");
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullEntityEnumerableAsync()
        {
            var mockUnitOfWork = new Mock<IEFUnitOfWork>();

            Action act = () =>
            {
                ISqlRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.AddAsync((IEnumerable<Test>)null).GetAwaiter().GetResult();
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("entities");
        }

        [Fact]
        public void CallSaveChangesSuccessfullyGivenManyEntitiesAsync()
        {
            var mockedTests = new List<Test>();

            Mock<DbSet<Test>> mockDbSet = mockedTests.AsQueryable().BuildMockDbSet();

            var mockUnitOfWork = new Mock<IEFUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);
            mockUnitOfWork.Setup(p => p.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(It.IsAny<int>()));

            ISqlRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            List<Test> tests = MockTests();
            testRepository.AddAsync(tests).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>().AddRangeAsync(It.IsAny<IEnumerable<Test>>(), It.IsAny<CancellationToken>()), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        private static List<Test> MockTests(int count)
        {
            var tests = new List<Test>();

            for (int i = 1; i <= count; i++)
            {
                tests.Add(new Test(i));
            }

            return tests;
        }

        private static List<Test> MockTests() => MockTests(5);
    }
}
