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


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
            // Configure one-to-many relationship between AdtechSystem and AdtechComponent
            //modelBuilder.Entity<AdtechComponent>()
            //    .HasOne(c => c.System)
            //    .WithMany(s => s.Components)
            //    .HasForeignKey(c => c.SystemID);

            //// Configure one-to-many relationship between AdtechComponent and AdtechConfig
            //modelBuilder.Entity<AdtechConfig>()
            //    .HasOne(c => c.Component)
            //    .WithMany(c => c.Configs)
            //    .HasForeignKey(c => c.ComponentID);



            ////إدخال بيانات تجريبية 
            //modelBuilder.Entity<AdtechSystem>().HasData(
            //    new AdtechSystem { SystemID = 1, SystemName = "HES" },
            //    new AdtechSystem { SystemID = 2, SystemName = "GIS" },
            //    new AdtechSystem { SystemID = 3, SystemName = "SCADA" },
            //    new AdtechSystem { SystemID = 4, SystemName = "SINCAL" },
            //    new AdtechSystem { SystemID = 5, SystemName = "Core" }
            //);

            //modelBuilder.Entity<AdtechComponent>().HasData(
            //    new AdtechComponent { ComponentID = 1, ComponentName = "MeterInstallation", SystemID = 1 },
            //    new AdtechComponent { ComponentID = 2, ComponentName = "DailyReading", SystemID = 1 },
            //    new AdtechComponent { ComponentID = 3, ComponentName = "NetworkGISNode", SystemID = 2 }
            //);

            //modelBuilder.Entity<AdtechConfig>().HasData(
            //    new AdtechConfig { Seq_Id = 1, ParameterName = "ServiceURL", ParameterValue = "http://example.com", ModifiesDate = DateTime.Now, ComponentID = 1 },
            //    new AdtechConfig { Seq_Id = 2, ParameterName = "LogfilePath", ParameterValue = "C:/logs", ModifiesDate = DateTime.Now, ComponentID = 1 },
            //    new AdtechConfig { Seq_Id = 3, ParameterName = "ServiceURL", ParameterValue = "http://gis.example.com", ModifiesDate = DateTime.Now, ComponentID = 3 }
            //);


        //}

    }
}
