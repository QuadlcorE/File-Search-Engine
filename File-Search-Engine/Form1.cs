using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Search_Engine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if ( flBrsDlgFolderFinder.ShowDialog() == DialogResult.OK)
            {
                txtBxFolderPath.Text = flBrsDlgFolderFinder.SelectedPath;
            }
        }

        private void btnUpdater_Click(object sender, EventArgs e)
        {
            DirectorySearchResult.UpdateFolderPath(txtBxFolderPath.Text);
            if (string.IsNullOrWhiteSpace(txtBxFolderPath.Text))
            {
                MessageBox.Show("Please select file path.", "File path cannot be null or empty.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DirectorySearchResult.searchFolder();
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            lstBxFiles.Items.Clear();
            foreach (var item in DirectorySearchResult.Files)
            {
                lstBxFiles.Items.Add(item.FullFileAndPathName);
            }
        }

        private void btnTableUpdater_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Tokenizer.TokenData.Tables["TokenTable"];
        }
    }
}
