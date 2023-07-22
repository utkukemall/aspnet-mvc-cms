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
            //Roles
            Role admin = new()
            {
                RoleName = "Admin"
            };
            _context.Roles.Add(admin);

            Role doctor = new()
            {
                RoleName = "Doctor"
            };
            _context.Roles.Add(doctor);

            Role user = new()
            {
                RoleName = "User"
            };
            _context.Roles.Add(user);
            _context.SaveChanges();
            //Users
            //User admin0 = new()
            //{
            //    Email = "admin0@noeva.com",  
            //    RoleId = 1 ,
            //    City = "Çorum",
            //    Password = "123456",
            //    Phone = "5469389421"
            //};
            //_context.Users.Add(admin0);

            //User admin1 = new()
            //{
            //    Email = "admin1@noeva.com",
            //    RoleId = 1 ,
            //    City = "Tekirdağ",
            //    Password = "123456",
            //    Phone = "54693894210"
            //};
            //_context.Users.Add(admin1);

            //User doctor2 = new()
            //{
            //    Email = "doctor2@noeva.com",
            //    RoleId = 2,
            //    City = "Izmir",
            //    Password = "123456",
            //    Phone = "54693894210"
            //};
            //_context.Users.Add(doctor2);

            //User doctor3 = new()
            //{
            //    Email = "doctor3@noeva.com",
            //    RoleId = 2,
            //    City = "Bursa",
            //    Password = "123456",
            //    Phone = "54693894210"
            //};
            //_context.Users.Add(doctor3);

            //User user4 = new()
            //{
            //    Email = "user4@noeva.com",
            //    RoleId = 3,
            //    City = "Ankara",
            //    Password = "123456",
            //    Phone = "54693894210"
            //};
            //_context.Users.Add(user4);

            //User user5 = new()
            //{
            //    Email = "user5@noeva.com",
            //    RoleId = 3,
            //    City = "Yalova",
            //    Password = "123456",
            //    Phone = "54693894210"
            //};
            //_context.Users.Add(user5);
            //_context.SaveChanges();
            //Departments
            Department dp = new()
            {
                Name = "Acil Servis",
                Description = "Acil Servis"
            };
            _context.Departments.Add(dp);

            Department dp1 = new()
            {
                Name = "Cildiye (Dermatoloji)",
                Description = "Cildiye"
            };
            _context.Departments.Add(dp1);

            Department dp2 = new()
            {
                Name = "İç Hastalıkları (Dahiliye)",
                Description = "İç Hastalıkları (Dahiliye)"
            };
            _context.Departments.Add(dp2);

            Department dp3 = new()
            {
                Name = "Kulak Burun Boğaz (KBB)",
                Description = "Kulak Burun Boğaz (KBB)"
            };
            _context.Departments.Add(dp3);

            Department dp4 = new()
            {
                Name = "Kadın Hastalıkları (Jinekoloji)",
                Description = "Kadın Hastalıkları (Jinekoloji)"
            };
            _context.Departments.Add(dp4);

            Department dp5 = new()
            {
                Name = "Kardiyoloji",
                Description = "Kardiyoloji"
            };
            _context.Departments.Add(dp5);

            Department dp6 = new()
            {
                Name = "Psikoloji",
                Description = "Psikoloji"
            };
            _context.Departments.Add(dp6);

            Department dp7 = new()
            {
                Name = "Radyoloji",
                Description = "Radyoloji"
            };
            _context.Departments.Add(dp7);
            _context.SaveChanges();

            PostImage image = new()
            {
                ImagePath="Image.png"
            };
            _context.PostImages.Add(image);

            PostImage image2 = new()
            {
                ImagePath = "Image2.png"
            };
            _context.PostImages.Add(image2);

            _context.SaveChanges();
            //Post
            Post post = new()
            {
                UserId = 1,//admin
                Title = "Ayarlar",
                Content = "Ayarlar",
                PostImageId = 2
            };
            _context.Posts.Add(post);

            Post post1 = new()
            {
                UserId = 3,//doctor
                Title = "Hastalıklar",
                 Content = "Hastalıklar",
                PostImageId = 1
            };
            _context.Posts.Add(post1);

            Post post2 = new()
            {
                UserId = 5,//user
                Title = "Hizmet",
                Content = "Hizmet",
                PostImageId= 1
                
            };
            _context.Posts.Add(post2);
            _context.SaveChanges();
            //DepartmenPost
            DepartmentPost dpPost = new() 
            {
                DepartmentId = 1, 
                PostId = 1,
            };
            _context.DepartmentPosts.Add(dpPost);

            DepartmentPost dpPost1 = new()
            {
                DepartmentId = 2,
                PostId = 2,
            };
            _context.DepartmentPosts.Add(dpPost1);

            DepartmentPost dpPost2 = new()
            {
                DepartmentId = 3,
                PostId = 3,
            };
            _context.DepartmentPosts.Add(dpPost2);
            _context.SaveChanges();
            //PostImage
            PostImage postImage = new()
            {
                
               ImagePath=""

            };
            _context.PostImages.Add(postImage);
            _context.SaveChanges();
            //Settings
            Setting settings = new()
            {
                UserId = 1,
                Name = "Role Ekleme",
                Value = "Role Ekleme",
            };
            _context.Settings.Add(settings);

            Setting settings1 = new()
            {
                UserId = 3,
                Name = "Hasta Ekleme",
                Value = "Hasta Ekleme",
            };
            _context.Settings.Add(settings1);

            Setting settings2 = new()
            {
                UserId = 5,
                Name = "Randevu İptali",
                Value = "Randevu İptali",
            };
            _context.Settings.Add(settings2);

            _context.SaveChanges();

            Doctor doctor1 = new()
            {
                City= "New York",
                Email = "miracle@noeva.com",
                Password="1234567",
                Phone = "5446508042",
                RoleId = 2,
                Specialty= "Neuroscience",
                
            };

            Patient patient = new()
            {
                // Doldurulacak
            };

        }
    }
}
