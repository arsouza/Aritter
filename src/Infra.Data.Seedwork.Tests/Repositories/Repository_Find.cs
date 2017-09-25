using FluentAssertions;
using Infra.Data.Seedwork.Tests.Extensions;
using Infra.Data.Seedwork.Tests.Mocks;
using Microsoft.EntityFrameworkCore;
using Moq;
using Ritter.Domain.Seedwork.Specifications;
using Ritter.Infra.Data.Seedwork;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Infra.Data.Seedwork.Tests.Repositories
{
    public class Repository_Find
    {
        [Fact]
        public void ReturnsAllEntities()
        {
            List<Test> mockedTests = MockTests();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            GenericTestRepository testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            ICollection<Test> tests = testRepository.Find();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNull().And.HaveSameCount(mockedTests);
        }

        [Fact]
        public void ReturnsEmpty()
        {
            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(Enumerable.Empty<Test>());

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            GenericTestRepository testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            ICollection<Test> tests = testRepository.Find();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void ReturnsAllEntitiesAsync()
        {
            List<Test> mockedTests = MockTests();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryableAsync(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            GenericTestRepository testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            ICollection<Test> tests = testRepository.FindAsync().GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNull().And.HaveSameCount(mockedTests);
        }

        [Fact]
        public void ReturnsEmptyAsync()
        {
            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryableAsync(Enumerable.Empty<Test>());

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            GenericTestRepository testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            ICollection<Test> tests = testRepository.FindAsync().GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void ReturnsAllEntitiesGivenSpecification()
        {
            List<Test> mockedTests = MockTests();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            Specification<Test> spec = new DirectSpecification<Test>(t => t.Active);
            GenericTestRepository testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            ICollection<Test> tests = testRepository.Find(spec);

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNullOrEmpty().And.OnlyContain(x => x.Active, "Any testis not active").And.HaveSameCount(mockedTests.Where(p => p.Active));
        }

        [Fact]
        public void ReturnsAllEntitiesGivenSpecificationAsync()
        {
            List<Test> mockedTests = MockTests();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryableAsync(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            Specification<Test> spec = new DirectSpecification<Test>(t => t.Active);
            GenericTestRepository testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            ICollection<Test> tests = testRepository.FindAsync(spec).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNullOrEmpty().And.OnlyContain(x => x.Active, "Any test is not active").And.HaveSameCount(mockedTests.Where(p => p.Active));
        }

        [Fact]
        public void ReturnsEmptyGivenSpecification()
        {
            List<Test> mockedTests = MockTests();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            Specification<Test> spec = new DirectSpecification<Test>(t => t.Id == 6);
            GenericTestRepository testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            ICollection<Test> tests = testRepository.Find(spec);

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void ReturnsEmptyGivenSpecificationAsync()
        {
            List<Test> mockedTests = MockTests();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryableAsync(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            Specification<Test> spec = new DirectSpecification<Test>(t => t.Id == 6);

            GenericTestRepository testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            ICollection<Test> tests = testRepository.FindAsync(spec).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNull().And.BeEmpty();
        }

        private static List<Test> MockTests()
        {
            return new List<Test>
            {
                new Test(1, true),
                new Test(2, false),
                new Test(3, true),
                new Test(4, false),
                new Test(5, true)
            };
        }
    }
}
