using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowsingTimeTracker.Models
{
    public class VisitedUrl
    {
        public long Id { get; set; }
        public string Url { get; set; }

        public long Time { get; set; }

        public string Title { get; set; }

        public string Favicon { get; set; }
    }
}
