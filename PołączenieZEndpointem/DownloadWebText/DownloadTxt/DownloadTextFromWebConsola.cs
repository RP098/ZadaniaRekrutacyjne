using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
namespace DownloadWebText
{
    public class DownloadTextFromWebConsola:IDownload
    {
        public string theCatText = null;
        public string Download()
        {
            try
            {
                AppSettingsReader appSettings = new AppSettingsReader();
                WebClient webClient = new WebClient();
                string webURL = (string)appSettings.GetValue("EndPoint", typeof(string));
                string text = webClient.DownloadString(new Uri(webURL));
               
                return text;
            }
            catch(Exception ex)
            {
                throw ex; 
            }
        }
    }
}



