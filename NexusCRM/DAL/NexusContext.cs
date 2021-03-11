using NexusCRM.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace NexusCRM.DAL
{
    public class NexusContext : DbContext
    {
        public NexusContext() : base("NexusContext")
        {
            
        }

        public DbSet<Companies> Companies { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<Opportunities> Opportunities { get; set; }
    }
}