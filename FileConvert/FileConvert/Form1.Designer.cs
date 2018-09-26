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
            this.selectFileButton = new System.Windows.Forms.Button();
            this.inputFile = new System.Windows.Forms.OpenFileDialog();
            this.convertToJson = new System.Windows.Forms.Button();
            this.convertToBinary = new System.Windows.Forms.Button();
            this.convertToZip = new System.Windows.Forms.Button();
            this.saveContent = new System.Windows.Forms.Button();
            this.filePathText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(12, 12);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(101, 44);
            this.selectFileButton.TabIndex = 0;
            this.selectFileButton.Text = "Browse Files";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // inputFile
            // 
            this.inputFile.FileName = "inputFile";
            this.inputFile.FileOk += new System.ComponentModel.CancelEventHandler(this.inputFile_FileOk);
            // 
            // convertToJson
            // 
            this.convertToJson.Location = new System.Drawing.Point(473, 12);
            this.convertToJson.Name = "convertToJson";
            this.convertToJson.Size = new System.Drawing.Size(96, 44);
            this.convertToJson.TabIndex = 1;
            this.convertToJson.Text = "Convert to JSON";
            this.convertToJson.UseVisualStyleBackColor = true;
            // 
            // convertToBinary
            // 
            this.convertToBinary.Location = new System.Drawing.Point(575, 12);
            this.convertToBinary.Name = "convertToBinary";
            this.convertToBinary.Size = new System.Drawing.Size(101, 44);
            this.convertToBinary.TabIndex = 2;
            this.convertToBinary.Text = "Convert to Binary";
            this.convertToBinary.UseVisualStyleBackColor = true;
            // 
            // convertToZip
            // 
            this.convertToZip.Location = new System.Drawing.Point(683, 13);
            this.convertToZip.Name = "convertToZip";
            this.convertToZip.Size = new System.Drawing.Size(105, 43);
            this.convertToZip.TabIndex = 3;
            this.convertToZip.Text = "Convert to ZIP";
            this.convertToZip.UseVisualStyleBackColor = true;
            // 
            // saveContent
            // 
            this.saveContent.Location = new System.Drawing.Point(12, 399);
            this.saveContent.Name = "saveContent";
            this.saveContent.Size = new System.Drawing.Size(101, 39);
            this.saveContent.TabIndex = 4;
            this.saveContent.Text = "Save Files";
            this.saveContent.UseVisualStyleBackColor = true;
            this.saveContent.Click += new System.EventHandler(this.button1_Click);
            // 
            // filePathText
            // 
            this.filePathText.Location = new System.Drawing.Point(62, 169);
            this.filePathText.Name = "filePathText";
            this.filePathText.Size = new System.Drawing.Size(572, 56);
            this.filePathText.TabIndex = 5;
            this.filePathText.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.filePathText);
            this.Controls.Add(this.saveContent);
            this.Controls.Add(this.convertToZip);
            this.Controls.Add(this.convertToBinary);
            this.Controls.Add(this.convertToJson);
            this.Controls.Add(this.selectFileButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.OpenFileDialog inputFile;
        private System.Windows.Forms.Button convertToJson;
        private System.Windows.Forms.Button convertToBinary;
        private System.Windows.Forms.Button convertToZip;
        private System.Windows.Forms.Button saveContent;
        private System.Windows.Forms.Label filePathText;
    }
}

