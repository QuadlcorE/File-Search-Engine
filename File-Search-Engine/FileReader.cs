using UglyToad.PdfPig;
using System.Text;

namespace File_Search_Engine
{
    static class FileReader
    {
        public static string ReadDocument(Document document)
        {
            // TODO: Add cases for other file extensions along with their corresponding methods.
            switch (document.GetFileExtension().ToLower())
            {
                case ".pdf":
                    return ReadPDF(document.GetFullFileAndPathName());
                default:
                    return "";
            }
        }

        public static string ReadPDF(string fileLocation)
        {
            StringBuilder result = new StringBuilder("");
            // using (PdfDocument document = PdfDocument.Open(@"C:\Users\aawon\Downloads\190805030.pdf"))
            using (PdfDocument document = PdfDocument.Open(fileLocation))
            {
                foreach (var page in document.GetPages())
                {
                    foreach (var word in page.GetWords())
                    {
                        result.Append(word);
                    }
                }
            }
            return result.ToString();
        }
    }
}
