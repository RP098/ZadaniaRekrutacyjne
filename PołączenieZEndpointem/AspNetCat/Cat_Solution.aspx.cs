using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using File_manager;
using DownloadWebText;
namespace NetwiseAspNetCat
{
    public partial class Cat_Solution : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        IDownload download_ = new DownloadTextFromWeb();
        ICreate create_ = new CreateFileTxt();
        IWrite write_ = new WriteToFileTxt();
        IRead read_ = new ReadFileTxt();
        IDelete delete_ = new DeleteTxt();
     
        protected async void ButtondownloadText_Click(object sender, EventArgs e)
        {
            try
            {
                await Task.Run(() =>
                {
                    Download download = new Download(download_);
                    string textDownload = download.Download_text();
                    Create create = new Create(create_);
                    create.CreateFile();
                    Write write = new Write(write_);
                    write.WriteToFile(textDownload);
                    Read read = new Read(read_);
                    TextBoxCat.Text = read.ReadFile();
                });
            }
            catch(Exception ex)
            {
                TextBoxCat.Text = ex.Message;
            }
        }

        protected void deleteFile_Click(object sender, EventArgs e)
        {
            try
            {
                Delete delete = new Delete(delete_);
                delete.DeleteFile();
            }
            catch(Exception ex)
            {
                TextBoxCat.Text=ex.Message;
            }
        }

        protected void clearWindow_Click(object sender, EventArgs e)
        {
            TextBoxCat.Text = "";
        }
    }
}