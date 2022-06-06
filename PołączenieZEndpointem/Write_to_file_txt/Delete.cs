

namespace File_manager
{
   public class Delete
    {
        IDelete delete;
        public Delete(IDelete delete)
        {
            this.delete = delete;
        }

        public void DeleteFile()
        {
            delete.DeleteFile();
        }
    }
}
