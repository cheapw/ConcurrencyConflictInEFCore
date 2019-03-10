﻿// <auto-generated />
using System;
using ConcurrencyConflictInEFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConcurrencyConflictInEFCore.Migrations
{
    [DbContext(typeof(PersonContext))]
    partial class PersonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConcurrencyConflictInEFCore.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasMaxLength(16);

                    b.Property<string>("Gender")
                        .HasMaxLength(6);

                    b.Property<string>("LastName")
                        .HasMaxLength(16);

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(12);

                    b.Property<byte[]>("RowVersion");

                    b.HasKey("PersonId");

                    b.ToTable("Person");
                });
#pragma warning restore 612, 618
        }
    }
}