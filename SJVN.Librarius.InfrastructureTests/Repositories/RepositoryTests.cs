using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SJVN.Librarius.Infrastructure.Repositories;
using SJVN.Librarius.Domain.Entities;
using SJVN.Librarius.Infrastructure;
using SJVN.Librarius.Infrastructure.DatabaseContext;
using Moq;
using System.Data.Entity;
using System.Linq;

namespace SJVN.Librarius.InfrastructureTests.Repositories
{
    [TestClass]
    public class RepositoryTests
    {
        public void PopulateFakeData(IDatabaseContext dbContext)
        {
            var entitySet = dbContext.Set<FakeEntity>();
            entitySet.Add(new FakeEntity { Name = "TheFirst" });
            entitySet.Add(new FakeEntity { Name = "TheSecond" });
            entitySet.Add(new FakeEntity { Name = "TheThird" });
            dbContext.SaveChanges();
        }

        [TestMethod]
        public void GetById_GetAnExistingEntity_ReturnAnEntity()
        {
            var dbContext = new FakeDatabaseContext(Effort.DbConnectionFactory.CreateTransient());
            PopulateFakeData(dbContext);

            var fakeRepository = new FakeRepository(dbContext);
            var existingEntity = fakeRepository.GetById(1);

            Assert.IsNotNull(existingEntity);
            Assert.AreEqual(1, existingEntity.Id);
            Assert.AreEqual("TheFirst", existingEntity.Name);
        }

        [TestMethod]
        public void Remove_AnExistingEntity_ReturnEntityRemoved()
        {
            var dbContext = new FakeDatabaseContext(Effort.DbConnectionFactory.CreateTransient());
            PopulateFakeData(dbContext);
            var fakeRepository = new FakeRepository(dbContext);

            var theSecondEntity = dbContext.Set<FakeEntity>().SingleOrDefault(x => x.Name == "TheSecond");
            fakeRepository.Remove(theSecondEntity);
            dbContext.SaveChanges();

            Assert.IsNull(dbContext.Set<FakeEntity>().SingleOrDefault(x => x.Name == "TheSecond"));
        }

        [TestMethod]
        public void GetAll_ReturnValidCollection()
        {
            var dbContext = new FakeDatabaseContext(Effort.DbConnectionFactory.CreateTransient());
            PopulateFakeData(dbContext);

            var fakeRepository = new FakeRepository(dbContext);
            dbContext.SaveChanges();

            Assert.AreEqual(3, fakeRepository.GetAll().Count());
        }

        public class FakeRepository : Repository<FakeEntity>
        {
            private readonly IDatabaseContext dbContext;
            public FakeRepository(IDatabaseContext dbContext)
                : base(dbContext)
            {
                this.dbContext = dbContext;
            }
        }

        #region Nested Classes
        public class FakeEntity : Entity
        {
            public string Name { get; set; }
        }

        public class FakeDatabaseContext : LibrariusDbContext
        {
            public FakeDatabaseContext(System.Data.Common.DbConnection dbConnection)
                : base(dbConnection)
            {
            }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<FakeEntity>();

                base.OnModelCreating(modelBuilder);
            }
        }
        #endregion
    }
}