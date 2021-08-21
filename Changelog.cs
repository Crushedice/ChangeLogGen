using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeLogGen
{
    public class Version
    {
        public string tag { get; set; }
        public string date { get; set; }
        public List<string> changes { get; set; }

        public Version(string v, string d, List<string>c)
        {
            tag = v;
            date = d;   
            changes = c;
        }
    }

    public class Changelog
    {
        public List<Version> versions { get; set; }
    }
}
