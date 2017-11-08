using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sos2.Models
{
    public class Disaster
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public IList<Basic> Basic { get; set; }
        public Prep Prep { get; set; }
        public Aftermath Aftermath { get; set; }
    }
}
