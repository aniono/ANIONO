using System;
using System.Collections.Generic;
using System.Text;

namespace CiKu.Domain
{
    public abstract class Ci
    {
        protected Ci(string name, string ciPaiMing)
            : this(name, ciPaiMing, string.Empty, string.Empty)
        {

        }

        protected Ci(string name, string ciPaiMing, string author, string chaoDai)
        {
            this.Name = name;
            this.CiPaiMing = ciPaiMing;
            this.Author = author;
            this.ChaoDai = chaoDai;
        }

        public string Name { get; private set; }

        public string CiPaiMing { get; private set; }

        public string Author { get; private set; }

        public string ChaoDai { get; private set; }
    }
}
