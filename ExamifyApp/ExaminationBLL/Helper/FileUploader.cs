using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationBLL.Helper
{
   public static class FileUploader
   {
        public static string UploadFile(string FolderName, IFormFile File)
        {

            try
            {
                // 1 ) Get Directory
                string FolderPath = Directory.GetCurrentDirectory() + "/wwwroot/" + FolderName;


                //2) Get File Name
                string FileName = Guid.NewGuid() + Path.GetFileName(File.FileName);


                // 3) Merge Path with File Name
                string FinalPath = Path.Combine(FolderPath, FileName);


                //4) Save File As Streams "Data Overtime"
                using (var Stream = new FileStream(FinalPath, FileMode.Create))
                {
                    File.CopyTo(Stream);
                }

                return FileName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        public static string RemoveFile(string FolderName, string fileName)
        {

            try
            {
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", FolderName, fileName);

                if (File.Exists(directory))
                {
                    File.Delete(directory);
                    return "File Deleted";
                }

                return "File Not Deleted";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
