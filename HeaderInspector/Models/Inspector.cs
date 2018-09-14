using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeaderInspector.Models
{
    public class Inspector
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string ExcludedHeaders { get; set; }
    }
}
