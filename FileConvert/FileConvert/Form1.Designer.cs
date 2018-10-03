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
            this.saveAsZipDialog = new System.Windows.Forms.SaveFileDialog();
            this.deleteSelectedButton = new System.Windows.Forms.Button();
            this.saveFilesAsZipButton = new System.Windows.Forms.Button();
            this.convertSelectedButton = new System.Windows.Forms.Button();
            this.replaceFilesCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // selectFilesButton
            // 
            this.selectFilesButton.Location = new System.Drawing.Point(12, 12);
            this.selectFilesButton.Name = "selectFilesButton";
            this.selectFilesButton.Size = new System.Drawing.Size(101, 44);
            this.selectFilesButton.TabIndex = 0;
            this.selectFilesButton.Text = "Add Files";
            this.selectFilesButton.UseVisualStyleBackColor = true;
            this.selectFilesButton.Click += new System.EventHandler(this.selectFilesButton_Click);
            // 
            // saveContentButton
            // 
            this.saveContentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveContentButton.Location = new System.Drawing.Point(12, 455);
            this.saveContentButton.Name = "saveContentButton";
            this.saveContentButton.Size = new System.Drawing.Size(101, 39);
            this.saveContentButton.TabIndex = 4;
            this.saveContentButton.Text = "Save Selected";
            this.saveContentButton.UseVisualStyleBackColor = true;
            this.saveContentButton.Click += new System.EventHandler(this.saveContentButton_Click);
            // 
            // fileGridView
            // 
            this.fileGridView.AllowUserToAddRows = false;
            this.fileGridView.AllowUserToDeleteRows = false;
            this.fileGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.fileGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.fileGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileGridView.Location = new System.Drawing.Point(12, 77);
            this.fileGridView.Name = "fileGridView";
            this.fileGridView.Size = new System.Drawing.Size(915, 330);
            this.fileGridView.TabIndex = 5;
            // 
            // browserFilesDialog
            // 
            this.browserFilesDialog.FileName = "browserFilesDialog";
            this.browserFilesDialog.Multiselect = true;
            this.browserFilesDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.browserFilesDialog_FileOk);
            // 
            // saveAsZipDialog
            // 
            this.saveAsZipDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveAsZipDialog_FileOk);
            // 
            // deleteSelectedButton
            // 
            this.deleteSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteSelectedButton.BackColor = System.Drawing.Color.Firebrick;
            this.deleteSelectedButton.ForeColor = System.Drawing.Color.Transparent;
            this.deleteSelectedButton.Location = new System.Drawing.Point(809, 12);
            this.deleteSelectedButton.Name = "deleteSelectedButton";
            this.deleteSelectedButton.Size = new System.Drawing.Size(118, 43);
            this.deleteSelectedButton.TabIndex = 6;
            this.deleteSelectedButton.Text = "Remove Selected";
            this.deleteSelectedButton.UseVisualStyleBackColor = false;
            this.deleteSelectedButton.Click += new System.EventHandler(this.deleteSelectedButton_Click);
            // 
            // saveFilesAsZipButton
            // 
            this.saveFilesAsZipButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveFilesAsZipButton.Location = new System.Drawing.Point(119, 455);
            this.saveFilesAsZipButton.Name = "saveFilesAsZipButton";
            this.saveFilesAsZipButton.Size = new System.Drawing.Size(127, 39);
            this.saveFilesAsZipButton.TabIndex = 7;
            this.saveFilesAsZipButton.Text = "Save Selected as Zip";
            this.saveFilesAsZipButton.UseVisualStyleBackColor = true;
            this.saveFilesAsZipButton.Click += new System.EventHandler(this.saveFilesAsZipButton_Click);
            // 
            // convertSelectedButton
            // 
            this.convertSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.convertSelectedButton.BackColor = System.Drawing.Color.Wheat;
            this.convertSelectedButton.Location = new System.Drawing.Point(685, 13);
            this.convertSelectedButton.Name = "convertSelectedButton";
            this.convertSelectedButton.Size = new System.Drawing.Size(118, 42);
            this.convertSelectedButton.TabIndex = 8;
            this.convertSelectedButton.Text = "Convert Selected";
            this.convertSelectedButton.UseVisualStyleBackColor = false;
            this.convertSelectedButton.Click += new System.EventHandler(this.convertSelectedButton_Click);
            // 
            // replaceFilesCheckbox
            // 
            this.replaceFilesCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.replaceFilesCheckbox.Location = new System.Drawing.Point(772, 465);
            this.replaceFilesCheckbox.Name = "replaceFilesCheckbox";
            this.replaceFilesCheckbox.Size = new System.Drawing.Size(155, 29);
            this.replaceFilesCheckbox.TabIndex = 9;
            this.replaceFilesCheckbox.Text = "Replace files when saving";
            this.replaceFilesCheckbox.UseVisualStyleBackColor = true;
            this.replaceFilesCheckbox.CheckStateChanged += new System.EventHandler(this.replaceFilesCheckbox_CheckStateChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 506);
            this.Controls.Add(this.replaceFilesCheckbox);
            this.Controls.Add(this.convertSelectedButton);
            this.Controls.Add(this.saveFilesAsZipButton);
            this.Controls.Add(this.deleteSelectedButton);
            this.Controls.Add(this.fileGridView);
            this.Controls.Add(this.saveContentButton);
            this.Controls.Add(this.selectFilesButton);
            this.MinimumSize = new System.Drawing.Size(500, 400);
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
        private System.Windows.Forms.SaveFileDialog saveAsZipDialog;
        private System.Windows.Forms.Button deleteSelectedButton;
        private System.Windows.Forms.Button saveFilesAsZipButton;
        private System.Windows.Forms.Button convertSelectedButton;
        private System.Windows.Forms.CheckBox replaceFilesCheckbox;
    }
}

