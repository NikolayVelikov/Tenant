using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public static class Extention
    {
        public static void Seed(this ModelBuilder builder)
        {
            var users = new List<User>
            {
                new User
                {
                    Id = 1.ToString(),
                    TenantId = 1.ToString(),
                    FirstName = "Niki",
                    Email = "niki@yahoo.com",
                    Password = "123!"
                },
                new User
                {
                    Id = 2.ToString(),
                    TenantId = 2.ToString(),
                    FirstName = "Medi",
                    Email = "medi@yahoo.com",
                    Password = "1234!"
                },
            };

            var products = new List<Product>
            {
                new Product
                {
                    Id = 1.ToString(),
                    TenantId = 1.ToString(),
                    Name  = "Banani",
                    Price = 12.5m,
                    UserId = 1.ToString()
                },
                new Product
                {
                    Id = 2.ToString(),
                    TenantId = 1.ToString(),
                    Name  = "Krushi",
                    Price = 13.5m,
                    UserId = 1.ToString(),
                },
                new Product
                {
                    Id = 3.ToString(),
                    TenantId = 2.ToString(),
                    Name  = "Domati",
                    Price = 12.5m,
                    UserId = 2.ToString(),
                },
                new Product
                {
                    Id = 4.ToString(),
                    TenantId = 2.ToString(),
                    Name  = "Likanka",
                    Price = 10.5m,
                    UserId = 2.ToString(),
                }
            };

            builder.Entity<User>().HasData(users);
            builder.Entity<Product>().HasData(products);
        }
    }
}