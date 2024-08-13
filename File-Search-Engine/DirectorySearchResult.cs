using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace File_Search_Engine
{
    static class DirectorySearchResult
    {
        public static List<Document> Files = new List<Document>();
        private static string FolderPath;
        private static List<string> allowedExtensions = new List<string> { ".pdf", ".doc", ".docx", ".ppt", ".ppts", ".xls", ".xlsx", ".txt", ".html", ".xm" };
        public static void UpdateFolderPath(string folderPath)
        {
            FolderPath = folderPath;
        }
        public static void searchFolder()
        {
            if (Directory.Exists(FolderPath))
            {
                List<string> newFiles = Directory.GetFiles(FolderPath, "*.*", SearchOption.AllDirectories)
                                            .Where(file => allowedExtensions.Contains(Path.GetExtension(file).ToLower()))
                                            .ToList();

                foreach (var file in newFiles)
                {
                    Document newDoc = new Document();
                    newDoc.FullFileAndPathName = file;
                    newDoc.DocumentContent = FileReader.ReadDocument(newDoc.FullFileAndPathName, Path.GetExtension(newDoc.FullFileAndPathName));
                    if (!Files.Any(curfile => curfile.FullFileAndPathName == newDoc.FullFileAndPathName))
                    {
                        Files.Add(newDoc);
                        Tokenizer.TokenizeDocument(newDoc);
                    }
                }
            }
        }
    }
}
