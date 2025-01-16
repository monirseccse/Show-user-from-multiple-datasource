using Assignment.DbContexts;
using Assignment.Model.Domain;
using MongoDB.Driver;
using System.Net.Sockets;

namespace Assignment.SeedData
{
    public class MongoDbSeeder
    {
        private readonly MongoDbContext _context;

        public MongoDbSeeder(MongoDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            var _usersCollection = _context.GetCollection<User>("Users");

            // Check if collection already has data
            if (await _usersCollection.CountDocumentsAsync(Builders<User>.Filter.Empty) > 0)
            {
                Console.WriteLine("Data already seeded. Skipping seeding process.");
                return;
            }


            var users = new List<User>
           {
            new User
            {
                Id = 1, FirstName = "Shibli", LastName = "Arafat", Active = true, Company = "Wunderman Thompson", Sex = "M",
                Contact = new Contact { Id = 1, Phone = "+41023658", Address = "Banani", City = "Dhaka", Country = "Bangladesh" },
                Role = new Role { Id = 5, Name = "Manager" }
            },
            new User
            {
                Id = 2, FirstName = "John", LastName = "Doe", Active = true, Company = "Acme Corp", Sex = "M",
                Contact = new Contact { Id = 2, Phone = "+15551234", Address = "123 Elm St", City = "Anytown", Country = "USA" },
                Role = new Role { Id = 1, Name = "Developer" }
            },
            new User
            {
                Id = 3, FirstName = "Alice", LastName = "Johnson", Active = false, Company = "Beta Industries", Sex = "F",
                Contact = new Contact { Id = 3, Phone = "+447911123456", Address = "456 Oak Ave", City = "London", Country = "UK" },
                Role = new Role { Id = 2, Name = "Analyst" }
            },
            new User
            {
                Id = 4, FirstName = "Bob", LastName = "Williams", Active = true, Company = "Gamma Solutions", Sex = "M",
                Contact = new Contact { Id = 4, Phone = "+61298765432", Address = "789 Pine Ln", City = "Sydney", Country = "Australia" },
                Role = new Role { Id = 3, Name = "Engineer" }
            },
            new User
            {
                Id = 5, FirstName = "Eva", LastName = "Garcia", Active = true, Company = "Delta Group", Sex = "F",
                Contact = new Contact { Id = 5, Phone = "+34612345678", Address = "1011 Maple Dr", City = "Madrid", Country = "Spain" },
                Role = new Role { Id = 4, Name = "Designer" }
            }
        };

            await _usersCollection.InsertManyAsync(users);
            Console.WriteLine("Data seeding completed.");
        }
    }
}
