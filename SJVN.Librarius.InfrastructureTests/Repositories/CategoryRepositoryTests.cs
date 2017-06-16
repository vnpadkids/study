using Effort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SJVN.Librarius.Domain.Entities;
using SJVN.Librarius.Domain.Repositories;
using SJVN.Librarius.Infrastructure;
using SJVN.Librarius.Infrastructure.DatabaseContext;
using SJVN.Librarius.Infrastructure.Repositories;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace SJVN.Librarius.InfrastructureTests.Repositories
{
    [TestClass()]
    public class CategoryRepositoryTests
    {
        [TestMethod()]
        public void GetAll_WhenProvideCollectionWithItems_ReturnValidCollection()
        {
            IDatabaseContext dbContext = new LibrariusDbContext(DbConnectionFactory.CreateTransient());
            ICategoryRepository categoryRepos = PopulateFakeCategories(dbContext);

            var cats = categoryRepos.GetAll().ToArray();
            Assert.AreEqual(3, cats.Length);
            Assert.AreEqual("1", cats[0].Name);
            Assert.AreEqual("2", cats[1].Name);
            Assert.AreEqual("3", cats[2].Name);
        }

        [TestMethod()]
        public void Add_WhenProvideValidEntity_ReturnValidCollection()
        {
            IDatabaseContext dbContext = new LibrariusDbContext(DbConnectionFactory.CreateTransient());
            ICategoryRepository categoryRepos = PopulateFakeCategories(dbContext);
            categoryRepos.Add(new Domain.Entities.Category { Name = "newcat", DDC = "NC1" });
            dbContext.SaveChanges();

            Assert.AreEqual(4, categoryRepos.GetAll().Count());
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateException))]
        public void Add_WhenEntityDDCIsDuplicated_ReturnDbUpdateException()
        {
            IDatabaseContext dbContext = new LibrariusDbContext(DbConnectionFactory.CreateTransient());
            ICategoryRepository categoryRepos = PopulateFakeCategories(dbContext);
            categoryRepos.Add(new Domain.Entities.Category { Name = "new-cat-code", DDC = "D01" });
            dbContext.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void Add_WhenNameIsEmpty_ReturnDbEntityValidationException()
        {
            IDatabaseContext dbContext = new LibrariusDbContext(DbConnectionFactory.CreateTransient());
            ICategoryRepository categoryRepos = PopulateFakeCategories(dbContext);
            categoryRepos.Add(new Domain.Entities.Category { Name = string.Empty, DDC = "D04" });
            dbContext.SaveChanges();
        }

        [TestMethod()]
        public void Remove_WhenEntityIsExistedInDatabase_ReturnEntityRemoved()
        {
            IDatabaseContext dbContext = new LibrariusDbContext(DbConnectionFactory.CreateTransient());
            ICategoryRepository categoryRepos = PopulateFakeCategories(dbContext);

            var needToBeDelete = categoryRepos.GetById(1);
            Assert.IsNotNull(needToBeDelete);

            categoryRepos.Remove(needToBeDelete);
            dbContext.SaveChanges();

            var needToCheckEntity = categoryRepos.GetById(1);

            Assert.AreEqual(null, needToCheckEntity);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void Remove_WhenEntityIsNotExistedInDatabase_ReturnException()
        {
            IDatabaseContext dbContext = new LibrariusDbContext(DbConnectionFactory.CreateTransient());
            ICategoryRepository categoryRepos = PopulateFakeCategories(dbContext);

            var needToBeDelete = new Category { Name = "anonymous", DDC = "ANY", Id = 1 };
            Assert.IsNotNull(needToBeDelete);

            categoryRepos.Remove(needToBeDelete);
            dbContext.SaveChanges();
        }

        [TestMethod()]
        public void UpdateACategory()
        {
            IDatabaseContext dbContext = new LibrariusDbContext(DbConnectionFactory.CreateTransient());
            ICategoryRepository categoryRepos = PopulateFakeCategories(dbContext);

            var needToBeUpdatedEntity = categoryRepos.GetById(1);
            Assert.IsNotNull(needToBeUpdatedEntity);

            needToBeUpdatedEntity.Name = "update-cat-name";

            categoryRepos.Update(needToBeUpdatedEntity);
            dbContext.SaveChanges();

            var needToCheckEntity = categoryRepos.GetById(1);

            Assert.IsNotNull(needToCheckEntity);
            Assert.AreEqual("update-cat-name", needToCheckEntity.Name);
        }

        private static ICategoryRepository PopulateFakeCategories(IDatabaseContext dbContext)
        {
            dbContext.Categories.Add(new Domain.Entities.Category { Name = "1", DDC = "D01" });
            dbContext.Categories.Add(new Domain.Entities.Category { Name = "2", DDC = "D02" });
            dbContext.Categories.Add(new Domain.Entities.Category { Name = "3", DDC = "D03" });
            dbContext.SaveChanges();

            ICategoryRepository categoryRepos = new CategoryRepository(dbContext);
            return categoryRepos;
        }
    }
}