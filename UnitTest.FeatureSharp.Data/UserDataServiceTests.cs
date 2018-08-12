
using FeatureSharp.Data;
using FeatureSharp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTest.FeatureSharp.Data
{
    [TestClass]
    public class UserDataServiceTests : DataServiceTestsBase
    {
        [TestMethod]
        public void Test_Add_User()
        {
            try
            { 
                using (var context = new FeatureSharpDbContext(_options))
                {
                    context.Database.EnsureCreated();
                }

                using (var context = new FeatureSharpDbContext(_options))
                {
                    var service = new UserDataService(context);
                    var user = new User
                    {
                        ID = Guid.NewGuid(),
                        FirstName = "Will",
                        LastName = "Li",
                        Email = "will.li@aniono.com",
                        Inactive = false
                    };

                    service.Add(user);
                }

                using (var context = new FeatureSharpDbContext(_options))
                {
                    Assert.AreEqual(1, context.Users.Count());
                    Assert.AreEqual("will.li@aniono.com", context.Users.Single().Email);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Get_User()
        {

        }
    }
}
