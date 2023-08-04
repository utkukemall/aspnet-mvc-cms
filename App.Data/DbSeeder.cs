using App.Data.Entity;
namespace App.Data
{
    public class DbSeeder
    {
        private readonly AppDbContext _context;

        public DbSeeder(AppDbContext context)
        {
            _context = context;
        }

        public static void Seed(AppDbContext context)
        {
            SeedDepartments(context);
           // SeedImages(context);
            SeedRoles(context);
            SeedDoctors(context);
            SeedPatients(context);
            SeedPosts(context);
            SeedPostComments(context);
            SeedSettings(context);
            SeedUsers(context);
            SeedPages(context);
            SeedDepartmentPosts(context);
        }


        private static void SeedDepartments(AppDbContext context)
        {
            for (int i = 1; i <= 10; i++)
            {
                var department = new Department
                {
                    Name = $"Kardiyoloji {i}",
                    Description = $"Description for Department {i}",
                    // Gerekli diğer özellikler doldur.
                };

                context.Departments.Add(department);
            }

            context.SaveChanges();
        }

        private static void SeedDoctors(AppDbContext context)
        {
            for (int i = 1; i <= 10; i++)
            {
                var doctor = new Doctors
                {
                    RoleId = i,
                  //  ImageId = i,
                    FullName = $"doctor FullName{i}",
                    City = $"City{i}",
                    Phone = $"123456789{i}",
                    Specialty = $"Specialty{i}",
                    Patients = SeedPatientsForDoctor(i),
                    Email = GenerateRandomEmail($"Doctors{i}", "Doctors.com"),
                    Password = "mysecretpassword",
                    DepartmentId = i
                };

                context.Doctors.Add(doctor);
            }

            context.SaveChanges();
        }

        private static List<Patient> SeedPatientsForDoctor(int doctorId)
        {
            var patients = new List<Patient>();

            for (int i = 1; i <= 5; i++) // Her doktor için 5 hasta oluşturuluyor.
            {
                var patient = new Patient
                {
                    Diagnosis = $"Diagnosis {i} for Doctor {doctorId}",
                    RoleId = i,
                  //  ImageId = i,
                    FullName = $"Patient FullName{i}",
                    City = $"City{i}",
                    Phone = $"123456789{i}",
                    Email = GenerateRandomEmail($"Patient{i}", "Patient.com"),
                    Password = "mysecretpassword",
                };

                patients.Add(patient);
            }

            return patients;
        }

        private static void SeedPatients(AppDbContext context)
        {
            for (int i = 1; i <= 10; i++)
            {
                var patient = new Patient
                {
                    Diagnosis = $"Diagnosis{i}",
                    RoleId = i,
                   // ImageId = i,
                    FullName = $"Patient FullName{i}",
                    City = $"City{i}",
                    Phone = $"123456789{i}",
                    Email = GenerateRandomEmail($"Patient{i}", "example.com"),
                    Password = "mysecretpassword",
                };

                context.Patients.Add(patient);
            }

            context.SaveChanges();
        }

        

        private static void SeedPosts(AppDbContext context)
        {
            for (int i = 1; i <= 10; i++)
            {
                var post = new Post
                {
                  //  ImageId = i, // Bu örnekte ImageId'leri 1'den 10'a kadar ekledik.
                    Title = $"Post Title{i}",
                    Content = $"Post Content{i}",
                    CommentsCount = i,
                    Comments = SeedCommentsForPost(i), // Her post için rastgele yorumlar oluşturuluyor.
                    // Gerekli diğer özellikleri de doldur.
                };

                context.Posts.Add(post);
            }

            context.SaveChanges();
        }

        private static List<PostComment> SeedCommentsForPost(int postId)
        {
            var comments = new List<PostComment>();

            for (int i = 1; i <= 5; i++) // Her post için 5 yorum oluşturuluyor.
            {
                var comment = new PostComment
                {
                    PostId = postId,
                    Comment = $"Comment {i} for Post {postId}",
                    IsActive = true, // Varsayılan olarak true olarak ekledik.
                    // Gerekli diğer özellikleri de doldur.
                };

                comments.Add(comment);
            }

            return comments;
        }

        private static void SeedPostComments(AppDbContext context)
        {
            for (int i = 1; i <= 10; i++)
            {
                var postComment = new PostComment
                {
                    PostId = i, // Bu örnekte PostId'leri 1'den 10'a kadar ekledik.
                    UserId = i, // Bu örnekte UserId'leri 1'den 10'a kadar ekledik.
                    Comment = $"Comment{i}",
                    IsActive = true, // Varsayılan olarak true olarak ekledik.
                    // Gerekli diğer özellikleri de doldur.
                };

                context.PostComments.Add(postComment);
            }

            context.SaveChanges();
        }

        private static void SeedRoles(AppDbContext context)
        {
            for (int i = 1; i <= 10; i++)
            {
                var role = new Role
                {
                    RoleName = $"Role{i}",
                    // Gerekli diğer özellikleri de doldur.
                };

                context.Roles.Add(role);
            }

            context.SaveChanges();
        }

        private static void SeedSettings(AppDbContext context)
        {
            for (int i = 1; i <= 10; i++)
            {
                var setting = new Setting
                {
                    Name = $"Setting Name{i}",
                    Value = $"Setting Value{i}",
                    // Gerekli diğer özellikleri de doldur.
                };

                context.Settings.Add(setting);
            }

            context.SaveChanges();
        }
        private static void SeedPages(AppDbContext context)
        {
            for (int i = 1; i <= 10; i++)
            {
                var page = new Page
                {
                    Title = $"Page Title{i}",
                    Content = $"Page Content{i}",
                    IsActive = true, // Set IsActive based on your requirements.
                                     // Add other necessary properties here.
                };

                context.Pages.Add(page);
            }

            context.SaveChanges();
        }

        private static void SeedUsers(AppDbContext context)
        {
            for (int i = 1; i <= 10; i++)
            {
                var user = new User
                {
                    RoleId = i, // Bu örnekte RoleId'leri 1'den 10'a kadar ekledik.
                  //  ImageId = i, // Bu örnekte ImageId'leri 1'den 10'a kadar ekledik.
                    FullName = $"User{i}",
                    Email = GenerateRandomEmail($"user{i}", "example.com"),
                    Password = "passwordpassword",
                    City = $"City{i}",
                    Phone = $"123456789{i}", // Örnek telefon numarası oluşturduk.
                };

                context.Users.Add(user);
            }

            context.SaveChanges();
        }
        private static void SeedDepartmentPosts(AppDbContext context)
        {
            for (int i = 1; i <= 10; i++)
            {
                var departmentPost = new DepartmentPost
                {
                    DepartmentId = i, // Bu örnekte DepartmentId'leri 1'den 10'a kadar ekledik.
                    PostId = i, // Bu örnekte PostId'leri 1'den 10'a kadar ekledik.
                };

                context.DepartmentPosts.Add(departmentPost);
            }

            context.SaveChanges();
        }

        private static string GenerateRandomEmail(string name, string domain)
        {
            // Rastgele bir sayı ekleyerek benzersiz bir e-posta adresi oluşturun.
            var random = new Random();
            var randomNumber = random.Next(1000, 9999);
            return $"{name}{randomNumber}@{domain}";
        }
    }
}
