using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Ritter.Domain.Seedwork;
using Ritter.Domain.Seedwork.Specifications;
using Ritter.Infra.Data.Seedwork;
using Ritter.Infra.Data.Seedwork.Tests.Extensions;
using Ritter.Infra.Data.Seedwork.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Ritter.Infra.Data.Seedwork.Tests.Repositories
{
    public class Repository_Remove
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
            testRepository.Remove(test);

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
            testRepository.RemoveAsync(test).GetAwaiter().GetResult();

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
                testRepository.Remove((Test) null);
            };

            act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("entity");
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullEntityAsync()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();

            Action act = () =>
            {
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.RemoveAsync((Test) null).GetAwaiter().GetResult();
            };

            act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("entity");
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
            testRepository.Remove(tests);

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChanges(), Times.Once);
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
            testRepository.RemoveAsync(tests).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullEntityEnumerable()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();

            Action act = () =>
            {
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.Remove((IEnumerable<Test>) null);
            };

            act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("entities");
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullEntityEnumerableAsync()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();

            Action act = () =>
            {
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.RemoveAsync((IEnumerable<Test>) null).GetAwaiter().GetResult();
            };

            act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("entities");
        }

        [Fact]
        public void CallSaveChangesSuccessfullyGivenSpecification()
        {
            List<Test> mockedTests = MockTests();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);
            mockUnitOfWork.Setup(p => p.SaveChanges());

            ISpecification<Test> spec = new DirectSpecification<Test>(p => p.Id == 1);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);

            testRepository.Remove(spec);

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Exactly(2));
            mockUnitOfWork.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void CallSaveChangesSuccessfullyGivenSpecificationAsync()
        {
            List<Test> mockedTests = MockTests();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryableAsync(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);
            mockUnitOfWork.Setup(p => p.SaveChangesAsync()).Returns(Task.FromResult(It.IsAny<int>()));

            ISpecification<Test> spec = new DirectSpecification<Test>(p => p.Id == 1);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);

            testRepository.RemoveAsync(spec).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Exactly(2));
            mockUnitOfWork.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullSpecification()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();

            Action act = () =>
            {
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.Remove((ISpecification<Test>) null);
            };

            act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("specification");
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullSpecificationAsync()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();

            Action act = () =>
            {
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.RemoveAsync((ISpecification<Test>) null).GetAwaiter().GetResult();
            };

            act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("specification");
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