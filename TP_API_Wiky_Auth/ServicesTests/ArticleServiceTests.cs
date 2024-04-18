using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Exceptions;
using Services;
using ServicesTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Tests
{
    [TestClass()]
    public class ArticleServiceTests
    {
        [TestMethod()]
        public async Task DeleteArticleAsyncTestUserId()
        {
            var mock = new MockArticleService();

            //Arrange
            var articleId = 1;
            var userId = "10";
            bool isAdmin = false;

            //Act
            bool result = await mock.DeleteArticleAsync(articleId, userId, isAdmin);

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public async Task DeleteArticleAsyncTestIsAdmin()
        {
            var mock = new MockArticleService();

            //Arrange
            var articleId = 1;
            var userId = "15";
            bool isAdmin = true;

            //Act
            bool result = await mock.DeleteArticleAsync(articleId, userId, isAdmin);

            Assert.IsTrue(result);
        }

        [TestMethod()]
        [ExpectedException(typeof(MyExceptions))]
        public async Task DeleteArticleAsyncTestIsNotAdminAndIsNotAuthor()
        {
            var mock = new MockArticleService();

            //Arrange
            var articleId = 1;
            var userId = "15";
            bool isAdmin = false;

            //Act
            await mock.DeleteArticleAsync(articleId, userId, isAdmin);

           
        }
    }
}