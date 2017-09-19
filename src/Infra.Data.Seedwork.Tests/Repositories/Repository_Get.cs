using Infra.Data.Seedwork.Tests.Extensions;
using Infra.Data.Seedwork.Tests.Repositories.Mock;
using Microsoft.EntityFrameworkCore;
using Moq;
using Ritter.Infra.Data.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Infra.Data.Seedwork.Tests.Repositories
{
    public class Repository_Get
    {
        //public TEntity Get(int id)
        //{
        //    return UnitOfWork.Set<TEntity>().FirstOrDefault(p => p.Id == id);
        //}

        [Fact]
        public void GetGivenIdReturnsAnEntity()
        {
            List<Test> tests = GetMockedTests();

            Mock<DbSet<Test>> mockDbSet = new Mock<DbSet<Test>>();
            Mock<IQueryableUnitOfWork> mockUnitOfWork = new Mock<IQueryableUnitOfWork>();

            mockDbSet.SetSource(tests);
            mockUnitOfWork.Setup(p => p.Set<Test>()).Returns(mockDbSet.Object);

            GenericTestRepository testRepository = new GenericTestRepository(mockUnitOfWork.Object);
            Test test = testRepository.Get(1);

            Assert.Equal(1, test.Id);
        }

        private static List<Test> GetMockedTests()
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
