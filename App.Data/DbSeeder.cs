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
                Description = $"Allergies including asthma are among the most common health problems. Immuno-deficiencies are rarer but can be chronic and debilitating if not diagnosed and treated properly. If you or your child have an allergic disease or a defect in the immune system, our Allergy and Immunology Division provides optimal and tailored care for children and adults with a wide range of allergic and immunologic conditions.The Allergy and Immunology Division at American Hospital Dubai provides cutting-edge, evidence-based care to identify and treat all allergic and immunological diseases.",
                // Gerekli diğer özellikler doldur.
            };

            var department8 = new Department
            {
                Name = $"Anesthesiology",
                Description = $"The word anesthesia means ‘loss of sensation’. It can involve a simple local anesthetic injection which numbs a small part of the body, such as a finger or around a tooth. It can also involve using powerful drugs which cause unconsciousness. These drugs also affect the function of the heart, the lungs, and circulation. As a result, anesthesia is only given under the close supervision of an anesthesiologist, who is trained to consider the best way to give you an effective anesthetic but also to keep you safe and well. The drugs used in anesthesia work by blocking the signals that pass along your nerves to your brain",
                // Gerekli diğer özellikler doldur.
            };

            var department9 = new Department
            {
                Name = $"Aviation Medical Services",
                Description = $"American Hospital Dubai provides exceptional Aviation Medical Services in Dubai with Specialist Aeromedical examiners. Our expert team of highly experienced Specialist AMEs is certified and approved to conduct special aviation medical examinations for all aviation professionals, including air traffic controllers, commercial pilots, private pilots, and the entire cabin crew. The trusted Specialist AMEs at the hospital access health and fitness for all the aeronautical personnel, ensuring they are fit to fly or can work safely in critical roles in the aviation field. We are committed to enable and facilitate patients with a comprehensive and complex range of medical services under one roof. With General Civil Aviation Authority (GCAA) certified Aeromedical Examiners at American Hospital Dubai, we are devoted to delivering excellence in all types of services we offer.",
                // Gerekli diğer özellikler doldur.
            };

            var department10 = new Department
            {
                Name = $"General Surgery",
                Description = $"At American Hospital Dubai’s General Surgery Department, our main aim is to deliver all-inclusive surgical healthcare at the highest international standards. We are the first choice general surgery hospital in Dubai for a number of reasons. Our team of multidisciplinary, fellowship-trained, Board-certified surgeons all possess a wealth of knowledge, in addition to their specific interests within a variety of subspecialties. These include Robotic Assistant Surgery, oncological surgery for all cancer, advanced laparoscopic surgery, colorectal surgery, breast surgery, thyroid surgery, endocrine surgery and pediatric surgery.",
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
