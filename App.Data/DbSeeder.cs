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
            SeedAppointments(context);
            SeedContacts(context);
            SeedSubscribber(context);
        }


        //burdayım be burdayım

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

            var department11 = new Department
            {
                Name = $"Psychiatrist",
                Description = $"A psychiatrist is a medical doctor who specializes in the diagnosis, treatment, and prevention of mental illnesses and emotional disorders. Their primary focus is on understanding the complex interplay between a person's psychological, emotional, and physiological factors to provide comprehensive mental healthcare.",
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
            context.Departments.Add(department11);


            context.SaveChanges();
        }

        private static void SeedDoctors(AppDbContext context)
        {

            var doctor = new Doctors
            {
                RoleId = 2,
                FullName = $"Alexandar JAMES",
                City = $"Arizona",
                Phone = $"09008008080",
                Specialty = $"Opthomology",
                Email = GenerateRandomEmail($"Doctor", "mvccms.com"),
                Password = "123123",
                DepartmentId = 1
            };

            var doctor2 = new Doctors
            {
                RoleId = 2,
                FullName = $"Alparslan KOBAK",
                City = $"Istanbul",
                Phone = $"9874561230",
                Specialty = $"Cardiology",
                Email = "kobak@webmvc.com",
                Password = "123456",
                DepartmentId = 2
            };

            var doctor3 = new Doctors
            {
                RoleId = 2,
                FullName = $"Kadir ALTINAY",
                City = $"Warsaw",
                Phone = $"9874563210",
                Specialty = $"Psychiatrist",
                Email = "altinay@webmvc.com",
                Password = "123456",
                DepartmentId = 11
            };

            var doctor4 = new Doctors
            {
                RoleId = 2,
                FullName = $"Utku Kemal CICEK",
                City = $"Bursa",
                Phone = $"9999999999",
                Specialty = $"Aviation Medical Services",
                Email = "cicek@webmvc.com",
                Password = "393939",
                DepartmentId = 9
            };

            var doctor5 = new Doctors
            {
                RoleId = 2,
                FullName = $"Serkan BILSEL",
                City = $"Izmir",
                Phone = $"2134567890",
                Specialty = $"Dental Care",
                Email = "bilsel@webmvc.com",
                Password = "123456",
                DepartmentId = 3
            };

            var doctor6 = new Doctors
            {
                RoleId = 2,
                FullName = $"Gökhan TURKMEN",
                City = $"Ankara",
                Phone = $"7896541230",
                Specialty = $"Child Care",
                Email = "turkmen@webmvc.com",
                Password = "123456",
                DepartmentId = 4
            };

            var doctor7 = new Doctors
            {
                RoleId = 2,
                FullName = $"Muharrem INAN",
                City = $"Istanbul",
                Phone = $"9876549840",
                Specialty = $"Pulmology",
                Email = "inan@webmvc.com",
                Password = "123456",
                DepartmentId = 5
            };

            var doctor8 = new Doctors
            {
                RoleId = 2,
                FullName = $"Ilker SARIKAYA",
                City = $"Istanbul",
                Phone = $"7897894563",
                Specialty = $"Gynecology",
                Email = "sarikaya@webmvc.com",
                Password = "123456",
                DepartmentId = 6
            };

            var doctor9 = new Doctors
            {
                RoleId = 2,
                FullName = $"Haydar ARAS",
                City = $"Eskisehir",
                Phone = $"9879871350",
                Specialty = $"Allergy And Immunology",
                Email = "aras@webmvc.com",
                Password = "123456",
                DepartmentId = 7
            };

            var doctor10 = new Doctors
            {
                RoleId = 2,
                FullName = $"Ozlem OYMAK",
                City = $"Bursa",
                Phone = $"1597532580",
                Specialty = $"Anesthesiology",
                Email = "oymak@webmvc.com",
                Password = "123456",
                DepartmentId = 8
            };

            var doctor11 = new Doctors
            {
                RoleId = 2,
                FullName = $"Serdar YALMAN",
                City = $"Eskisehir",
                Phone = $"7538521594",
                Specialty = $"General Surgery",
                Email = "yalman@webmvc.com",
                Password = "123456",
                DepartmentId = 10
            };

            context.Doctors.Add(doctor);
            context.Doctors.Add(doctor2);
            context.Doctors.Add(doctor3);
            context.Doctors.Add(doctor4);
            context.Doctors.Add(doctor5);
            context.Doctors.Add(doctor6);
            context.Doctors.Add(doctor7);
            context.Doctors.Add(doctor8);
            context.Doctors.Add(doctor9);
            context.Doctors.Add(doctor10);
            context.Doctors.Add(doctor11);
            context.SaveChanges();
        }



        private static void SeedPatients(AppDbContext context)
        {

            var patient = new Patient
            {
                Diagnosis = $"Vision Problems",
                RoleId = 3,
                FullName = $"Hakkı BULUT",
                City = $"Arizona",
                Phone = $"09008008080",
                Email = GenerateRandomEmail($"Patient", "mvccms.com"),
                Password = "123123",
                DoctorId = 1
            };

            var patient2 = new Patient
            {
                Diagnosis = $"Chest Palpitations",
                RoleId = 3,
                FullName = $"Aylin YILMAZ",
                City = $"Istanbul",
                Phone = $"09008008080",
                Email = GenerateRandomEmail($"Patient", "mvccms.com"),
                Password = "123123",
                DoctorId = 2
            };

            var patient3 = new Patient
            {
                Diagnosis = $"Tooth Extraction",
                RoleId = 3,
                FullName = $"Emre KAYA",
                City = $"Izmir",
                Phone = $"09008008080",
                Email = GenerateRandomEmail($"Patient", "mvccms.com"),
                Password = "123123",
                DoctorId = 3
            };

            var patient4 = new Patient
            {
                Diagnosis = $"Feverish Toddler",
                RoleId = 3,
                FullName = $"Elif SAHIN",
                City = $"Ankara",
                Phone = $"09008008080",
                Email = GenerateRandomEmail($"Patient", "mvccms.com"),
                Password = "123123",
                DoctorId = 4
            };

            var patient5 = new Patient
            {
                Diagnosis = $"Chronic Cough",
                RoleId = 3,
                FullName = $"Burak ARSLAN",
                City = $"Istanbul",
                Phone = $"09008008080",
                Email = GenerateRandomEmail($"Patient", "mvccms.com"),
                Password = "123123",
                DoctorId = 5
            };

            var patient6 = new Patient
            {
                Diagnosis = $"Irregular Periods",
                RoleId = 3,
                FullName = $"Deniz KAYAN",
                City = $"Istanbul",
                Phone = $"09008008080",
                Email = GenerateRandomEmail($"Patient", "mvccms.com"),
                Password = "123123",
                DoctorId = 6
            };

            var patient7 = new Patient
            {
                Diagnosis = $"Allergic Reaction",
                RoleId = 3,
                FullName = $"Fırat DEMIR",
                City = $"Eskisehir",
                Phone = $"09008008080",
                Email = GenerateRandomEmail($"Patient", "mvccms.com"),
                Password = "123123",
                DoctorId = 7
            };

            var patient8 = new Patient
            {
                Diagnosis = $"Surgical Sedation",
                RoleId = 3,
                FullName = $"Gizem YILDIRIM",
                City = $"Bursa",
                Phone = $"09008008080",
                Email = GenerateRandomEmail($"Patient", "mvccms.com"),
                Password = "123123",
                DoctorId = 8
            };

            var patient9 = new Patient
            {
                Diagnosis = $"Pilot Checkup",
                RoleId = 3,
                FullName = $"Ipek AKSOY",
                City = $"Bursa",
                Phone = $"09008008080",
                Email = GenerateRandomEmail($"Patient", "mvccms.com"),
                Password = "123123",
                DoctorId = 9
            };

            var patient10 = new Patient
            {
                Diagnosis = $"Appendectomy Surgery",
                RoleId = 3,
                FullName = $"Lale PAK",
                City = $"Eskisehir",
                Phone = $"09008008080",
                Email = GenerateRandomEmail($"Patient", "mvccms.com"),
                Password = "123123",
                DoctorId = 10
            };

            var patient11 = new Patient
            {
                Diagnosis = $"Sleep Disorder",
                RoleId = 3,
                FullName = $"Pelin KURT",
                City = $"Warsaw",
                Phone = $"09008008080",
                Email = GenerateRandomEmail($"Patient", "mvccms.com"),
                Password = "123123",
                DoctorId = 11
            };

            context.Patients.Add(patient);
            context.Patients.Add(patient2);
            context.Patients.Add(patient3);
            context.Patients.Add(patient4);
            context.Patients.Add(patient5);
            context.Patients.Add(patient6);
            context.Patients.Add(patient7);
            context.Patients.Add(patient8);
            context.Patients.Add(patient9);
            context.Patients.Add(patient10);
            context.Patients.Add(patient11);
            context.SaveChanges();
        }



        private static void SeedPosts(AppDbContext context)
        {

            var post = new Post
            {
                //  ImageId = i, // Bu örnekte ImageId'leri 1'den 10'a kadar ekledik.

                Title = "Advances in the Healthcare Sector",
                Content = "The healthcare sector is continuously evolving and advancing due to innovations in science, technology, and medicine. These advancements have led to the improvement of healthcare services and treatment methods for human health. In this article, we will discuss some significant developments and innovations in the healthcare sector: Genetic and Cellular Therapies: In recent years, there have been significant advancements in genetic and cellular therapies. Gene editing technologies offer promising results for treating genetic disorders. Additionally, stem cell therapy holds great potential in the treatment of certain diseases and enhancing injury recovery.Artificial Intelligence and Data Analytics: Artificial intelligence (AI) and data analytics have revolutionized the healthcare sector. AI algorithms are being used for early disease detection, treatment planning, and patient care. Big data analytics improves the efficiency and effectiveness of healthcare services.Digital Health and Telemedicine: Digital health technologies and telemedicine services facilitate easier patient-doctor interactions and increase access to healthcare services. Remote monitoring systems and telehealth platforms are used for managing chronic diseases and providing remote patient care.Targeted Therapies: Advancements in pharmacology enable more effective and targeted treatments for diseases. Personalized medicines are tailored to individual patients' genetic characteristics and disease profiles.Robotic Surgery: Robotic surgery enhances precision and accuracy, making surgical procedures safer and more effective. This technology plays a significant role in performing complex surgeries and minimally invasive interventions.Neuromodulation Techniques: Neuromodulation involves stimulating the nervous system electrically or chemically to treat certain medical conditions. It is considered an effective method for managing chronic pain, Parkinson's disease, and epilepsy. These are just a few examples of the developments in the healthcare sector. Research and advancements in medicine and healthcare continue to progress, and we can expect even more significant breakthroughs in the future. These advancements hold the potential to improve patients' quality of life and make healthcare services more effective and accessible",
               
                // Comments = SeedCommentsForPost, // Her post için rastgele yorumlar oluşturuluyor.
                // Gerekli diğer özellikleri de doldur.
            };
            var post2 = new Post
            {
                Title = "Revolutionizing Healthcare: Unveiling the Latest Advances",
                Content = "The healthcare landscape is undergoing a remarkable transformation, driven by the relentless march of scientific discovery, technological prowess, and medical ingenuity. These dynamic advancements are redefining the way we approach healthcare, leading to enhanced services and novel treatment modalities that cater to the ever-evolving needs of humanity. In the pages that follow, we embark on a journey through some of the most noteworthy breakthroughs and innovations that are propelling the healthcare sector into an exhilarating future.",
                CommentsCount = 10,
            };
            
            var post3 = new Post
            {
                Title = "Genetic and Cellular Marvels: A Glimpse into Tomorrow",
                Content = "In recent times, the arena of genetic and cellular therapies has witnessed an extraordinary metamorphosis. The advent of gene-editing technologies has bestowed us with the potential to rectify genetic anomalies, holding the promise of curing diseases once deemed insurmountable. Simultaneously, the realm of stem cell therapy stands as a beacon of hope, showing us a path towards addressing afflictions previously deemed incurable and expediting the recovery from injuries that once posed lasting debilitation.",
                CommentsCount = 10,
            };
            var post4 = new Post
            {
                Title = "Cognitive Frontiers: AI and Data Unleashed",
                Content = "The advent of artificial intelligence (AI) and the formidable power of data analytics have sparked a revolution that reverberates throughout the healthcare domain. Harnessing the might of AI algorithms, we now stand at the precipice of early disease detection, tailored treatment strategies, and an elevated standard of patient care. The seamless integration of vast datasets has led to a profound metamorphosis, optimizing the efficiency and efficacy of healthcare services like never before.",
                CommentsCount = 10,
            };
            var post5 = new Post
            {
                Title = "Virtual Horizons: Exploring Digital Health and Telemedicine",
                Content = "In an age defined by interconnectedness, digital health technologies and the marvel of telemedicine have emerged as transformative game-changers. The once-daunting divide between patients and physicians has been bridged, as digital platforms enable seamless interactions, democratizing access to healthcare services. Remote patient monitoring systems, in synergy with telehealth platforms, herald a new era in the management of chronic ailments and the delivery of compassionate, remote care.",
                CommentsCount = 10,
            };
            var post6 = new Post
            {
                Title = "Bull's Eye Medicine: Precision in Every Dose",
                Content = "Advancements in the realm of pharmacology have ushered in an era of precision-targeted therapies, a monumental shift that transcends the conventional treatment paradigms. The dawn of personalized medicine, tailored to individual genetic idiosyncrasies and distinct disease blueprints, is upon us. This tailored approach not only augments the effectiveness of treatments but also enhances patient outcomes in ways previously deemed unattainable.",
                CommentsCount = 10,
            };
            var post7 = new Post
            {
                Title = "Surgical Symphony: The Rise of Robotic Virtuosos",
                Content = "The operating theater, once solely the realm of human hands, is now adorned with the grace of robotic precision. Robotic surgery has elevated the standards of accuracy and safety to unprecedented heights, particularly in complex procedures and minimally invasive interventions. With each controlled movement, these technological virtuosos redefine the boundaries of surgical excellence.",
                CommentsCount = 10,
            };
            var post8 = new Post
            {
                Title = "Neurological Wonders: Unveiling Neuromodulation's Potential",
                Content = "In the arena of medical interventions, neuromodulation stands as a vanguard, unlocking new avenues of hope for individuals grappling with chronic afflictions. By delicately stimulating the nervous system through electrical or chemical means, we're unraveling innovative solutions for chronic pain, Parkinson's disease, epilepsy, and beyond. This technique marks a testament to human innovation's ability to conquer the most intricate challenges posed by the human body.",
                CommentsCount = 10,
            };
            var post9 = new Post
            {
                Title = "A Glimpse into the Future: Pioneering the Path Aheadn",
                Content = "As we traverse the ever-unfolding landscape of medical marvels, it is clear that the journey has only just begun. The relentless pursuit of knowledge and the audacity to push boundaries continue to propel medicine forward. With each passing day, we edge closer to a future where patient well-being is augmented, healthcare becomes even more accessible, and the very fabric of human existence is interwoven with the tapestry of groundbreaking innovation." +
                "In retrospect, these advances in the healthcare sector serve as a poignant reminder that the boundaries of human achievement are but temporary markers in an ever-expansive voyage towards progress. And as we inch towards a horizon teeming with potential, we do so with a shared anticipation for the untold wonders that lie ahead.",
                CommentsCount = 10,
            };
            var post10 = new Post
            {
                Title = "Elixir of Genetics: Unveiling a New Era",
                Content = "The symphony of progress in the realm of genetics and cellular therapies is reaching a crescendo, offering us a glimpse into a future where the manipulation of genes holds the key to treating ailments once deemed unconquerable. The emergence of gene-editing technologies casts a radiant light on the possibility of rewriting the very code of life, a prospect that holds immense potential for eradicating hereditary disorders. Concurrently, the allure of stem cell therapy dances before us, promising novel avenues for disease management and swifter convalescence from injuries.",
                CommentsCount = 10,
            };
            var post11 = new Post
            {
                Title = "AI's Healing Touch: Crafting a Healthier Tomorrow",
                Content = "In the annals of healthcare history, the chapter on artificial intelligence (AI) and data analytics gleams with transformative promise. With algorithms as our guide, we traverse uncharted territories, detecting diseases at their inception, devising treatment blueprints with surgical precision, and orchestrating a symphony of patient care that resonates with empathy. The marriage of colossal data streams with the prowess of AI bestows upon us a treasure trove of insights, optimizing the efficacy and efficiency of healthcare services in a manner previously deemed unattainable.",
                CommentsCount = 10,
            };

            context.Posts.Add(post);
            context.Posts.Add(post2);
            context.Posts.Add(post3);
            context.Posts.Add(post4);
            context.Posts.Add(post5);
            context.Posts.Add(post6);
            context.Posts.Add(post7);
            context.Posts.Add(post8);
            context.Posts.Add(post9);
            context.Posts.Add(post10);
            context.Posts.Add(post11);
            context.SaveChanges();
        }

        private static List<PostComment> SeedCommentsForPost(int postId)
        {
            var comments = new List<PostComment>();


            var comment = new PostComment
            {
                PostId = postId,
                Comment = $"Wow, these healthcare advancements are truly remarkable! It's incredible to see how technology and science are revolutionizing the medical field. The potential for personalized treatments and improved patient care is so promising. Exciting times ahead for healthcare{postId}",
                IsActive = true, // Varsayılan olarak true olarak ekledik.
                                 // Gerekli diğer özellikleri de doldur.
            };

            comments.Add(comment);
            return comments;
        }

        private static void SeedPostComments(AppDbContext context)
        {

            var postComment = new PostComment
            {
                PostId = 1, // Bu örnekte PostId'leri 1'den 10'a kadar ekledik.
                UserId = 1, // Bu örnekte UserId'leri 1'den 10'a kadar ekledik.
                Comment = $"This is such a positive step forward in healthcare! The progress in genetic therapies and AI applications is truly impressive. It gives hope for better treatment options and faster diagnoses in the future. Kudos to all the researchers and healthcare professionals working tirelessly to make these advancements a reality!",
                IsActive = true, // Varsayılan olarak true olarak ekledik.
                                 // Gerekli diğer özellikleri de doldur.
            };

            context.PostComments.Add(postComment);


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

            var setting = new Setting
            {
                Name = $"First Setting",
                Address = $"Karaköy / İstanbul",
                Email = "academy@siliconmade.com",
                Image = "",
                IsActive = true ,
                Phone = "+90 850 272 7454",
                AlpLinkedin = "https://www.linkedin.com/in/alparslan-kobak-5a98831b5/",
                UtkuLinkedin = "https://www.youtube.com/shorts/fDjMVKTFjFs",
                KadirLinkedin = "https://www.linkedin.com/in/kadir-alt%C4%B1nay-919a66264/"                
            };

            context.Settings.Add(setting);
            context.SaveChanges();
        }
        private static void SeedPages(AppDbContext context)
        {

            var page = new Page
            {
                Title = $"Cms News",
                Content = $"News From Healty World",
                IsActive = true, // Set IsActive based on your requirements.
                                 // Add other necessary properties here.
            };

            context.Pages.Add(page);
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
                Phone = $"09008008080", // Örnek telefon numarası oluşturduk.
            };

            var user2 = new User
            {
                RoleId = 4, // Bu örnekte RoleId'leri 1'den 10'a kadar ekledik.
                            //  ImageId = i, // Bu örnekte ImageId'leri 1'den 10'a kadar ekledik.
                FullName = $"Guest",
                Email = GenerateRandomEmail($"User", "mvccms.com"),
                Password = "123123",
                City = $"Bagcilar",
                Phone = $"09008008080", // Örnek telefon numarası oluşturduk.
            };
            var user3 = new User
            {
                RoleId = 4, // Bu örnekte RoleId'leri 1'den 10'a kadar ekledik.
                            //  ImageId = i, // Bu örnekte ImageId'leri 1'den 10'a kadar ekledik.
                FullName = $"User",
                Email = GenerateRandomEmail($"User", "mvccms.com"),
                Password = "123123",
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

            var departmentPost = new DepartmentPost
            {
                DepartmentId = 1, // Bu örnekte DepartmentId'leri 1'den 10'a kadar ekledik.
                PostId = 1, // Bu örnekte PostId'leri 1'den 10'a kadar ekledik.
            };

            context.DepartmentPosts.Add(departmentPost);
            context.SaveChanges();
        }

        private static void SeedAppointments(AppDbContext context)
        {
            Appointment appointment = new()
            {
                DepartmentId = 2,
                DoctorId = 2,
                AppointmentDate = new DateTime(2023, 08, 17),
                Email = "lnt@coalminer.com",
                FullName = "Abuzer Coalsaler",
                Message = "My son gived me a toxic thing. Son of a Dog!",
                Phone = "974764233466",


            };
            context.Appointments.Add(appointment);

            Appointment appointment2 = new()
            {
                DepartmentId = 11,
                DoctorId = 3,
                AppointmentDate = new DateTime(2023, 08, 17),
                Email = "Kantarci@vadi.com",
                FullName = "Tuncay Weigher",
                Message = "I do not like bugs. Burn them all!",
                Phone = "974764233466",


            };
            context.Appointments.Add(appointment2);

            Appointment appointment3 = new()
            {
                DepartmentId = 9,
                DoctorId = 4,
                AppointmentDate = new DateTime(2023, 08, 17),
                Email = "Madman@guesthouse.com",
                FullName = "Unknown Guest",
                Message = "I do not know what i have...",
                Phone = "974764233466",


            };
            context.Appointments.Add(appointment3);

            Appointment appointment4 = new()
            {
                DepartmentId = 3,
                DoctorId = 5,
                AppointmentDate = new DateTime(2023, 08, 17),
                Email = "ChickGirl@gmail.com",
                FullName = "The Mediterranean Girl",
                Message = "I have nothing... But Dentist is too hot...",
                Phone = "974764233466",


            };
            context.Appointments.Add(appointment4);

            context.SaveChanges();
        }


        private static void SeedContacts(AppDbContext context)
        {
            Contact contact = new()
            {
                Title = "Non of Your Businness",
                Email = "chief@kgt.com",
                FullName = "Lion Whitelord",
                Message = "I gived you some stuffs. Take care of them!",
                Phone = "974764233466",


            };
            context.Contacts.Add(contact);

           
           

            context.SaveChanges();
        }

        private static void SeedSubscribber(AppDbContext context)
        {
            Subscriber subscribber = new()
            {
        
                Email = "Azrail2023@gmail.com"
               

            };
            context.Subscribbers.Add(subscribber);




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
