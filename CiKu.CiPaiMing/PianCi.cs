using System;
using System.Collections.Generic;
using System.Text;

namespace CiKu.Domain
{
    public abstract class PianCi : Ci
    {
        protected PianCi(string name, string ciPaiMing, Pian shangPian, Pian xiaPian)
            : base(name, ciPaiMing)
        {
            this.ShangPian = shangPian;
            this.XiaPian = xiaPian;
        }

        public Pian ShangPian { get; private set; }

        public Pian XiaPian { get; private set; }

        public override string ToString() =>
            ShangPian.ToString() +
            Environment.NewLine +
            Environment.NewLine +
            XiaPian.ToString();
    }
}
