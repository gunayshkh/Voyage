using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Voyage.Areas.Admin.Utilities
{
    public class FileUtility
    {
       
            public static string CreateFile(string folderPath, IFormFile file)
            {
                string fileName = Guid.NewGuid() + file.FileName;
            
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

      //        var path = Path.Combine(folderPath, fileName);


                FileStream stream = new FileStream(path, FileMode.Create);
                file.CopyTo(stream);
                stream.Close();
                return fileName;
            }

            public static void DeleteFile(string filePath)
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        
    }
}
