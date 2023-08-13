namespace App.API.Abstract
{
    public interface IFileService
    {
        public Tuple<int, string> SaveImage(IFormFile image);
        public bool DeleteImage(string imageFileName);
    }
}
