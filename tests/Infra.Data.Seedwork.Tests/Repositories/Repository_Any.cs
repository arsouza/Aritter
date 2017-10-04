using FluentAssertions;
using Infra.Data.Seedwork.Tests.Extensions;
using Infra.Data.Seedwork.Tests.Mocks;
using Microsoft.EntityFrameworkCore;
using Moq;
using Ritter.Domain.Seedwork;
using Ritter.Domain.Seedwork.Specs;
using Ritter.Infra.Data.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Infra.Data.Seedwork.Tests.Repositories
{
    public class Repository_Any
    {
        [Fact]
        public void ReturnsTrueGivenAnyEntity()
        {
            List<Test> mockedTests = MockTests();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            bool any = testRepository.Any();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            any.Should().BeTrue();
        }

        [Fact]
        public void ReturnsTrueGivenAnyEntityAsync()
        {
            List<Test> mockedTests = MockTests();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryableAsync(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            bool any = testRepository.AnyAsync().GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            any.Should().BeTrue();
        }

        [Fact]
        public void ReturnsFalseGivenNoneEntity()
        {
            List<Test> mockedTests = MockTests(0);

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            bool any = testRepository.Any();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            any.Should().BeFalse();
        }

        [Fact]
        public void ReturnsFalseGivenNoneEntityAsync()
        {
            List<Test> mockedTests = MockTests(0);

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryableAsync(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            bool any = testRepository.AnyAsync().GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            any.Should().BeFalse();
        }

        [Fact]
        public void ReturnsTrueGivenAnyActiveEntity()
        {
            List<Test> mockedTests = MockTests();
            mockedTests.First().Deactivate();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            ISpecification<Test> spec = new DirectSpecification<Test>(t => t.Active);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            bool any = testRepository.Any(spec);

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            any.Should().BeTrue();
        }

        [Fact]
        public void ReturnsTrueGivenAnyActiveEntityAsync()
        {
            List<Test> mockedTests = MockTests();
            mockedTests.First().Deactivate();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryableAsync(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            ISpecification<Test> spec = new DirectSpecification<Test>(t => t.Active);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            bool any = testRepository.AnyAsync(spec).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            any.Should().BeTrue();
        }

        [Fact]
        public void ReturnsFalseGivenNoneActiveEntity()
        {
            List<Test> mockedTests = MockTests(1);
            mockedTests.First().Deactivate();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            ISpecification<Test> spec = new DirectSpecification<Test>(t => t.Active);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            bool any = testRepository.Any(spec);

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            any.Should().BeFalse();
        }

        [Fact]
        public void ReturnsFalseGivenNoneActiveEntityAsync()
        {
            List<Test> mockedTests = MockTests(1);
            mockedTests.First().Deactivate();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryableAsync(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            ISpecification<Test> spec = new DirectSpecification<Test>(t => t.Active);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            bool any = testRepository.AnyAsync(spec).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            any.Should().BeFalse();
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullSpecification()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();

            Action act = () =>
            {
                ISpecification<Test> spec = null;
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                bool any = testRepository.Any(spec);
            };

            act.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("specification");
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullSpecificationAsync()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();

            Action act = () =>
            {
                ISpecification<Test> spec = null;
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                bool any = testRepository.AnyAsync(spec).GetAwaiter().GetResult();
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
