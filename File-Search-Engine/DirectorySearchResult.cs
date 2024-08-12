using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace File_Search_Engine
{
    static class DirectorySearchResult
    {
        private static List<Document> Files = new List<Document>();

        private static string FolderPath;

        private static List<string> allowedExtensions = new List<string> { ".pdf", ".doc", ".docx", ".ppt", ".ppts", ".xls", ".xlsx", ".txt", ".html", ".xm" };

        public static int CalledTokenizeDocument = 0; // TODO: Remove this line of code

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
                    Document newDoc = new Document(file);
                    if (!Files.Any(curfile => curfile.GetFullFileAndPathName() == newDoc.GetFullFileAndPathName()))
                    {
                        Files.Add(newDoc);
                        Tokenizer.TokenizeDocument(newDoc);
                        CalledTokenizeDocument += 1; // TODO: Remove this line of code
                    }
                }
            }
        }

        public static List<string> GetFiles()
        {
            return Files.Select( file => file.GetFileName()).ToList();
        }

    }
}
