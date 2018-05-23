using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Ritter.Domain;
using Ritter.Domain.Specifications;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Data.Tests.Extensions;
using Ritter.Infra.Data.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Ritter.Infra.Data.Tests.Repositories
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

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            ICollection<Test> tests = testRepository.Find();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNull().And.HaveSameCount(mockedTests);
        }

        [Fact]
        public void ReturnsEmpty()
        {
            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(Enumerable.Empty<Test>().ToList());

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
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

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            ICollection<Test> tests = testRepository.FindAsync().GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNull().And.HaveSameCount(mockedTests);
        }

        [Fact]
        public void ReturnsEmptyAsync()
        {
            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryableAsync(Enumerable.Empty<Test>().ToList());

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            ICollection<Test> tests = testRepository.FindAsync().GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void ReturnsAllEntitiesGivenSpecification()
        {
            List<Test> mockedTests = MockTests();
            mockedTests.Skip(1).Take(2).ForEach(t => t.Deactivate());

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            ISpecification<Test> spec = new DirectSpecification<Test>(t => t.Active);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            ICollection<Test> tests = testRepository.Find(spec);

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNullOrEmpty().And.OnlyContain(x => x.Active, "Any test is not active").And.HaveSameCount(mockedTests.Where(p => p.Active));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullSpecification()
        {
            List<Test> mockedTests = MockTests();
            mockedTests.Skip(1).Take(2).ForEach(t => t.Deactivate());

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            Action act = () =>
            {
                ISpecification<Test> spec = null;
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.Find(spec);
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("specification");
        }

        [Fact]
        public void ReturnsAllEntitiesGivenSpecificationAsync()
        {
            List<Test> mockedTests = MockTests();
            mockedTests.Skip(1).Take(2).ForEach(t => t.Deactivate());

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryableAsync(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            ISpecification<Test> spec = new DirectSpecification<Test>(t => t.Active);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            ICollection<Test> tests = testRepository.FindAsync(spec).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNullOrEmpty().And.OnlyContain(x => x.Active, "Any test is not active").And.HaveSameCount(mockedTests.Where(p => p.Active));
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenNullSpecificationAsync()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();

            Action act = () =>
            {
                ISpecification<Test> spec = null;
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.FindAsync(spec).GetAwaiter().GetResult();
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("specification");
        }

        [Fact]
        public void ReturnsEmptyGivenSpecification()
        {
            List<Test> mockedTests = MockTests();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            ISpecification<Test> spec = new DirectSpecification<Test>(t => t.Id == 6);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
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

            ISpecification<Test> spec = new DirectSpecification<Test>(t => t.Id == 6);

            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            ICollection<Test> tests = testRepository.FindAsync(spec).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void ReturnsFirstPageOrderedAscendingGivenPageSize10AndTotal100()
        {
            List<Test> mockedTests = MockTests(100);

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            IPagination pagination = new Pagination(0, 10);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            IPagedCollection<Test> tests = testRepository.Find(pagination);

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNull().And.HaveCount(10);
            tests.TotalCount.Should().Be(100);
            tests.PageCount.Should().Be(10);
            tests.First().Should().Be(mockedTests[0]);
            tests.Last().Should().Be(mockedTests[9]);
        }

        [Fact]
        public void ReturnsFirstPageOrderedDescendingGivenPageSize10AndTotal100()
        {
            List<Test> mockedTests = MockTests(100);

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            IPagination pagination = new Pagination(0, 10, "Id", false);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            IPagedCollection<Test> tests = testRepository.Find(pagination);

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNull().And.HaveCount(10);
            tests.TotalCount.Should().Be(100);
            tests.PageCount.Should().Be(10);
            tests.First().Should().Be(mockedTests[99]);
            tests.Last().Should().Be(mockedTests[90]);
        }

        [Fact]
        public void ReturnsFirstPageOrderedAscendingGivenPageSize10AndTotal100Async()
        {
            List<Test> mockedTests = MockTests(100);

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryableAsync(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            IPagination pagination = new Pagination(0, 10);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            IPagedCollection<Test> tests = testRepository.FindAsync(pagination).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNull().And.HaveCount(10);
            tests.TotalCount.Should().Be(100);
            tests.PageCount.Should().Be(10);
            tests.First().Should().Be(mockedTests[0]);
            tests.Last().Should().Be(mockedTests[9]);
        }

        [Fact]
        public void ReturnsFirstPageOrderedDescendingGivenPageSize10AndTotal100Async()
        {
            List<Test> mockedTests = MockTests(100);

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryableAsync(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            IPagination pagination = new Pagination(0, 10, "Id", false);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            IPagedCollection<Test> tests = testRepository.FindAsync(pagination).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNull().And.HaveCount(10);
            tests.TotalCount.Should().Be(100);
            tests.PageCount.Should().Be(10);
            tests.First().Should().Be(mockedTests[99]);
            tests.Last().Should().Be(mockedTests[90]);
        }

        [Fact]
        public void ReturnsSecondPageOrderedAscendingGivenPageSize10AndTotal100()
        {
            List<Test> mockedTests = MockTests(100);

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            IPagination pagination = new Pagination(1, 10);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            IPagedCollection<Test> tests = testRepository.Find(pagination);

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNull().And.HaveCount(10);
            tests.TotalCount.Should().Be(100);
            tests.PageCount.Should().Be(10);
            tests.First().Should().Be(mockedTests[10]);
            tests.Last().Should().Be(mockedTests[19]);
        }

        [Fact]
        public void ReturnsSecondPageOrderedDescendingGivenPageSize10AndTotal100()
        {
            List<Test> mockedTests = MockTests(100);

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            IPagination pagination = new Pagination(1, 10, "Id", false);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            IPagedCollection<Test> tests = testRepository.Find(pagination);

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNull().And.HaveCount(10);
            tests.TotalCount.Should().Be(100);
            tests.PageCount.Should().Be(10);
            tests.First().Should().Be(mockedTests[89]);
            tests.Last().Should().Be(mockedTests[80]);
        }

        [Fact]
        public void ReturnsSecondPageOrderedAscendingGivenPageSize10AndTotal100Async()
        {
            List<Test> mockedTests = MockTests(100);

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryableAsync(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            IPagination pagination = new Pagination(1, 10);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            IPagedCollection<Test> tests = testRepository.FindAsync(pagination).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNull().And.HaveCount(10);
            tests.TotalCount.Should().Be(100);
            tests.PageCount.Should().Be(10);
            tests.First().Should().Be(mockedTests[10]);
            tests.Last().Should().Be(mockedTests[19]);
        }

        [Fact]
        public void ReturnsSecondPageOrderedDescendingGivenPageSize10AndTotal100Async()
        {
            List<Test> mockedTests = MockTests(100);

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryableAsync(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            IPagination pagination = new Pagination(1, 10, "Id", false);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            IPagedCollection<Test> tests = testRepository.FindAsync(pagination).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNull().And.HaveCount(10);
            tests.TotalCount.Should().Be(100);
            tests.PageCount.Should().Be(10);
            tests.First().Should().Be(mockedTests[89]);
            tests.Last().Should().Be(mockedTests[80]);
        }

        [Fact]
        public void ReturnsFirstPageOrderedAscendingGivenPageSize10AndTotal9()
        {
            List<Test> mockedTests = MockTests(9);

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            IPagination pagination = new Pagination(0, 10);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            IPagedCollection<Test> tests = testRepository.Find(pagination);

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNull().And.HaveCount(9);
            tests.TotalCount.Should().Be(9);
            tests.PageCount.Should().Be(1);
            tests.First().Should().Be(mockedTests[0]);
            tests.Last().Should().Be(mockedTests[8]);
        }

        [Fact]
        public void ReturnsFirstPageOrderedAscendingGivenPageSize10AndTotal9Async()
        {
            List<Test> mockedTests = MockTests(9);

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryableAsync(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            IPagination pagination = new Pagination(0, 10);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            IPagedCollection<Test> tests = testRepository.FindAsync(pagination).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNull().And.HaveCount(9);
            tests.TotalCount.Should().Be(9);
            tests.PageCount.Should().Be(1);
            tests.First().Should().Be(mockedTests[0]);
            tests.Last().Should().Be(mockedTests[8]);
        }

        [Fact]
        public void ReturnsFirstPageOrderedDescendingGivenPageSize10AndTotal9()
        {
            List<Test> mockedTests = MockTests(9);

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            IPagination pagination = new Pagination(0, 10, "Id", false);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            IPagedCollection<Test> tests = testRepository.Find(pagination);

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNull().And.HaveCount(9);
            tests.TotalCount.Should().Be(9);
            tests.PageCount.Should().Be(1);
            tests.First().Should().Be(mockedTests[8]);
            tests.Last().Should().Be(mockedTests[0]);
        }

        [Fact]
        public void ReturnsFirstPageOrderedDescendingGivenPageSize10AndTotal9Async()
        {
            List<Test> mockedTests = MockTests(9);

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryableAsync(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            IPagination pagination = new Pagination(0, 10, "Id", false);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            IPagedCollection<Test> tests = testRepository.FindAsync(pagination).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNull().And.HaveCount(9);
            tests.TotalCount.Should().Be(9);
            tests.PageCount.Should().Be(1);
            tests.First().Should().Be(mockedTests[8]);
            tests.Last().Should().Be(mockedTests[0]);
        }

        [Fact]
        public void ReturnsFirstPageOrderedAscendingActivesGivenPageSize10AndTotal100()
        {
            List<Test> mockedTests = MockTests(100);
            mockedTests.First().Deactivate();
            mockedTests.Last().Deactivate();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            ISpecification<Test> spec = new DirectSpecification<Test>(t => t.Active);
            IPagination pagination = new Pagination(0, 10);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            IPagedCollection<Test> tests = testRepository.Find(spec, pagination);

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNullOrEmpty().And.OnlyContain(x => x.Active, "Any test is not active").And.HaveCount(10);
            tests.TotalCount.Should().Be(98);
            tests.PageCount.Should().Be(10);
            tests.First().Should().Be(mockedTests[1]);
            tests.Last().Should().Be(mockedTests[10]);
        }

        [Fact]
        public void GivenDefaultPageThenReturnsFirstPageOrderedAscendingActivesAndTotal100()
        {
            List<Test> mockedTests = MockTests(100);
            mockedTests.First().Deactivate();
            mockedTests.Last().Deactivate();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            ISpecification<Test> spec = new DirectSpecification<Test>(t => t.Active);
            IPagination pagination = new Pagination(-1, -1);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            IPagedCollection<Test> tests = testRepository.Find(spec, pagination);

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNullOrEmpty().And.OnlyContain(x => x.Active, "Any test is not active").And.HaveCount(10);
            tests.TotalCount.Should().Be(98);
            tests.PageCount.Should().Be(10);
            tests.First().Should().Be(mockedTests[1]);
            tests.Last().Should().Be(mockedTests[10]);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenSpecificationAndNullPagination()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();

            Action act = () =>
            {
                ISpecification<Test> spec = new DirectSpecification<Test>(t => t.Active);
                IPagination pagination = null;
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.Find(spec, pagination);
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("pagination");
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenSpecificationAndNullPaginationAsync()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();

            Action act = () =>
            {
                ISpecification<Test> spec = new DirectSpecification<Test>(t => t.Active);
                IPagination pagination = null;
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.FindAsync(spec, pagination).GetAwaiter().GetResult();
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("pagination");
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenPaginationAndNullSpecification()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();

            Action act = () =>
            {
                ISpecification<Test> spec = null;
                IPagination pagination = new Pagination(0, 10);
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.Find(spec, pagination);
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("specification");
        }

        [Fact]
        public void ThrowsArgumentNullExceptionGivenPaginationAndNullSpecificationAsync()
        {
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();

            Action act = () =>
            {
                ISpecification<Test> spec = null;
                IPagination pagination = new Pagination(0, 10);
                IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
                testRepository.FindAsync(spec, pagination).GetAwaiter().GetResult();
            };

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("specification");
        }

        [Fact]
        public void ReturnsFirstPageOrderedAscendingActivesGivenPageSize10AndTotal100Async()
        {
            List<Test> mockedTests = MockTests(100);
            mockedTests.First().Deactivate();
            mockedTests.Last().Deactivate();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryableAsync(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            ISpecification<Test> spec = new DirectSpecification<Test>(t => t.Active);
            IPagination pagination = new Pagination(0, 10);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            IPagedCollection<Test> tests = testRepository.FindAsync(spec, pagination).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNullOrEmpty().And.OnlyContain(x => x.Active, "Any test is not active").And.HaveCount(10);
            tests.TotalCount.Should().Be(98);
            tests.PageCount.Should().Be(10);
            tests.First().Should().Be(mockedTests[1]);
            tests.Last().Should().Be(mockedTests[10]);
        }

        [Fact]
        public void ReturnsFirstPageOrderedDescendingActivesGivenPageSize10AndTotal100()
        {
            List<Test> mockedTests = MockTests(100);
            mockedTests.First().Deactivate();
            mockedTests.Last().Deactivate();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            ISpecification<Test> spec = new DirectSpecification<Test>(t => t.Active);
            IPagination pagination = new Pagination(0, 10, "Id", false);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            IPagedCollection<Test> tests = testRepository.Find(spec, pagination);

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNullOrEmpty().And.OnlyContain(x => x.Active, "Any test is not active").And.HaveCount(10);
            tests.TotalCount.Should().Be(98);
            tests.PageCount.Should().Be(10);
            tests.First().Should().Be(mockedTests[98]);
            tests.Last().Should().Be(mockedTests[89]);
        }

        [Fact]
        public void ReturnsFirstPageOrderedDescendingActivesGivenPageSize10AndTotal100Async()
        {
            List<Test> mockedTests = MockTests(100);
            mockedTests.First().Deactivate();
            mockedTests.Last().Deactivate();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryableAsync(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            ISpecification<Test> spec = new DirectSpecification<Test>(t => t.Active);
            IPagination pagination = new Pagination(0, 10, "Id", false);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            IPagedCollection<Test> tests = testRepository.FindAsync(spec, pagination).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNullOrEmpty().And.OnlyContain(x => x.Active, "Any test is not active").And.HaveCount(10);
            tests.TotalCount.Should().Be(98);
            tests.PageCount.Should().Be(10);
            tests.First().Should().Be(mockedTests[98]);
            tests.Last().Should().Be(mockedTests[89]);
        }

        [Fact]
        public void ReturnsLastPageOrderedAscendingActivesGivenPageSize10AndTotal100()
        {
            List<Test> mockedTests = MockTests(100);
            mockedTests.First().Deactivate();
            mockedTests.Last().Deactivate();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryable(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            ISpecification<Test> spec = new DirectSpecification<Test>(t => t.Active);
            IPagination pagination = new Pagination(9, 10);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            IPagedCollection<Test> tests = testRepository.Find(spec, pagination);

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNullOrEmpty().And.OnlyContain(x => x.Active, "Any test is not active").And.HaveCount(8);
            tests.TotalCount.Should().Be(98);
            tests.PageCount.Should().Be(10);
            tests.First().Should().Be(mockedTests[91]);
            tests.Last().Should().Be(mockedTests[98]);
        }

        [Fact]
        public void ReturnsLastPageOrderedAscendingActivesGivenPageSize10AndTotal100Async()
        {
            List<Test> mockedTests = MockTests(100);
            mockedTests.First().Deactivate();
            mockedTests.Last().Deactivate();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            mockDbSet.SetupAsQueryableAsync(mockedTests);

            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            ISpecification<Test> spec = new DirectSpecification<Test>(t => t.Active);
            IPagination pagination = new Pagination(9, 10);
            IRepository<Test> testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            IPagedCollection<Test> tests = testRepository.FindAsync(spec, pagination).GetAwaiter().GetResult();

            mockUnitOfWork.Verify(x => x.Set<Test>(), Times.Once);
            tests.Should().NotBeNullOrEmpty().And.OnlyContain(x => x.Active, "Any test is not active").And.HaveCount(8);
            tests.TotalCount.Should().Be(98);
            tests.PageCount.Should().Be(10);
            tests.First().Should().Be(mockedTests[91]);
            tests.Last().Should().Be(mockedTests[98]);
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
