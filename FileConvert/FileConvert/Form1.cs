using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileConvert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            inputFile.ShowDialog(); 
        }

        private void inputFile_FileOk(object sender, CancelEventArgs e)
        {
            var senderCast = (OpenFileDialog)sender;
            
            FileProcessor.TextFileToJson(senderCast.FileName, senderCast.SafeFileName);
            filePathText.Text = senderCast.FileName;


        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
