using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Ritter.Domain;
using Ritter.Infra.Crosscutting.Specifications;
using Ritter.Infra.Data.Tests.Extensions;
using Ritter.Infra.Data.Tests.Mocks;
using Xunit;

namespace Ritter.Infra.Data.Tests.Repositories
{
    public class Repository_Remove
    {
        [Fact]
        public void CallSaveChangesSuccessfullyGivenOneEntity()
        {
            var mockedTests = new List<Test>();

            Mock<DbSet<Test>> mockDbSet = mockedTests
                .AsQueryable()
                .BuildMockDbSet();

            var mockUnitOfWork = new Mock<IEFUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);
            mockUnitOfWork.Setup(p => p.SaveChanges());

            ISqlRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            var test = new Test();
            testRepository.Remove(test);

            mockUnitOfWork.Verify(x => x.Set<Test>().Remove(It.IsAny<Test>()), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void CallSaveChangesSuccessfullyGivenOneEntityAsync()
        {
            var mockedTests = new List<Test>();

            Mock<DbSet<Test>> mockDbSet = mockedTests
                .AsQueryable()
                .BuildMockDbSet();

            var mockUnitOfWork = new Mock<IEFUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);
            mockUnitOfWork.Setup(p => p.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(It.IsAny<int>()));

            ISqlRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            var test = new Test();
            testRepository.RemoveAsync(test).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>().Remove(It.IsAny<Test>()), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullEntity()
        {
            var mockUnitOfWork = new Mock<IEFUnitOfWork>();

            Action act = () =>
            {
                ISqlRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.Remove((Test)null);
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
                testRepository.RemoveAsync((Test)null).GetAwaiter().GetResult();
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("entity");
        }

        [Fact]
        public void CallSaveChangesSuccessfullyGivenManyEntities()
        {
            var mockedTests = new List<Test>();

            Mock<DbSet<Test>> mockDbSet = mockedTests
                .AsQueryable()
                .BuildMockDbSet();

            var mockUnitOfWork = new Mock<IEFUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);
            mockUnitOfWork.Setup(p => p.SaveChanges());

            ISqlRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            List<Test> tests = MockTests();
            testRepository.Remove(tests);

            mockUnitOfWork.Verify(x => x.Set<Test>().RemoveRange(It.IsAny<IEnumerable<Test>>()), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void CallSaveChangesSuccessfullyGivenManyEntitiesAsync()
        {
            var mockedTests = new List<Test>();

            Mock<DbSet<Test>> mockDbSet = mockedTests
                .AsQueryable()
                .BuildMockDbSet();

            var mockUnitOfWork = new Mock<IEFUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);
            mockUnitOfWork.Setup(p => p.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(It.IsAny<int>()));

            ISqlRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            List<Test> tests = MockTests();
            testRepository.RemoveAsync(tests).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>().RemoveRange(It.IsAny<IEnumerable<Test>>()), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullEntityEnumerable()
        {
            var mockUnitOfWork = new Mock<IEFUnitOfWork>();

            Action act = () =>
            {
                ISqlRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.Remove((IEnumerable<Test>)null);
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

            var mockUnitOfWork = new Mock<IEFUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);
            mockUnitOfWork.Setup(p => p.SaveChanges());

            ISpecification<Test> spec = new DirectSpecification<Test>(p => p.Id == 1);
            ISqlRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);

            testRepository.Remove(spec);

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Exactly(2));
            mockUnitOfWork.Verify(x => x.Set<Test>().RemoveRange(It.IsAny<IEnumerable<Test>>()), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Fact]
        public void CallSaveChangesSuccessfullyGivenSpecificationAsync()
        {
            List<Test> mockedTests = MockTests();

            Mock<DbSet<Test>> mockDbSet = mockedTests
                .AsQueryable()
                .BuildMockDbSet();

            var mockUnitOfWork = new Mock<IEFUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);
            mockUnitOfWork.Setup(p => p.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(It.IsAny<int>()));

            ISpecification<Test> spec = new DirectSpecification<Test>(p => p.Id == 1);
            ISqlRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);

            testRepository.RemoveAsync(spec).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Exactly(2));
            mockUnitOfWork.Verify(x => x.Set<Test>().RemoveRange(It.IsAny<IEnumerable<Test>>()), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullSpecification()
        {
            var mockUnitOfWork = new Mock<IEFUnitOfWork>();

            Action act = () =>
            {
                ISqlRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.Remove((ISpecification<Test>)null);
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("specification");
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullSpecificationAsync()
        {
            var mockUnitOfWork = new Mock<IEFUnitOfWork>();

            Action act = () =>
            {
                ISqlRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.RemoveAsync((ISpecification<Test>)null).GetAwaiter().GetResult();
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("specification");
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
