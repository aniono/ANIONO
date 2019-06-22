using System;
using System.Collections.Generic;
using System.Text;

namespace CiKu.CiPaiMing.Tests
{
    public class MockData
    {
        private static readonly Random random = new Random();

        public static Ju GetJu(int numberOfZis)
        {
            var zis = GetZis(numberOfZis);

            var ju = new Ju(zis);

            return ju;
        }

        public static Zi[] GetZis(int numberOfZis)
        {
            var zis = new Zi[numberOfZis];
            for (int i = 0; i < numberOfZis; i++)
            {
                int k = random.Next(1, Hanzi.StartWith_B.Count);
                zis[i] = new Zi(Hanzi.StartWith_B[k]);
            }

            return zis;
        }

        public static HuanXiSha GetHuanXiSha()
        {
            var jusOfShangPian = new Ju[HuanXiSha.NumberOfJusOfShangPian];
            for (int i = 0; i < jusOfShangPian.Length; i++)
                jusOfShangPian[i] = MockData.GetJu(HuanXiSha.NumberOfZisForEachJu);

            var jusOfXiaPian = new Ju[HuanXiSha.NumberOfJusOfXiaPian];
            for (int i = 0; i < jusOfXiaPian.Length; i++)
                jusOfXiaPian[i] = MockData.GetJu(HuanXiSha.NumberOfZisForEachJu);

            var shangPian = new Pian(jusOfShangPian);
            var xiaPian = new Pian(jusOfXiaPian);
            var hxs = new HuanXiSha(shangPian, xiaPian);

            return hxs;
        }
    }
}
