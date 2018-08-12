using FeatureSharp.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.FeatureSharp.Data
{
    [TestClass]
    public abstract class DataServiceTestsBase
    {
        protected static SqliteConnection _connection;
        protected static DbContextOptions<FeatureSharpDbContext> _options;
        public TestContext TestContext { get; set; }

        static DataServiceTestsBase()
        {
            Console.WriteLine(nameof(DataServiceTestsBase));

            _connection = new SqliteConnection("DataSource=:memory:");
            _options = new DbContextOptionsBuilder<FeatureSharpDbContext>()
                .UseSqlite(_connection)
                .Options;
        }

        [TestInitialize]
        public void BaseTestInit()
        {
            Console.WriteLine(nameof(DataServiceTestsBase.BaseTestInit));
            TestContext.WriteLine(TestContext.TestName);

            _connection.Open();
        }

        [TestCleanup]
        public void BaseTestCleanup()
        {
            Console.WriteLine(nameof(DataServiceTestsBase.BaseTestCleanup));
            TestContext.WriteLine(TestContext.TestName);

            _connection.Close();
        }
    }
}
