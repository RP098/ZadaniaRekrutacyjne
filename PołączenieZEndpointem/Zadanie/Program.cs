using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DownloadWebText;
using File_manager;
namespace Zadanie
{
    class Program
    {
        static IDownload download_ = new DownloadTextFromWebConsola();
        static ICreate create_ = new CreateFileTxt();
        static IWrite write_ = new WriteToFileTxt();
    
        static void Main(string[] args)
        {
            try
            {
                Console.Title = "Adam Górski: Netwise S.A";
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                Download download = new Download(download_);
                string textDownload = download.Download_text();
                Create create = new Create(create_);
                create.CreateFile();
                Write write = new Write(write_);
                write.WriteToFile(textDownload);
                string[] helpText = null;
                string text = textDownload;

                helpText = text.Split(new char[] { '{', '}' });
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("{");
                Console.ForegroundColor = ConsoleColor.Red;
                text = helpText[0] + "\n" + helpText[1].Replace(helpText[1].Split(new char[] { ',' }).Last(), " ") + "\n" + helpText[1].Split(new char[] { ',' }).Last() + "\n" + helpText[2];
                helpText = text.Split(new char[] { ':' });
                Console.Write(helpText[0] + ": " + helpText[1] + ": ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(helpText[2]);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
