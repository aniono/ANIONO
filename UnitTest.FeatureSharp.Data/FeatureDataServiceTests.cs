using FeatureSharp.Data;
using FeatureSharp.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTest.FeatureSharp.Data
{
    [TestClass]
    public class FeatureDataServiceTests : DataServiceTestsBase
    {
        [TestMethod]
        public void Test_Add_Feature()
        {
            Console.WriteLine(nameof(FeatureDataServiceTests.Test_Add_Feature));
            TestContext.WriteLine(TestContext.TestName);

            try
            {
                using (var context = new FeatureSharpDbContext(_options))
                {
                    context.Database.EnsureCreated();
                }

                Feature feature = null;
                using (var context = new FeatureSharpDbContext(_options))
                {
                    User user = new User
                    {
                        ID = Guid.NewGuid(),
                        FirstName = "Will" + DateTime.Now.ToString("yyyyMMdd hh:mm:ss"),
                        LastName = "Li",
                        Email = "will.li@aniono.com",
                        Inactive = false
                    };

                    feature = new Feature
                    {
                        ID = Guid.NewGuid(),
                        Name = "Feature" + DateTime.Now.ToString("yyyyMMdd hh:mm:ss"),
                        AuthorId = user.ID,
                        Description = "For testing only, created by:" + nameof(FeatureDataServiceTests.Test_Add_Feature),
                        Enabled = true
                    };

                    context.Users.Add(user);
                    context.SaveChanges();

                    FeatureDataService featureDataService = new FeatureDataService(context);
                    featureDataService.Add(feature);
                }

                using (var context = new FeatureSharpDbContext(_options))
                {
                    Assert.AreEqual(1, context.Features.Count());
                    Assert.AreEqual(feature.Name, context.Features.Single().Name);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
