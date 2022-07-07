using Microsoft.EntityFrameworkCore;
using TesteVector.Domain.Models.Entities;

namespace TesteVector.Infra.Data.Context
{
    public partial class TesteVectorContext : DbContext
    {
        public TesteVectorContext(DbContextOptions<TesteVectorContext> options) : base(options)
        {
        }

        public DbSet<AccessHistory> AccessHistories { get; set; }
        public DbSet<Email> Emails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessHistory>().ToTable("AccessHistory");
            modelBuilder.Entity<Email>().ToTable("Email");
        }
    }
}
