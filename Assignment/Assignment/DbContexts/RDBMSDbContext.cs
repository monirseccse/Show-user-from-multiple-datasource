using Assignment.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Assignment.DbContexts
{
    public class RDBMSDbContext : DbContext
    {
        public RDBMSDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Contact)
                .WithOne()
                .HasForeignKey<User>(u => u.ContactId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany() 
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data for Contacts
            modelBuilder.Entity<Contact>().HasData(
                new Contact { Id = 1, Phone = "+41023658", Address = "Banani", City = "Dhaka", Country = "Bangladesh" },
                new Contact { Id = 2, Phone = "+15551234", Address = "123 Elm St", City = "Anytown", Country = "USA" },
                new Contact { Id = 3, Phone = "+447911123456", Address = "456 Oak Ave", City = "London", Country = "UK" },
                new Contact { Id = 4, Phone = "+61298765432", Address = "789 Pine Ln", City = "Sydney", Country = "Australia" },
                new Contact { Id = 5, Phone = "+34612345678", Address = "1011 Maple Dr", City = "Madrid", Country = "Spain" }
            );

            // Seed data for Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Developer" },
                new Role { Id = 2, Name = "Analyst" },
                new Role { Id = 3, Name = "Engineer" },
                new Role { Id = 4, Name = "Designer" },
                new Role { Id = 5, Name = "Manager" }
            );

            // Seed data for Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Shibli", LastName = "Arafat", Active = true, Company = "Wunderman Thompson", Sex = "M", ContactId = 1, RoleId = 5 },
                new User { Id = 2, FirstName = "John", LastName = "Doe", Active = true, Company = "Acme Corp", Sex = "M", ContactId = 2, RoleId = 1 },
                new User { Id = 3, FirstName = "Alice", LastName = "Johnson", Active = false, Company = "Beta Industries", Sex = "F", ContactId = 3, RoleId = 2 },
                new User { Id = 4, FirstName = "Bob", LastName = "Williams", Active = true, Company = "Gamma Solutions", Sex = "M", ContactId = 4, RoleId = 3 },
                new User { Id = 5, FirstName = "Eva", LastName = "Garcia", Active = true, Company = "Delta Group", Sex = "F", ContactId = 5, RoleId = 4 }
            );
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
