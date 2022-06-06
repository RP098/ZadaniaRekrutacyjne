using System;
using System.IO;
using System.Configuration;
namespace File_manager
{
    public class ReadFileTxt:IRead
    {
        public string ReadFile()
        {

            FileTxtIsExist fileTxtIsExist = new FileTxtIsExist();
            Exception exception = new Exception("File is not exist");
            if (!fileTxtIsExist.FileIsExist())
                throw exception;
            AppSettingsReader appSettings = new AppSettingsReader();
            string nameFile = (string)appSettings.GetValue("FileName", typeof(string));
            string catRead = null;
            try
            { 
                StreamReader stream= new StreamReader(nameFile);
                string line;
                while ( (line = stream.ReadLine())!=null)
                {
                    catRead += line + "\n";
                }
                stream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return catRead;
        }
    }
}
