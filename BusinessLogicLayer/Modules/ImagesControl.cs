using BusinessLogicLayer.ModelsDTO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace BusinessLogicLayer.Modules
{
    public static class ImagesControl
    {
        public static IEnumerable<ImageDTO> UpdateImages(string directoryPath, IFormFileCollection fileCollection)
        {
            DeleteImages(directoryPath);
            return AddImages(directoryPath, fileCollection);
        }

        public static IEnumerable<ImageDTO> AddImages(string directoryPath, IFormFileCollection fileCollection)
        {
            DirectoryInfo directory = new DirectoryInfo(directoryPath);

            if (!directory.Exists)
            {
                directory.Create();
            }

            List<ImageDTO> images = new List<ImageDTO>();

            int name = 1;
            foreach (IFormFile file in fileCollection)
            {
                using (FileStream stream = new FileStream(directoryPath + @"\" + "00" + name.ToString(), FileMode.Create))
                {
                    file.CopyTo(stream);
                    images.Add(new ImageDTO { Name = "00" + name.ToString(), Path = directoryPath + @"\" + "00" + name.ToString() });
                }
                name++;
            }

            return images;
        }

        public static void DeleteImages(string directoryPath)
        {
            DirectoryInfo directory = new DirectoryInfo(directoryPath);

            if (!directory.Exists)
                throw new DirectoryNotFoundException("Директория не найдена!");

            IEnumerable<FileInfo> files = directory.GetFiles();

            foreach (FileInfo file in files)
                file.Delete();
        }
    }
}
