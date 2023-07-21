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
            //idye gerek yok
            Role role = new()
            {
                RoleName = "Admin"
            };
            Role role = new()
            {
                RoleName = "Admin"
            };

            User admin1 = new()
            {
                Email = "admin@noeva.com",
                City = "Çorum",
                Password = "123456",
                Phone = "5469389421"
            };
            _context.Users.Add(admin);







            _context.SaveChanges();

        }
    }
}
