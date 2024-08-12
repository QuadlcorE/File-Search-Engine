using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace File_Search_Engine
{
    class Document
    {
        private string Filename;
        private string FullFileAndPathName;
        private string FileExtension;
        public int WordCount { get; set; }
        public string DocumentContent { get; }

        public Document(string fullFileAndPathName)
        {
            FullFileAndPathName = fullFileAndPathName;
            Filename = Path.GetFileName(fullFileAndPathName);
            FileExtension = Path.GetExtension(fullFileAndPathName);
            DocumentContent = FileReader.ReadDocument(this);
        }

        public override bool Equals(object obj)
        {
            if (obj is Document other)
            {
                return this.FullFileAndPathName == other.FullFileAndPathName;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return FullFileAndPathName.GetHashCode();
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

        public void CountWords()
        {
            if (string.IsNullOrWhiteSpace(DocumentContent))
            {
                WordCount = 0;
            }

            // Use a regular expression to match words
            MatchCollection matches = Regex.Matches(DocumentContent, @"\b\w+\b");

            WordCount = matches.Count;

            foreach (var match in matches)
            {
                Tokenizer.TokenizeWord(match.ToString(), this);
            }
        }
    }
}

