using Microsoft.AspNetCore.Http;

namespace Voyage.DATA.Utilities
{
    public static class FileExtentions
    { 

        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image");
        }

        public static bool IsGreaterThanGivenSize(this IFormFile file, int kb)
        {
            return file.Length > kb * 1000;
        }
    
    }
}
