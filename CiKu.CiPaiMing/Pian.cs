using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CiKu.Domain
{
    public class Pian
    {
        private string outputString;

        public Pian(Ju[] jus)
        {
            this.Jus = jus;
        }

        public Ju[] Jus { get; private set; }

        public int NumberOfJus { get { return this.Jus.Length; } }

        public string Description { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(outputString))
                outputString = string.Join(Environment.NewLine, Jus.Select(x => x.ToString()));

            return outputString;
        }
    }
}
