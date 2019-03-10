using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

namespace ConcurrencyConflictInEFCore
{
    class PersonContext : DbContext
    {
        //public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        //{

        //}
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            //modelBuilder.Entity<Person>().Property(p => p.FirstName).IsConcurrencyToken();
            //modelBuilder.Entity<Person>().Property(p => p.FirstName).IsRowVersion();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
