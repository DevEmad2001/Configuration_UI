using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GUI_Adtech.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AdtechSystem> Systems { get; set; }
        public DbSet<AdtechComponent> Components { get; set; }
        public DbSet<AdtechConfig> Configs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
