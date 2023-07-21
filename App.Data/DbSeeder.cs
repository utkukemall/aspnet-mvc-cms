﻿using App.Data.Entity;
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

            Role role = new()
            {
                RoleName = "Admin"
            };

            User admin = new()
            {
                Email = "admin@noeva.com",
                RoleId = 1,
                City = "Çorum",
                Password = "123456",
                Phone = "5469389421"
            };
            // Hiçbirine Id gelmeyecek.
            // User dr

            // Daha fazla entity eklenmesi gerek.


            // Dummy'Ler eklenecek
            _context.Users.Add(admin);







            _context.SaveChanges();

        }
    }
}
