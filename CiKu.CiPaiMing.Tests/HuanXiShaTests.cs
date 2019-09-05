using CiKu.Domain;
using System;
using Xunit;

namespace CiKu.CiPaiMing.Tests
{
    public class HuanXiShaTests
    {
        [Fact]
        public void Test_Rules()
        {
            Assert.Equal(42, HuanXiSha.NumberOfZis);
            Assert.Equal(3, HuanXiSha.NumberOfJusOfShangPian);
            Assert.Equal(3, HuanXiSha.NumberOfJusOfXiaPian);
            Assert.Equal(7, HuanXiSha.NumberOfZisForEachJu);
        }

        [Theory]
        [InlineData(5)]        
        [InlineData(6)]
        [InlineData(8)]
        public void Test_Constructor(int numberOfZisForEachJu)
        {
            var jusOfShangPian = new Ju[HuanXiSha.NumberOfJusOfShangPian];
            for (int i = 0; i < jusOfShangPian.Length; i++)
                jusOfShangPian[i] = MockData.GetJu(numberOfZisForEachJu);

            var jusOfXiaPian = new Ju[HuanXiSha.NumberOfJusOfXiaPian];
            for (int i = 0; i < jusOfXiaPian.Length; i++)
                jusOfXiaPian[i] = MockData.GetJu(numberOfZisForEachJu);

            var shangPian = new Pian(jusOfXiaPian);
            var xiaPian = new Pian(jusOfXiaPian);

            var actual = Assert.Throws<Exception>(() => new HuanXiSha("", shangPian, xiaPian));

        }
    }
}