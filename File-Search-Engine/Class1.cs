using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System;

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
                    if (!Files.Any(curfile => curfile.FullFileAndPathName == newDoc.FullFileAndPathName))
                    {
                        Files.Add(newDoc);
                        Tokenizer.TokenizeDocument(newDoc);
                    }
                }
            }
        }
    }

    static class Tokenizer
    {
        public struct Token
        {
            public string Word;
            public int TotalNumberOfDocuments;
        }

        

        public static DataSet TokenData = new DataSet("TokenData");
        public static DataTable TokenTable = new DataTable("TokenTable");

        static Tokenizer()
        {
            InitializeTokenTable();
            if (TokenData.Tables["TokenTable"] == null)
            {
                TokenData.Tables.Add(TokenTable);
            }
        }

        public static void InitializeTokenTable()
        {
            if (TokenTable.Columns.Count == 0)
            {
                // DataColumn documentColumn = new DataColumn("Document", typeof(Document));
                DataColumn documentColumn = new DataColumn("Document", typeof(string));
                TokenTable.Columns.Add(documentColumn);
                TokenTable.PrimaryKey = new DataColumn[] { documentColumn };
            }
        }

        public static void TokenizeDocument(Document document)
        {   
            try
            {
                // Check if the document already exists in the table
                DataRow existingRow = TokenTable.Rows.Find(document.FullFileAndPathName);

                if (existingRow == null)
                {
                    // Create a new row and set the Document column
                    DataRow newRow = TokenTable.NewRow();
                    newRow["Document"] = document.FullFileAndPathName;

                    // Add the new row to the table
                    TokenTable.Rows.Add(newRow);

                    Console.WriteLine($"Added new document: {document.FullFileAndPathName}");
                }
                else
                {
                    Console.WriteLine($"Document already exists: {document.FullFileAndPathName}  as {TokenTable.Rows.Find(document)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error tokenizing document {document.FullFileAndPathName}: {ex.Message}");
            }
            
        }

        public static void TokenizeWords()
        {

        }
    }
}
