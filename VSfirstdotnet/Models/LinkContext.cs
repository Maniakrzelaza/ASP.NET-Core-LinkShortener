using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace VSfirstdotnet.Models
{
    public class LinkContext : DbContext
    {
        
        public LinkContext(DbContextOptions<LinkContext> options): base(options)
        {
        }
        public DbSet<Link> links { get; set; }
    }
}
