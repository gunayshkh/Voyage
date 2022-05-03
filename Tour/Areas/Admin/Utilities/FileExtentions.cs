using Microsoft.AspNetCore.Http;

namespace Voyage.Areas.Admin.Utilities
{
    public static class FileExtentions
    { 

        public static bool ImageExtention(this IFormFile file)
        {
            return file.ContentType.Contains("image");
        }

        public static bool CheckForSize(this IFormFile file, int kb)
        {
            return file.Length > 1024*kb;
        }
    
    }
}
