using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadWebText
{
  public class Download
    {
        private IDownload download;
        public Download(IDownload download)
        {
            this.download = download;
        }
        public string Download_text()
        {
            return download.Download();
        }

    }
}
