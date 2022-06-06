

namespace File_manager
{
   public class Read
    {
        IRead read;
        public Read(IRead read)
        {
            this.read = read;
        }

        public string ReadFile()
        {
            return read.ReadFile();
        }
    }
}
