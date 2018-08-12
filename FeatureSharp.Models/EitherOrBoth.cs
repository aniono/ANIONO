using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureSharp.Models
{
    public class EitherOrBoth
    {
        public EitherOrBoth() : this(true, false, false)
        { }

        public EitherOrBoth(bool yes, bool no, bool both)
        {
            Yes = yes;
            No = no;
            Both = both;
        }

        public bool Yes { get; set; }
        public bool No { get; set; }
        public bool Both { get; set; }
        public bool Value
        {
            get
            {
                return Match(this);
            }
        }

        public static bool Match(EitherOrBoth status)
        {
            if (status.Both)
                return true;
            else if (status.Yes)
                return true;
            else
                return false;
        }
    }
}
