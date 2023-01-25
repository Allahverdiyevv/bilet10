namespace bileton.Helpers
{
    public static class FileManage
    {
        public static string SaveFile(string rootpash, string FolderName, IFormFile file)
        {
            string name = file.FileName;
            string path = Path.Combine(rootpash, FolderName  , name);

           
            using(FileStream fs = new FileStream(path , FileMode.Create))
            {
                file.CopyTo(fs);
            }
            return name;    
        }
        public static void DeleteFile(string rootpash, string FolderName,string filename) 
        {
            string deletpath = Path.Combine(rootpash, FolderName, filename);
            if (System.IO.File.Exists(deletpath))
            {
                System.IO.File.Delete(deletpath);
            }
           
        }

       
    }
}
