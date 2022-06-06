using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
namespace DownloadWebText
{
    public class DownloadTextFromWeb:IDownload
    {
        public string theCatText = null;
        public string Download()
        {
            try
            {
                AppSettingsReader appSettings = new AppSettingsReader();
                WebClient webClient = new WebClient();
                string webURL = (string)appSettings.GetValue("EndPoint", typeof(string));
                string text= webClient.DownloadString(new Uri(webURL));
                string [] helpText = text.Split(new char[] { '{','}' });
                text = "{"+ helpText[0] + "\n" + helpText[1].Replace(helpText[1].Split(new char[] { ',' }).Last()," ") + "\n" + helpText[1].Split(new char[] { ',' }).Last() + "\n" + helpText[2] +"}";
                helpText= text.Split(new char[] { ':' });
                text= helpText[0]+": " + helpText[1]+ ": "+helpText[2];
                return text;
            }
            catch(Exception ex)
            {
                throw ex; 
            }
        }
    }
}
