using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace File_Search_Engine
{
    static class SearchEngine
    {
        public static string SearchQuery;

        public static List<Document> SearchResults = new List<Document>();

        public static void SearchTokens()
        {
            // First identify all the words in the SearchQuery
            if (string.IsNullOrEmpty(SearchQuery))
            {
                SearchResults = Enumerable.Empty<Document>().ToList();
            }

            // use a regular expression to match words 
            MatchCollection matches = Regex.Matches(SearchQuery, @"\b\w+\b");

            // Get the necessary document for each inputed word in the search query
            foreach (var match in matches)
            {
                string currWord = match.ToString().ToLower();
                // Check if this word is an existing token
                if (Tokenizer.TokensDiscovered.Any(token => token.Word == currWord))
                {
                    // Retrieve the column for the respective token
                    int matchedColumnIndex = Tokenizer.TokenTable.Columns.IndexOf(currWord);
                    foreach (DataRow row in Tokenizer.TokenTable.Rows)
                    {
                        // Check if a rank exists for the said Row
                        if (row[currWord] != DBNull.Value)
                        {
                            Document foundDocument = DirectorySearchResult.Files.Single(file => file.FullFileAndPathName == row["Document"]);
                            if (!SearchResults.Contains(foundDocument)) SearchResults.Add(foundDocument);
                        }
                    }
                }

            }
        }
    }
}
