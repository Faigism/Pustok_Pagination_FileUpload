using Pustok_DbStructure.Entities;

namespace Pustok_DbStructure.Helpers
{
    public static class FileManager
    {
        public static string Save(IFormFile file, string rootPath, string folder)
        {
            string newFileName = Guid.NewGuid().ToString() + (file.FileName.Length <= 64 ? file.FileName : file.FileName.Substring(file.FileName.Length - 64));
            //string path = rootPath + folder + newFileName; 
            string path = Path.Combine(rootPath, folder, newFileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return newFileName;
        }
        public static void Delete(string rootPath, string folder, string fileName)
        {
            string path = Path.Combine(rootPath, folder, fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
