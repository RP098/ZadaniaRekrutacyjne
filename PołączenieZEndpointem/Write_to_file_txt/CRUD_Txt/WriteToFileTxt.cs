using System;
using System.IO;
using System.Configuration;
namespace File_manager
{
    public class WriteToFileTxt: IWrite
    {
        public void WriteToFile(string catInfo)
        {

            FileTxtIsExist fileTxtIsExist = new FileTxtIsExist();
            Exception exception = new Exception("File is not exist");
            if (!fileTxtIsExist.FileIsExist())
                throw exception;
            AppSettingsReader appSettings = new AppSettingsReader();
            string nameFile = (string)appSettings.GetValue("FileName", typeof(string));
            try
            {
                StreamWriter stream = File.AppendText(nameFile);
                stream.WriteLine(catInfo);
                stream.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
