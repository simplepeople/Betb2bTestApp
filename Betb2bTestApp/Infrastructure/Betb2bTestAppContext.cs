using System;
using Microsoft.EntityFrameworkCore;

namespace Betb2bTestApp.Infrastructure
{
    public sealed class Betb2bTestAppContext : DbContext
    {
        public DbSet<DbUser> Users { get; set; }

        public Betb2bTestAppContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=admin;database=betb2b;",
                new MySqlServerVersion(new Version(8, 0, 11))
            );
        }
    }

    public class DbUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
    }
}
