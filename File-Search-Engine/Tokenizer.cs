using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data;
using System;

namespace File_Search_Engine
{

    static class Tokenizer
    {
        public struct Token
        {
            public string Word;
            public int TotalNumberOfDocuments;
        }

        public struct Rank
        {
            public int TermCountInDocument;
            public float TF;
            public float IDF;
            public float TFIDF;
            public Token ColumnToken;
        }



        public static DataSet TokenData = new DataSet("TokenData");
        public static DataTable TokenTable = new DataTable("TokenTable");
        public static List<Token> TokensDiscovered = new List<Token>();

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

                    // Console.WriteLine($"Added new document: {document.FullFileAndPathName}");
                }
                else
                {
                    // Console.WriteLine($"Document already exists: {document.FullFileAndPathName}  as {TokenTable.Rows.Find(document)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error tokenizing document {document.FullFileAndPathName}: {ex.Message}");
            }

            try
            {
                TokenizeWords(document);
                // Console.WriteLine($"Document {document.FullFileAndPathName} words Tokenized ");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error tokenizing document {document.FullFileAndPathName}: {ex.Message}");
            }

        }

        public static void TokenizeWords(Document document)
        {
            // First identify all the words in the document 
            if (string.IsNullOrEmpty(document.DocumentContent))
            {
                document.WordCount = 0;
            }

            // use a regular expression to match words 
            MatchCollection matches = Regex.Matches(document.DocumentContent, @"\b\w+\b");

            document.WordCount = matches.Count;

            // Loop for each match in the regex collection 
            foreach (var match in matches)
            {
                // Here we Tokenize the individual words 
                string Word = match.ToString().ToLower();
                Token currToken;
                DataRow currentRow = TokenTable.Rows.Find(document.FullFileAndPathName);

                int currentColumnIndex = -1;
                Rank currRank;

                // ------------- Condition for a new undiscovered token ------------------------
                if (!TokensDiscovered.Any(token => token.Word == Word))
                {
                    currToken = new Token { Word = Word };
                    TokensDiscovered.Add(currToken);

                    // Add new column
                    DataColumn newColumn = new DataColumn(currToken.Word, typeof(Rank)); // TODO: Change this to another type 
                    TokenTable.Columns.Add(newColumn);

                    // Get the index of the newly added column
                    currentColumnIndex = TokenTable.Columns.IndexOf(newColumn);
                    currRank = new Rank { ColumnToken = currToken, IDF = 0, TermCountInDocument = 1, TF = 0, TFIDF = 0 };
                }
                // ------------- Condition for an existing Token ------------------------------
                else
                {
                    // Find the existing column index
                    currentColumnIndex = TokenTable.Columns.IndexOf(Word);
                    currToken = TokensDiscovered.Single(token => token.Word == Word);
                    currRank = new Rank { TermCountInDocument = 1, ColumnToken = currToken, TF = 0, IDF = 0, TFIDF = 0 };
                }

                // Now you have the current row and column
                int currentRowIndex = TokenTable.Rows.IndexOf(currentRow);

                // You can use currentRowIndex and currentColumnIndex as needed
                if (currentColumnIndex != -1)
                {
                    if (currentRow[currentColumnIndex] == DBNull.Value)
                    {
                        currentRow[currentColumnIndex] = currRank;
                    }
                    else
                    {
                        currRank = (Rank)currentRow[currentColumnIndex];
                        currRank.TermCountInDocument += 1;
                    }
                }

            }
        }
    } 
}
