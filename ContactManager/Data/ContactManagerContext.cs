//Kenny Hedlund
//Chapter 4 Contact 
//COP.4813

using Microsoft.EntityFrameworkCore;
using ContactManager.Models;
using System;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ContactManager.Data
{
    // Represents Entity Framework Core database context for ContactManager
    public class ContactManagerContext(DbContextOptions<ContactManagerContext> options) : DbContext(options)
    {
        // Represents the Contacts table in the database
        public DbSet<Contact> Contacts { get; set; }

        // Represents the Categories table in the database
        public DbSet<Category> Categories { get; set; }

        // Configures the database context
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Suppress the warning for pending model changes to avoid runtime errors
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        // Configures model and seeds initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Family" },
                new Category { CategoryId = 2, Name = "Friends" },
                new Category { CategoryId = 3, Name = "Work" }
            );

            // Seed data for Contacts
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    FirstName = "Will",
                    LastName = "Smith",
                    Phone = "123-456-7890",
                    Email = "BeverlyHillsPD@aol.com",
                    Organization = "BHPD",
                    CategoryId = 3,
                    DateAdded = DateTime.Now
                },
                new Contact
                {
                    ContactId = 2,
                    FirstName = "John",
                    LastName = "Ham",
                    Phone = "109-876-5432",
                    Email = "Hammy@outlook.com",
                    Organization = "SpookyTown",
                    CategoryId = 1,
                    DateAdded = DateTime.Now
                }
            );
        }
    }
}
