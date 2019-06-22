using System;
using System.Collections.Generic;
using System.Text;

namespace CiKu.Domain
{
    public class Zi
    {
        public Zi(string jianti)
            : this(jianti, string.Empty, string.Empty)
        { }

        public Zi(string jianti, string fanti, string pinying)
        {
            this.JianTi = jianti;
            this.FanTi = fanti;
            this.PinYing = pinying;
        }

        public string JianTi { get; }

        public string FanTi { get; }

        public string PinYing { get; }
    }
}
