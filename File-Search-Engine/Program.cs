using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Search_Engine
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //DirectorySearchResult CurrentDirectory = new DirectorySearchResult();
            //CurrentDirectory.searchFolder("C:/Users/aawon/Documents/School");
        }
    }
}
