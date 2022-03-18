using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Hello
{
    public class PersonInfo
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }

        public override string ToString()
        {
            string report = $"[Name] = [{Name}],[Age] = [{Age}],[Sex] = [{Sex}]";
            return report;
        }

    }
    public class PersonInfoEven : PersonInfo
    {

    }
}
