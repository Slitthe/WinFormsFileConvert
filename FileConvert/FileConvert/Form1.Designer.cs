namespace FileConvert
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
            this.selectFilesButton = new System.Windows.Forms.Button();
            this.inputFile = new System.Windows.Forms.OpenFileDialog();
            this.saveContentButton = new System.Windows.Forms.Button();
            this.fileGridView = new System.Windows.Forms.DataGridView();
            this.selectedFiles = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.convertTo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.fileGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // selectFilesButton
            // 
            this.selectFilesButton.Location = new System.Drawing.Point(12, 12);
            this.selectFilesButton.Name = "selectFilesButton";
            this.selectFilesButton.Size = new System.Drawing.Size(101, 44);
            this.selectFilesButton.TabIndex = 0;
            this.selectFilesButton.Text = "Select Files";
            this.selectFilesButton.UseVisualStyleBackColor = true;
            this.selectFilesButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // inputFile
            // 
            this.inputFile.FileName = "inputFile";
            this.inputFile.FileOk += new System.ComponentModel.CancelEventHandler(this.inputFile_FileOk);
            // 
            // saveContentButton
            // 
            this.saveContentButton.Location = new System.Drawing.Point(12, 399);
            this.saveContentButton.Name = "saveContentButton";
            this.saveContentButton.Size = new System.Drawing.Size(101, 39);
            this.saveContentButton.TabIndex = 4;
            this.saveContentButton.Text = "Save Files";
            this.saveContentButton.UseVisualStyleBackColor = true;
            this.saveContentButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // fileGridView
            // 
            this.fileGridView.AllowUserToAddRows = false;
            this.fileGridView.AllowUserToDeleteRows = false;
            this.fileGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selectedFiles,
            this.fileName,
            this.fileExtension,
            this.convertTo});
            this.fileGridView.Location = new System.Drawing.Point(12, 77);
            this.fileGridView.Name = "fileGridView";
            this.fileGridView.Size = new System.Drawing.Size(945, 316);
            this.fileGridView.TabIndex = 5;
            this.fileGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_2);
            // 
            // selectedFiles
            // 
            this.selectedFiles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.selectedFiles.Frozen = true;
            this.selectedFiles.HeaderText = "Select";
            this.selectedFiles.Name = "selectedFiles";
            this.selectedFiles.Width = 43;
            // 
            // fileName
            // 
            this.fileName.Frozen = true;
            this.fileName.HeaderText = "File Name";
            this.fileName.Name = "fileName";
            // 
            // fileExtension
            // 
            this.fileExtension.Frozen = true;
            this.fileExtension.HeaderText = "File Extension";
            this.fileExtension.Name = "fileExtension";
            this.fileExtension.ReadOnly = true;
            // 
            // convertTo
            // 
            this.convertTo.Frozen = true;
            this.convertTo.HeaderText = "Convert To";
            this.convertTo.Items.AddRange(new object[] {
            "JSON,",
            "Binary"});
            this.convertTo.Name = "convertTo";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 492);
            this.Controls.Add(this.fileGridView);
            this.Controls.Add(this.saveContentButton);
            this.Controls.Add(this.selectFilesButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.fileGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button selectFilesButton;
        private System.Windows.Forms.OpenFileDialog inputFile;
        private System.Windows.Forms.Button saveContentButton;
        private System.Windows.Forms.DataGridView fileGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectedFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileExtension;
        private System.Windows.Forms.DataGridViewComboBoxColumn convertTo;
    }
}

