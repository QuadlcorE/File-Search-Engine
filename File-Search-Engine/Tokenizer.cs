using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data;

namespace File_Search_Engine
{
    static class Tokenizer
    {
        public class Token
        {
            public string Word { get; }
            public float TotalNumberOfDocuments = 0;

            public Token(string word)
            {
                Word = word;
            }
        }

        public class Rank
        {
            public int TermCountInDocument { get; set; }
            public float TF { get; set; }
            public float IDF { get; set; }
            public float TFIDF { get; set; }
            public Token ColumnToken { get; set; }

            public Rank ()
            {
                // ColumnToken = columnToken;
                TermCountInDocument = 1;
                TF = 0;
                IDF = 0;
                TFIDF = 0;
            }

            public void IncreaseTermCount()
            {
                TermCountInDocument += 1;
            }

            public void UpdateRank (Document document)
            {
                TF = TermCountInDocument / document.WordCount;
                IDF = TokenTable.Rows.Count / 1;// ColumnToken.TotalNumberOfDocuments;
                TFIDF = TF * IDF;
            }
        }


        public static DataSet TokenData = new DataSet("TokenData");
        public static DataTable TokenTable = new DataTable("TokenTable");
        public static List<Token> TokensDiscovered { get; } = new List<Token>();
        public static int NumberOfTimesADocument = 0; // TODO: Remove this line of code

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
                DataColumn documentColumn = new DataColumn("Document", typeof(Document));
                TokenTable.Columns.Add(documentColumn);
                TokenTable.PrimaryKey = new DataColumn[] { documentColumn };
            }
        }


        // TODO: Edit the function to accomodate changes to documents.
        public static void TokenizeDocument(Document document)
        {
            try
            {
                // Check if the document already exists in the table
                DataRow existingRow = TokenTable.Rows.Find(document);

                if (existingRow == null)
                {
                    // Create a new row and set the Document column
                    DataRow newRow = TokenTable.NewRow();
                    newRow["Document"] = document;

                    // Add the new row to the table
                    TokenTable.Rows.Add(newRow);

                    Console.WriteLine($"Added new document: {document.GetFileName()}");
                }
                else
                {
                    Console.WriteLine($"Document already exists: {document.GetFileName()}  as {TokenTable.Rows.Find(document)}");
                }

                // Count the words in the document
                document.CountWords();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error tokenizing document {document.GetFileName()}: {ex.Message}");
            }
        }

        // Rather than tokenize a document how about I tokenize a word when performing a document count.
        public static void TokenizeWord(string word, Document document)
        {
            // For each new word we find we tokenize it ( Create a token and add it to the tokenDiscovered list ) +++
            // We then add a new column to the tokentable with a tuple as its data. +++
            // We update the table to show the accurate new counts of the new token for previous documents
            // For each old token discovered we want to update the count of that token for that document
            // We also want to update that tokens TotalNumberOfDocuments

            Token currToken;

            DataRow currentRow = TokenTable.Rows.Find(document);

            if (currentRow == null)
            {
                // If the document is not in the table, add it
                currentRow = TokenTable.NewRow();
                currentRow["Document"] = document; // Use the column name "Document"
                TokenTable.Rows.Add(currentRow);
            }

            int currentColumnIndex = -1;

            if (!TokensDiscovered.Any(token => token.Word == word.ToLower()))
            {
                currToken = new Token(word.ToLower());
                TokensDiscovered.Add(currToken);

                // Add new column
                DataColumn newColumn = new DataColumn(currToken.Word, typeof(Rank));
                TokenTable.Columns.Add(newColumn);

                // Get the index of the newly added column
                currentColumnIndex = TokenTable.Columns.IndexOf(newColumn);
            }
            else
            {
                // Find the existing column index
                currentColumnIndex = TokenTable.Columns.IndexOf(word.ToLower());
            }

            // Now you have the current row and column
            int currentRowIndex = TokenTable.Rows.IndexOf(currentRow);

            // You can use currentRowIndex and currentColumnIndex as needed
            // Console.WriteLine($"Current Row Index: {currentRowIndex}, Current Column Index: {currentColumnIndex}");

            // Update the cell value if needed
            if (currentColumnIndex != -1)
            {
                if (currentRow[currentColumnIndex] == null)  currentRow[currentColumnIndex] = new Rank(); // Create and set a new Rank object
            }
        }
    }
}
