using FeatureSharp.Data;
using FeatureSharp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace UnitTest.FeatureSharp.Data
{
    [TestClass]
    public class PaginationTests
    {
        private IEnumerable<User> users;

        [TestInitialize]
        public void TestClassInit()
        {
            users = new List<User>
            {
                new User { ID = new Guid("501d5b87-1260-44bf-998d-942212e9020b"), FirstName = "Kobe", LastName = "Bryant"},
                new User { ID = new Guid("401d5b87-1260-44bf-998d-942212e9020b"), FirstName = "Kevin", LastName = "Durant"},
                new User { ID = new Guid("301d5b87-1260-44bf-998d-942212e9020b"), FirstName = "West", LastName = "Brooks"},
                new User { ID = new Guid("201d5b87-1260-44bf-998d-942212e9020b"), FirstName = "Stepen", LastName = "Curry"},
                new User { ID = new Guid("101d5b87-1260-44bf-998d-942212e9020b"), FirstName = "Paul", LastName = "Gasoul"}
            };
        }

        [TestMethod]
        public void Test_Paging()
        {
            int pageIndexZero = 0;
            int pageIndexOne = 1;
            int pageIndexTwo = 2;
            int pageSize = 2;

            Page<User> page = new Page<User>(pageIndexZero, pageSize);
            Pagination<User> pagination = new Pagination<User>(page, users);
            var firstPage = pagination.Current;

            Assert.AreEqual(pageIndexZero, page.Index);
            Assert.AreEqual(pageSize, page.Size);
            Assert.AreEqual(users.Count(), page.Total);

            var secondPage = pagination.Next;
            Assert.AreEqual(pageIndexOne, secondPage.Index);
            Assert.AreEqual(pageSize, page.Size);
            Assert.AreEqual(users.Count(), page.Total);

            var thirdPage = pagination.Last;
            Assert.AreEqual(pageIndexTwo, thirdPage.Index);
            Assert.AreEqual(1, thirdPage.Size);
            Assert.AreEqual(users.Count(), page.Total);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Should throw ArgumentNullException")]
        public void Test_Paging_With_Null_Argument_page()
        {
            Pagination<User> pagination = new Pagination<User>(null, users);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Should throw ArgumentNullException")]
        public void Test_Paging_With_Null_Argument_items()
        {
            Pagination<User> pagination = new Pagination<User>(new Page<User>(), null);
        }

        [TestMethod]
        public void Test_Enumerable()
        {
            int pageIndex = 0;
            int pageSize = 2;
            Page<User> page = new Page<User>(pageIndex, pageSize);
            Pagination<User> pagination = new Pagination<User>(page, users);

            var expectedPages = new List<Page<User>>(3)
            {
                pagination.Current,
                pagination.Next,
                pagination.Last
            };

            var actualPages = new List<Page<User>>(3);

            foreach (var p in pagination)
            {
                actualPages.Add(p);
            }

            for (int i = 0; i < expectedPages.Count; i++)
            {
                for (int j = 0; j < expectedPages[i].Items.Count(); j++)
                {
                    Assert.AreEqual(
                        expectedPages[i].Items.ElementAt(j).ID
                        , actualPages[i].Items.ElementAt(j).ID);
                }
            }
        }
    }
}
