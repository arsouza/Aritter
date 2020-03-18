using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Ritter.Domain;
using Ritter.Infra.Crosscutting.Specifications;
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
    public class Repository_Remove
    {
        [Fact]
        public void CallSaveChangesSuccessfullyGivenOneEntity()
        {
            List<Test> mockedTests = new List<Test>();

            Mock<DbSet<Test>> mockDbSet = mockedTests
                .AsQueryable()
                .BuildMockDbSet();

            Mock<IEFUnitOfWork> mockUnitOfWork = new Mock<IEFUnitOfWork>();
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

            Mock<DbSet<Test>> mockDbSet = mockedTests
                .AsQueryable()
                .BuildMockDbSet();

            Mock<IEFUnitOfWork> mockUnitOfWork = new Mock<IEFUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);
            mockUnitOfWork.Setup(p => p.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(It.IsAny<int>()));

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            Test test = new Test();
            testRepository.RemoveAsync(test).GetAwaiter().GetResult();

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
                testRepository.Remove((Test)null);
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
                testRepository.RemoveAsync((Test)null).GetAwaiter().GetResult();
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("entity");
        }

        [Fact]
        public void CallSaveChangesSuccessfullyGivenManyEntities()
        {
            List<Test> mockedTests = new List<Test>();

            Mock<DbSet<Test>> mockDbSet = mockedTests
                .AsQueryable()
                .BuildMockDbSet();

            Mock<IEFUnitOfWork> mockUnitOfWork = new Mock<IEFUnitOfWork>();
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

            Mock<DbSet<Test>> mockDbSet = mockedTests
                .AsQueryable()
                .BuildMockDbSet();

            Mock<IEFUnitOfWork> mockUnitOfWork = new Mock<IEFUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);
            mockUnitOfWork.Setup(p => p.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(It.IsAny<int>()));

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            List<Test> tests = MockTests();
            testRepository.RemoveAsync(tests).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullEntityEnumerable()
        {
            Mock<IEFUnitOfWork> mockUnitOfWork = new Mock<IEFUnitOfWork>();

            Action act = () =>
            {
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.Remove((IEnumerable<Test>)null);
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
                testRepository.RemoveAsync((IEnumerable<Test>)null).GetAwaiter().GetResult();
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("entities");
        }

        [Fact]
        public void CallSaveChangesSuccessfullyGivenSpecification()
        {
            List<Test> mockedTests = MockTests();

            Mock<DbSet<Test>> mockDbSet = mockedTests
                .AsQueryable()
                .BuildMockDbSet();

            Mock<IEFUnitOfWork> mockUnitOfWork = new Mock<IEFUnitOfWork>();
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

            Mock<DbSet<Test>> mockDbSet = mockedTests
                .AsQueryable()
                .BuildMockDbSet();

            Mock<IEFUnitOfWork> mockUnitOfWork = new Mock<IEFUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);
            mockUnitOfWork.Setup(p => p.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(It.IsAny<int>()));

            ISpecification<Test> spec = new DirectSpecification<Test>(p => p.Id == 1);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);

            testRepository.RemoveAsync(spec).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Exactly(2));
            mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullSpecification()
        {
            Mock<IEFUnitOfWork> mockUnitOfWork = new Mock<IEFUnitOfWork>();

            Action act = () =>
            {
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.Remove((ISpecification<Test>)null);
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("specification");
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullSpecificationAsync()
        {
            Mock<IEFUnitOfWork> mockUnitOfWork = new Mock<IEFUnitOfWork>();

            Action act = () =>
            {
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.RemoveAsync((ISpecification<Test>)null).GetAwaiter().GetResult();
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("specification");
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
