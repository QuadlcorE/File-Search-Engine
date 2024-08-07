
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
            this.lstBxFiles = new System.Windows.Forms.ListBox();
            this.fldBwsrDlgBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowseFolders = new System.Windows.Forms.Button();
            this.lblFolderSelector = new System.Windows.Forms.Label();
            this.txtBxFolderPath = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstBxFiles
            // 
            this.lstBxFiles.FormattingEnabled = true;
            this.lstBxFiles.Location = new System.Drawing.Point(24, 70);
            this.lstBxFiles.Name = "lstBxFiles";
            this.lstBxFiles.Size = new System.Drawing.Size(500, 277);
            this.lstBxFiles.TabIndex = 0;
            // 
            // btnBrowseFolders
            // 
            this.btnBrowseFolders.Location = new System.Drawing.Point(388, 8);
            this.btnBrowseFolders.Name = "btnBrowseFolders";
            this.btnBrowseFolders.Size = new System.Drawing.Size(136, 27);
            this.btnBrowseFolders.TabIndex = 1;
            this.btnBrowseFolders.Text = "Browse";
            this.btnBrowseFolders.UseVisualStyleBackColor = true;
            this.btnBrowseFolders.Click += new System.EventHandler(this.btnBrowseFolders_Click);
            // 
            // lblFolderSelector
            // 
            this.lblFolderSelector.AutoSize = true;
            this.lblFolderSelector.Location = new System.Drawing.Point(21, 15);
            this.lblFolderSelector.Name = "lblFolderSelector";
            this.lblFolderSelector.Size = new System.Drawing.Size(61, 13);
            this.lblFolderSelector.TabIndex = 3;
            this.lblFolderSelector.Text = "Folder Path";
            // 
            // txtBxFolderPath
            // 
            this.txtBxFolderPath.Location = new System.Drawing.Point(88, 12);
            this.txtBxFolderPath.Name = "txtBxFolderPath";
            this.txtBxFolderPath.Size = new System.Drawing.Size(294, 20);
            this.txtBxFolderPath.TabIndex = 4;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(388, 41);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(136, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 541);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtBxFolderPath);
            this.Controls.Add(this.lblFolderSelector);
            this.Controls.Add(this.btnBrowseFolders);
            this.Controls.Add(this.lstBxFiles);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBxFiles;
        private System.Windows.Forms.FolderBrowserDialog fldBwsrDlgBrowse;
        private System.Windows.Forms.Button btnBrowseFolders;
        private System.Windows.Forms.Label lblFolderSelector;
        private System.Windows.Forms.TextBox txtBxFolderPath;
        private System.Windows.Forms.Button btnUpdate;
    }
}

