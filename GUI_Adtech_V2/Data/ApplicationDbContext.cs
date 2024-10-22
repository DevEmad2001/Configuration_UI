using GUI_Adtech_V2.Models.Sys;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GUI_Adtech_V2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AdtechSystem> AdtechSystems { get; set; }
        public DbSet<AdtechConfig> AdtechConfigs { get; set; }
        public DbSet<AdtecComponent> AdtecComponents { get; set; }
    }
}
