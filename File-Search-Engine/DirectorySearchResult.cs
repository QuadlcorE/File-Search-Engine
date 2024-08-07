using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Search_Engine
{
    static class DirectorySearchResult
    {
        private static List<string> Files;

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
                Files = Directory.GetFiles(FolderPath, "*.*", SearchOption.AllDirectories)
                                          .Where(file => allowedExtensions.Contains(Path.GetExtension(file).ToLower()))
                                          .ToList();
            }
        }

        public static List<string> GetFiles()
        {
            return Files.Select(file => Path.GetFileName(file)).ToList();
        }

    }
}
