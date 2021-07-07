using Microsoft.EntityFrameworkCore;
using System;

namespace DateTimeManagement.Infra
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Operation> MonEntittyWithIANADateTimes => Set<Operation>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DateTimeManagement;Integrated Security=True;", options => options.UseNodaTime());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Operation>().OwnsOne(i => i.BilingDate);
            modelBuilder.Entity<Operation>().OwnsOne(i => i.DueDate);
        }
    }
}
