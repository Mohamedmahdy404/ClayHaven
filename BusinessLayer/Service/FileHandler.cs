using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Service
{
   public static class FileHandler
   {
        public static string FileNameHandler(this IFormFile Pic)
        {
            if (Pic == null)
                return "NoPhoto.jpg";

            string PicNewName = Guid.NewGuid().ToString() + "_" + Pic.FileName;
            var FilePath = Path.Combine(@"./wwwroot/Photos", PicNewName);
            using (var file = new FileStream(FilePath, FileMode.Create))
            {
                Pic.CopyTo(file);
            };
            return PicNewName;
        }



   }
}
