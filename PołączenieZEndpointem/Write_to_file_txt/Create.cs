

namespace File_manager
{
   public class Create
    {
        ICreate create;
        public Create(ICreate create)
        {
            this.create = create;
        }

        public void CreateFile()
        {
            create.CreateFile();
        }
    }
}
