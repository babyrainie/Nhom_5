using System.Text;
using System.Text.RegularExpressions;
namespace dailybook.Helpers
{
    public class Salt
    {
        public static string UploadImage(IFormFile Image, string folder)
        {
            try
            {
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image", folder, Image.FileName);
                using (var myfile = new FileStream(fullPath, FileMode.CreateNew))
                {
                    Image.CopyTo(myfile);
                }
                return Image.FileName;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        public static string GenerateRandomKey(int length = 5)
        {
            var pattern = @"zxcvbnmasdfghjklQWERTYUI1!@\]=-";
            var sb = new StringBuilder();
            var rd = new Random();
            for (int i = 0; i < length; i++)
            {
                sb.Append(pattern[rd.Next(0,pattern.Length)]);
            }
            return sb.ToString();
        }
    }
}
