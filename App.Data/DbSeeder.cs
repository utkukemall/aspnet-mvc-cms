using App.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class DbSeeder : AppDbContext
    {
        private readonly AppDbContext _context;

        public DbSeeder(AppDbContext context)
        {
            _context = context;
        }

        public static void Seed(AppDbContext _context)
        {
            User admin = new()
            {
                Email = "admin@noeva.com",
                City = "Çorum",
                Id = 1,
                Password = "123456",
                Phone = "5469389421"
            };

            _context.Users.Add(admin);
           
        }
    }
}
