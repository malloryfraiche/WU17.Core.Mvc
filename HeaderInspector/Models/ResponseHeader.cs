using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeaderInspector.Models
{
    public class ResponseHeader
    {
        public string CacheControl { get; set; }
        public string ContentEncoding { get; set; }
        public string ContentType { get; set; }
        public DateTime Date { get; set; }
        public DateTime Expires { get; set; }
        public string Server { get; set; }
        public int Status { get; set; }
        public string StrictTransportSecurity { get; set; }
        public string Vary { get; set; }
        public string Via { get; set; }
        public string XAmzCfId { get; set; }
        public string XCache { get; set; }
        public string XCacheStatus { get; set; }
    }
}
