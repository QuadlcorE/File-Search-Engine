using System.IO;

namespace File_Search_Engine
{
    class Document
    {
        private string Filename;
        private string FullFileAndPathName;
        private string FileExtension;

        public Document (string fullFileAndPathName)
        {
            FullFileAndPathName = fullFileAndPathName;
            Filename = Path.GetFileName(fullFileAndPathName);
            FileExtension = Path.GetExtension(fullFileAndPathName);
        }

        public string GetFileName()
        {
            return Filename;
        }
        public string GetFileExtension()
        {
            return FileExtension;
        }

        public string GetFullFileAndPathName()
        {
            return FullFileAndPathName;
        }
    }
}
