using System;
using System.Configuration;
using System.IO;
namespace File_manager
{
   public class DeleteTxt:IDelete
    {
        public void DeleteFile()
        {
            AppSettingsReader appSettings = new AppSettingsReader();
            string nameFile = (string)appSettings.GetValue("FileName", typeof(string));
            FileTxtIsExist fileTxtIsExist = new FileTxtIsExist();
            Exception exception = new Exception("File is not exist");
            if (!fileTxtIsExist.FileIsExist())
                throw exception;
            try
            {
                FileInfo fileInfo = new FileInfo(nameFile);
                fileInfo.Delete();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
