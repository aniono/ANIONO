using DesignPatterns.Creational;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DesignPatterns.Tests.Creational
{
    public class SingletonTests
    {
        [Fact]
        public void Create_Singleton_Test()
        {
            // Arrange
            var expected = Singleton.GetInstance;
            var size = 100;
            var instances = new Singleton[size];

            // Act
            Parallel.For(0, size, i =>
            {
                instances[i] = Singleton.GetInstance;
            });

            // Assert
            Assert.All(instances, actual => Assert.Same(expected, actual));
        }
    }
}
