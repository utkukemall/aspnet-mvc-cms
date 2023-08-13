using App.API.Abstract;

namespace App.API.Concrete
{
    public class FileService : IFileService
    {
        // IWebHostEnvironment, projenin dosya yollarına erişim sağlar.
        private IWebHostEnvironment environment;

        public FileService(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public Tuple<int, string> SaveImage(IFormFile imageFile)
        {
            try
            {
                // Projenin kök dizinine erişim sağlar.
                var contentPath = this.environment.ContentRootPath;

                // Resimleri saklamak için "Uploads" adında bir klasör yolu oluştur.
                var path = Path.Combine(contentPath, "Uploads");

                // Eğer "Uploads" klasörü yoksa, oluştur.
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }


                // Yüklenen dosyanın uzantısını al.
                var ext = Path.GetExtension(imageFile.FileName);

                // Kabul edilen resim uzantıları
                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg", ".ico" };

                // Dosya uzantısı kabul edilenler arasında değilse, hata mesajı döndür.
                if (!allowedExtensions.Contains(ext))
                {
                    string msg = string.Format("Only {0} extension allowed", string.Join(",", allowedExtensions));

                    return new Tuple<int, string>(0, msg);
                }

                // Dosya için benzersiz bir isim oluştur. 
                string uniqueString = Guid.NewGuid().ToString();

                var newFileName = uniqueString + ext;

                // Yeni dosyanın tam yolu
                var fileWithPath = Path.Combine(path, newFileName);

                // Yeni bir dosya oluştur ve içeriğini yaz. (Burası GPT üzerinde farklı, eğer hata alınırsa değiştirilecek...)
                //var stream = new FileStream(fileWithPath, FileMode.Create);

                //imageFile.CopyTo(stream);

                //stream.Close();

                // Yukarıdaki yaklaşımda manuel bir şekilde nesne oluşturuyorduk ancak olası hatalarda bellek sızıntısına yol açıp projeyi çökertme riski taşıyordu... Bunun yerine aşağıdakini kullanacağız.

                using (var stream = new FileStream(fileWithPath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                // Başarılı bir şekilde kaydedildiyse, dosya adını döndür.
                return new Tuple<int, string>(1, newFileName);
            }
            catch (Exception ex)
            {
                // Hata oluştuysa, genel bir hata mesajı döndür.
                return new Tuple<int, string>(0, "Error has occured");
            }
        }

        public bool DeleteImage(string imageFileName)
        {
            try
            {
                // Projenin web kök dizinine erişim sağlar.
                var wwwPath = this.environment.WebRootPath;

                // Silinecek dosyanın tam yolu
                var path = Path.Combine(wwwPath, "Uploads\\", imageFileName);

                // Dosya varsa sil ve 'true' döndür.
                if (System.IO.File.Exists(path))
                {

                    System.IO.File.Delete(path);
                    return true;
                }
                // Dosya yoksa 'false' döndür.
                return false;
            }
            catch (Exception ex)
            {
                // Hata oluştuysa 'false' döndür.
                return false;
            }
        }

    }
}
