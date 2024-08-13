
namespace File_Search_Engine
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnUpdater = new System.Windows.Forms.Button();
            this.txtBxFolderPath = new System.Windows.Forms.TextBox();
            this.flBrsDlgFolderFinder = new System.Windows.Forms.FolderBrowserDialog();
            this.lstBxFiles = new System.Windows.Forms.ListBox();
            this.btnTableUpdater = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtBxSearchQuery = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lstBxSearchResults = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(305, 25);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnUpdater
            // 
            this.btnUpdater.Location = new System.Drawing.Point(305, 54);
            this.btnUpdater.Name = "btnUpdater";
            this.btnUpdater.Size = new System.Drawing.Size(75, 23);
            this.btnUpdater.TabIndex = 1;
            this.btnUpdater.Text = "Update";
            this.btnUpdater.UseVisualStyleBackColor = true;
            this.btnUpdater.Click += new System.EventHandler(this.btnUpdater_Click);
            // 
            // txtBxFolderPath
            // 
            this.txtBxFolderPath.Location = new System.Drawing.Point(13, 25);
            this.txtBxFolderPath.Name = "txtBxFolderPath";
            this.txtBxFolderPath.Size = new System.Drawing.Size(286, 20);
            this.txtBxFolderPath.TabIndex = 2;
            // 
            // lstBxFiles
            // 
            this.lstBxFiles.FormattingEnabled = true;
            this.lstBxFiles.Location = new System.Drawing.Point(12, 83);
            this.lstBxFiles.Name = "lstBxFiles";
            this.lstBxFiles.Size = new System.Drawing.Size(367, 355);
            this.lstBxFiles.TabIndex = 3;
            // 
            // btnTableUpdater
            // 
            this.btnTableUpdater.Location = new System.Drawing.Point(385, 25);
            this.btnTableUpdater.Name = "btnTableUpdater";
            this.btnTableUpdater.Size = new System.Drawing.Size(171, 23);
            this.btnTableUpdater.TabIndex = 4;
            this.btnTableUpdater.Text = "Update Table";
            this.btnTableUpdater.UseVisualStyleBackColor = true;
            this.btnTableUpdater.Click += new System.EventHandler(this.btnTableUpdater_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(385, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(330, 355);
            this.dataGridView1.TabIndex = 5;
            // 
            // txtBxSearchQuery
            // 
            this.txtBxSearchQuery.Location = new System.Drawing.Point(729, 27);
            this.txtBxSearchQuery.Name = "txtBxSearchQuery";
            this.txtBxSearchQuery.Size = new System.Drawing.Size(210, 20);
            this.txtBxSearchQuery.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(945, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lstBxSearchResults
            // 
            this.lstBxSearchResults.FormattingEnabled = true;
            this.lstBxSearchResults.Location = new System.Drawing.Point(729, 83);
            this.lstBxSearchResults.Name = "lstBxSearchResults";
            this.lstBxSearchResults.Size = new System.Drawing.Size(315, 355);
            this.lstBxSearchResults.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 525);
            this.Controls.Add(this.lstBxSearchResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtBxSearchQuery);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnTableUpdater);
            this.Controls.Add(this.lstBxFiles);
            this.Controls.Add(this.txtBxFolderPath);
            this.Controls.Add(this.btnUpdater);
            this.Controls.Add(this.btnBrowse);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnUpdater;
        private System.Windows.Forms.TextBox txtBxFolderPath;
        private System.Windows.Forms.FolderBrowserDialog flBrsDlgFolderFinder;
        private System.Windows.Forms.ListBox lstBxFiles;
        private System.Windows.Forms.Button btnTableUpdater;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtBxSearchQuery;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox lstBxSearchResults;
    }
}

