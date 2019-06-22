using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CiKu.Domain
{
    public class Ju
    {
        private string outputString;

        public Ju(Zi[] zis)
        {
            this.Zis = zis;
        }

        public Zi[] Zis { get; private set; }

        public int NumberOfZis { get { return this.Zis.Length; } }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(outputString))
                outputString = string.Join(string.Empty, Zis.Select(x => x.JianTi));

            return outputString;
        }
    }
}
