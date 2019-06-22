using System;

namespace CiKu.Domain
{
    public class HuanXiSha : PianCi
    {
        public const int NumberOfZis = 42;
        public const int NumberOfJusOfShangPian = 3;
        public const int NumberOfJusOfXiaPian = 3;
        public const int NumberOfZisForEachJu = 7;
        public static readonly string[] BieMings_JianTi = { "浣沙溪" };
        public static readonly string[] BieMings_PinYing = { "HuanShaXi" };
        public const string Description = @"本唐代教坊曲名，因西施浣纱于若耶溪，故又名《浣溪沙》或《浣沙溪》。
上下片或上下阕三个七字句。四十二字。分平仄两体。平韵体流传至今。最早的是唐人韩偓词，是正体。上片或上阕三句全用韵，
下片或下阕末二句用韵。过片二句用对偶句的居多。仄韵体始于南唐李煜。另有《摊破浣溪沙》，又名《山花子》上下片各增三字，韵位不变。";

        public HuanXiSha(string name, Pian shangPian, Pian xiaPian)
            : base(name, "浣溪沙", shangPian, xiaPian)
        {
            if (shangPian == null)
                throw new ArgumentNullException(nameof(shangPian));
            if (xiaPian == null)
                throw new ArgumentNullException(nameof(xiaPian));

            if (this.ShangPian.NumberOfJus != NumberOfJusOfShangPian)
                throw new ArgumentException($"上片的句数不正确，上片的句数应为：{NumberOfJusOfShangPian}");

            if (this.XiaPian.NumberOfJus != NumberOfJusOfXiaPian)
                throw new ArgumentException($"下片的句数不正确，下片的句数应为：{NumberOfJusOfXiaPian}");

            int line = 1;
            foreach (var ju in shangPian.Jus)
            {
                if (ju.NumberOfZis != NumberOfZisForEachJu)
                    throw new Exception($"上片第{line}句的字数不正确，应为：{NumberOfZisForEachJu}");

                line++;
            }

            line = 1;
            foreach (var ju in xiaPian.Jus)
            {
                if (ju.NumberOfZis != NumberOfZisForEachJu)
                    throw new Exception($"下片第{line}句的字数不正确，应为：{NumberOfZisForEachJu}");

                line++;
            }

            this.ShangPian.Description = "上片或上阕三句全用韵";
            this.XiaPian.Description = "下片或下阕末二句用韵";
        }
    }
}
