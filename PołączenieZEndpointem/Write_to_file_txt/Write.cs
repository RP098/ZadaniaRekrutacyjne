

namespace File_manager
{
   public class Write
    {
        IWrite write;
        public Write(IWrite write)
        {
            this.write = write;
        }
        public void WriteToFile(string catInfo)
        {
            write.WriteToFile(catInfo);
        }
    }
}
