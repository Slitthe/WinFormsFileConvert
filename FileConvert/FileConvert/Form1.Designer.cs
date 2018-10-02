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
            this.saveContentButton = new System.Windows.Forms.Button();
            this.fileGridView = new System.Windows.Forms.DataGridView();
            this.browserFilesDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.deleteSelectedButton = new System.Windows.Forms.Button();
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
            this.selectFilesButton.Click += new System.EventHandler(this.selectFilesButton_Click);
            // 
            // saveContentButton
            // 
            this.saveContentButton.Location = new System.Drawing.Point(12, 399);
            this.saveContentButton.Name = "saveContentButton";
            this.saveContentButton.Size = new System.Drawing.Size(101, 39);
            this.saveContentButton.TabIndex = 4;
            this.saveContentButton.Text = "Save Files";
            this.saveContentButton.UseVisualStyleBackColor = true;
            this.saveContentButton.Click += new System.EventHandler(this.saveContentButton_Click);
            // 
            // fileGridView
            // 
            this.fileGridView.AllowUserToAddRows = false;
            this.fileGridView.AllowUserToDeleteRows = false;
            this.fileGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileGridView.Location = new System.Drawing.Point(12, 77);
            this.fileGridView.Name = "fileGridView";
            this.fileGridView.Size = new System.Drawing.Size(945, 316);
            this.fileGridView.TabIndex = 5;
            // 
            // browserFilesDialog
            // 
            this.browserFilesDialog.FileName = "browserFilesDialog";
            this.browserFilesDialog.Multiselect = true;
            this.browserFilesDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.browserFilesDialog_FileOk);
            // 
            // deleteSelectedButton
            // 
            this.deleteSelectedButton.Location = new System.Drawing.Point(839, 12);
            this.deleteSelectedButton.Name = "deleteSelectedButton";
            this.deleteSelectedButton.Size = new System.Drawing.Size(118, 43);
            this.deleteSelectedButton.TabIndex = 6;
            this.deleteSelectedButton.Text = "Delete Selected";
            this.deleteSelectedButton.UseVisualStyleBackColor = true;
            this.deleteSelectedButton.Click += new System.EventHandler(this.deleteSelectedButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 492);
            this.Controls.Add(this.deleteSelectedButton);
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
        private System.Windows.Forms.Button saveContentButton;
        private System.Windows.Forms.DataGridView fileGridView;
        private System.Windows.Forms.OpenFileDialog browserFilesDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button deleteSelectedButton;
    }
}

