using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection.Metadata;

namespace LogsTechnation.Model
{
    public class LogContext : DbContext
    {
        public virtual DbSet<LogAgora> LogsAgora { get; set; }
        public virtual DbSet<LogMinhaCdn> LogsMinhaCdn { get; set; }
        public virtual DbSet<LogAgoraAntes> LogsAgoraAntes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        }
    }
}
