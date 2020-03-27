using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowsingTimeTracker.Models
{
    public class BrowsingTimeTrackerContext : DbContext
    {
        public BrowsingTimeTrackerContext(
            DbContextOptions<BrowsingTimeTrackerContext> options)
           : base(options)
        {
        }

        public DbSet<VisitedUrl> VisitedUrls { get; set; }
    }
}
