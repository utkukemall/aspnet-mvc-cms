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

            var department = new Department
            {
                Name = $"Opthomology",
                Description = $"Ophthalmology, the branch of medicine that focuses on the study and treatment of disorders and diseases related to the eyes and visual system. Ophthalmologists are specialized medical professionals who diagnose and manage various eye conditions, ranging from refractive errors like nearsightedness and farsightedness to more complex issues such as cataracts, glaucoma, and retinal disorders. They use advanced diagnostic tools and surgical techniques to provide patients with the best possible care for their vision and overall eye health. Regular eye check-ups with ophthalmologists are crucial for early detection and timely treatment of eye problems, helping individuals maintain clear vision and prevent potential sight-threatening conditions.",
                // Gerekli diğer özellikler doldur.
            };

            var department2 = new Department
            {
                Name = $"Cardiology",
                Description = $"Cardiology is the medical specialty that deals with the diagnosis, treatment, and prevention of diseases and conditions related to the heart and the cardiovascular system. Cardiologists are highly trained medical professionals who focus on understanding the intricacies of heart function and its interaction with blood vessels.They use various diagnostic techniques, such as electrocardiograms (ECGs), echocardiograms, and stress tests, to assess heart health and identify potential issues. Cardiologists also manage a wide range of heart conditions, including coronary artery disease, heart failure, arrhythmias, and congenital heart defects.Treatment approaches in cardiology may include lifestyle changes, medications, minimally invasive procedures, and, in some cases, complex surgeries.",
                // Gerekli diğer özellikler doldur.
            };

            var department3 = new Department
            {
                Name = $"Dental Care",
                Description = $"Dental care involves the maintenance of oral hygiene and the prevention and treatment of dental diseases. It is a crucial aspect of overall health and well-being. Dental care encompasses various practices, such as regular dental check-ups, daily brushing, flossing, and proper nutrition to maintain healthy teeth and gums.Dentists and dental hygienists play a vital role in providing dental care services. During routine check-ups, they examine teeth and gums, clean teeth professionally, and identify any potential dental issues like cavities, gum disease, or oral infections..",
                // Gerekli diğer özellikler doldur.
            };

            var department4 = new Department
            {
                Name = $"Child Care",
                Description = $"Child care refers to the supervision and nurturing of children in their early years by caregivers, parents, or professionals. It is a crucial aspect of a child's development, ensuring their safety, well-being, and overall growth.Child care can take various forms, such as home-based care, where parents or family members look after the child, or center-based care, which includes daycare centers, nurseries, and preschools.h",
                // Gerekli diğer özellikler doldur.
            };

            var department5 = new Department
            {
                Name = $"Pulmology",
                Description = $"Pulmonology is the medical specialty that focuses on the study and treatment of diseases and disorders related to the respiratory system. Pulmonologists are specialized physicians who diagnose and manage various respiratory conditions, including but not limited to asthma, chronic obstructive pulmonary disease (COPD), pneumonia, lung cancer, and interstitial lung diseases.They use advanced diagnostic tools such as pulmonary function tests, chest X-rays, CT scans, and bronchoscopy to assess lung health and identify specific respiratory issues..",
                // Gerekli diğer özellikler doldur.
            };

            var department6 = new Department
            {
                Name = $"Gynecology",
                Description = $"Gynecology is the medical specialty that deals with the health and well-being of the female reproductive system. Gynecologists are specialized physicians who focus on diagnosing and treating a wide range of conditions related to the female reproductive organs, including the uterus, ovaries, fallopian tubes, and breasts.These medical professionals provide essential services for women of all ages, from adolescence through menopause and beyond.",
                // Gerekli diğer özellikler doldur.
            };

            var department7 = new Department
            {
                Name = $"Allergy And Immunology",
                Description = $"Allergies including asthma are among the most common health problems. Immuno-deficiencies are rarer but can be chronic and debilitating if not diagnosed and treated properly. If you or your child have an allergic disease or a defect in the immune system, our Allergy and Immunology Division provides optimal and tailored care for children and adults with a wide range of allergic and immunologic conditions",
                // Gerekli diğer özellikler doldur.
            };

            var department8 = new Department
            {
                Name = $"Anesthesiology",
                Description = $"The word anesthesia means ‘loss of sensation’. It can involve a simple local anesthetic injection which numbs a small part of the body, such as a finger or around a tooth. It can also involve using powerful drugs which cause unconsciousness. ",
                // Gerekli diğer özellikler doldur.
            };

            var department9 = new Department
            {
                Name = $"Aviation Medical Services",
                Description = $"American Hospital Dubai provides exceptional Aviation Medical Services in Dubai with Specialist Aeromedical examiners. Our expert team of highly experienced Specialist AMEs is certified and approved to conduct special aviation medical examinations for all aviation professionals, including air traffic controllers, commercial pilots, private pilots, and the entire cabin crew. .",
                // Gerekli diğer özellikler doldur.
            };

            var department10 = new Department
            {
                Name = $"General Surgery",
                Description = $"At American Hospital Dubai’s General Surgery Department, our main aim is to deliver all-inclusive surgical healthcare at the highest international standards. We are the first choice general surgery hospital in Dubai for a number of reasons..",
                // Gerekli diğer özellikler doldur.
            };
            context.Departments.Add(department);
            context.Departments.Add(department2);
            context.Departments.Add(department3);
            context.Departments.Add(department4);
            context.Departments.Add(department5);
            context.Departments.Add(department6);
            context.Departments.Add(department7);
            context.Departments.Add(department8);
            context.Departments.Add(department9);
            context.Departments.Add(department10);


            context.SaveChanges();
        }
        // admin 1 // rol id 1
        // 2 doktor rol 1 rol 2 rol 10
        // Patitents // rol id 3
        // user // rol id 4
        private static void SeedDoctors(AppDbContext context)
        {

            var doctor = new Doctors
            {
                RoleId = 2, // roller hepsi 2
                            //  ImageId = i,
                FullName = $"Alexandar James",
                City = $"Arizona",
                Phone = $"123456789",
                Specialty = $"Orthopedic Surgary",
                //  Patients = SeedPatientsForDoctor,
                Email = "alexandarjames@mvccms.com",
                Password = "123",
                DepartmentId = 2
            };

            context.Doctors.Add(doctor);
            context.SaveChanges();
        }

  

        private static void SeedPatients(AppDbContext context)
        {
         
                var patient = new Patient
                {
                    Diagnosis = $"Brain Damage",
                    RoleId = 3,
                    FullName = $"Hakkı Bulut",
                    City = $"Hakkari/Turkey",
                    Phone = $"123456789",
                    Email = "patient1@gmail.com",
                    Password = "123123",
                    DoctorId = 1

                };

                context.Patients.Add(patient);
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

            var role = new Role
            {
                RoleName = "Admin",
                // Gerekli diğer özellikleri de doldur.
            };
            var role2 = new Role
            {
                RoleName = "Doctor",
                // Gerekli diğer özellikleri de doldur.
            };
            var role3 = new Role
            {
                RoleName = "Patient",
                // Gerekli diğer özellikleri de doldur.
            };

            var role4 = new Role
            {
                RoleName = "User",
                // Gerekli diğer özellikleri de doldur.
            };

            var role5 = new Role
            {
                RoleName = "Guest",
                // Gerekli diğer özellikleri de doldur.
            };
            
            context.Roles.Add(role);
            context.Roles.Add(role2);
            context.Roles.Add(role3);
            context.Roles.Add(role4);
            context.Roles.Add(role5);
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

            var user = new User
            {
                RoleId = 1, // Bu örnekte RoleId'leri 1'den 10'a kadar ekledik.
                            //  ImageId = i, // Bu örnekte ImageId'leri 1'den 10'a kadar ekledik.
                FullName = $"Admin admin",
                Email = "admin@mvccms.com",
                Password = "123123",
                City = $"Istanbul",
                Phone = $"1234567890", // Örnek telefon numarası oluşturduk.
            };

            var user2 = new User
            {
                RoleId = 4, // Bu örnekte RoleId'leri 1'den 10'a kadar ekledik.
                            //  ImageId = i, // Bu örnekte ImageId'leri 1'den 10'a kadar ekledik.
                FullName = $"Guest",
                Email = GenerateRandomEmail($"Guest", "Guest@mvccms.com"),
                Password = "123",
                City = $"Bagcilar",
                Phone = $"09008008080", // Örnek telefon numarası oluşturduk.
            };   
            var user3 = new User
            {
                RoleId = 4, // Bu örnekte RoleId'leri 1'den 10'a kadar ekledik.
                            //  ImageId = i, // Bu örnekte ImageId'leri 1'den 10'a kadar ekledik.
                FullName = $"User",
                Email = GenerateRandomEmail($"Guest", "User@mvccms.com"),
                Password = "123",
                City = $"Texas",
                Phone = $"09008008080", // Örnek telefon numarası oluşturduk.
            };

            context.Users.Add(user);
            context.Users.Add(user2);
            context.Users.Add(user3);
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
