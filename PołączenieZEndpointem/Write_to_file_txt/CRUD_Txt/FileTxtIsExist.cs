using System.IO;
using System.Configuration;
namespace File_manager
{
    class FileTxtIsExist
    {
        public bool FileIsExist()
        {
            AppSettingsReader appSettings = new AppSettingsReader();
            string nameFile = (string)appSettings.GetValue("FileName", typeof(string));
            FileInfo fileInfo = new FileInfo(nameFile);
            return fileInfo.Exists;
        }
    }
}
