using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileConvert.DTOs;
using FileConvert.Enums;
using FileConvert.Storage;

namespace FileConvert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            InitDataGridViewTable();

        }

        private void InitDataGridViewTable()
        {
            DataGridViewCheckBoxColumn checkCol = new DataGridViewCheckBoxColumn();
            checkCol.Name = "checkedFiles";
            checkCol.HeaderText = "Check";
            checkCol.ValueType = typeof(bool);

            DataGridViewTextBoxColumn fileExtension = new DataGridViewTextBoxColumn();
            fileExtension.Name = "fileExtension";
            fileExtension.HeaderText = "File Extension";
            fileExtension.ReadOnly = true;
            fileExtension.ValueType = typeof(String);

            DataGridViewTextBoxColumn fileNameCol = new DataGridViewTextBoxColumn();
            fileNameCol.Name = "fileName";
            fileNameCol.HeaderText = "File Name";
            fileNameCol.ValueType = typeof(String);

            DataGridViewComboBoxColumn convertTypesCol = new DataGridViewComboBoxColumn();
            convertTypesCol.Name = "Convert To";
            convertTypesCol.DataSource = Enum.GetValues(typeof(ConvertType));
            convertTypesCol.ValueType = typeof(ConvertType);





            fileGridView.Columns.Add(checkCol);
            fileGridView.Columns.Add(fileNameCol);
            fileGridView.Columns.Add(fileExtension);
            fileGridView.Columns.Add(convertTypesCol);

            var lastColumn = fileGridView.Columns[fileGridView.Columns.Count - 1];




        }

        private void selectFilesButton_Click(object sender, EventArgs e)
        {
            // show the select files open dialog
            browserFilesDialog.ShowDialog();

            // construct files DTOs in memory from from the selected files

            // need the full path of each
        }

        private void browserFilesDialog_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog dialogInfo = (OpenFileDialog)sender;
            var fileList = dialogInfo.FileNames;

            addFilesData(fileList);
            //InMemoryFiles.AddFilesToList(filePathsToFileDto);

            //addDataGridViewRows(InMemoryFiles.filesToConvertList);
        }

        private void addFilesData(string[] filePaths)
        {
            var gridRows = fileGridView.Rows;

            foreach(string filePath in filePaths)
            {
                FileDTO file = FileProcessor.FilePathsToFileDTO(filePath);
                gridRows.Add(false, file.FileName, file.FileExtension);

                // get the last added row


                DataGridViewRow addedRow = gridRows[gridRows.Count - 1];

                if(file.FileExtension != "txt")
                {
                    addedRow.Cells[addedRow.Cells.Count - 1].ReadOnly = true;
                }

                InMemoryFiles.AddRowToList(addedRow, file);
                // pass this added row along with the file data to the in-memory collection


                // add the same file to the in-memory file list using the current row as a dictionary key
            }
            
        }

        private void saveContentButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog saveDir = new FolderBrowserDialog() )
            {
                var saveDialog = saveDir.ShowDialog();
                if(saveDialog == DialogResult.OK)
                {
                    string path = saveDir.SelectedPath;
                }
            }
            // open the save files dialog to select a directory
        }

        private void deleteSelectedButton_Click(object sender, EventArgs e)
        {
            var dataViewRows = fileGridView.Rows;

            var removeItems = new List<DataGridViewRow>();

            foreach(DataGridViewRow row in dataViewRows)
            {
                DataGridViewCheckBoxCell checkRow = (DataGridViewCheckBoxCell)row.Cells[0];
                bool checkedValue = (bool)checkRow.Value;

                if(checkedValue)
                {
                    // delete the row && the in-memory data of that row
                    removeItems.Add(row);
                }
            }

            foreach(DataGridViewRow itemToRemove in removeItems)
            {
                dataViewRows.Remove(itemToRemove);
                InMemoryFiles.RemoveSpecificFile(itemToRemove);
            }

            var memFiles = InMemoryFiles.FilesDictionary;
        }
    }
}
