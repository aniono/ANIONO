using System;
using System.Collections.Generic;
using System.Text;

namespace CiKu.Domain
{
    public class ShuiDiaoGeTou : PianCi
    {
        public ShuiDiaoGeTou(string name, Pian shangPian, Pian xiaPian)
            : base(name, "水调歌头", shangPian, xiaPian)
        {
        }
    }
}
