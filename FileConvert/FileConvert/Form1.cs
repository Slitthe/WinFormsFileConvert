using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileConvert.DTOs;
using FileConvert.Enums;
using FileConvert.Services;
using FileConvert.Storage;

namespace FileConvert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            InitDataGridViewTable();
            InitDialogSettings();

        }

        private void InitDialogSettings()
        {
            saveAsZipDialog.OverwritePrompt = true;
            saveAsZipDialog.AddExtension = true;
            saveAsZipDialog.DefaultExt = "zip";
        }

        private void InitDataGridViewTable()
        {
            var checkCol = new DataGridViewCheckBoxColumn
            {
                Name = "checkedFiles", HeaderText = "Check", ValueType = typeof(bool), AutoSizeMode = DataGridViewAutoSizeColumnMode.None, Width = 50
            };
            var fileExtension = new DataGridViewTextBoxColumn
            {
                Name = "fileExtension", HeaderText = "File Extension", ReadOnly = true, ValueType = typeof(string)
            };
            var fileNameCol = new DataGridViewTextBoxColumn
            {
                Name = "fileName", HeaderText = "File Name", ValueType = typeof(string)
            };
            var convertTypesCol = new DataGridViewComboBoxColumn
            {
                Name = "Convert To",
                DataSource = Enum.GetValues(typeof(ConvertType)),
                ValueType = typeof(ConvertType)
            };

            fileGridView.Columns.Add(checkCol);
            fileGridView.Columns.Add(fileNameCol);
            fileGridView.Columns.Add(fileExtension);
            fileGridView.Columns.Add(convertTypesCol);
        }

        private void selectFilesButton_Click(object sender, EventArgs e)
        {
            browserFilesDialog.ShowDialog();
        }

        private void browserFilesDialog_FileOk(object sender, CancelEventArgs e)
        {
            var dialogInfo = (OpenFileDialog)sender;
            var fileList = dialogInfo.FileNames;

            AddFilesData(fileList);
        }

        private void AddFilesData(string[] filePaths)
        {
            var gridRows = fileGridView.Rows;

            foreach(string filePath in filePaths)
            {
                FileDTO file = FileProcessor.FilePathsToFileDTO(filePath);

                bool isUnique = IsUnique(file);

                if (isUnique)
                {
                    gridRows.Add(false, file.FileName, file.FileExtension);
                    DataGridViewRow addedRow = gridRows[gridRows.Count - 1];

                    if(file.FileExtension != "txt")
                    {
                        addedRow.Cells[addedRow.Cells.Count - 1].ReadOnly = true;
                    }

                    InMemoryFiles.AddRowToList(addedRow, file);
                }
              
            }
            
        }

        private void uncheckAllRows()
        {
            var rows = fileGridView.Rows;
            foreach (DataGridViewRow row in rows)
            {
                row.Cells[0].Value = false;
            }
        }

        private void saveContentButton_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> checkedRows = getCheckedItems();

            if (checkedRows.Count > 0)
            {
                string saveDirectory = getDirectoryFromUserPrompt();

                var itemsToSave = InMemoryFiles.GetMatchingFiles(checkedRows)
                    .Select(item => item.FileObj).ToList();

                FileProcessor.SaveFiles(itemsToSave, saveDirectory, overwriteExisting);
                uncheckAllRows();
                Process.Start(saveDirectory);
            }
            // deleteGridViewRowsFromMemory(deletedRows);
            // open the save files dialog to select a directory
        }

        private void deleteSelectedButton_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> checkedRows = getCheckedItems();
            List<DataGridViewRow> deletedRows = deleteDataGridViewRows(checkedRows);
            
            
            List<FileToConvertDTO> checkedFilesFromMemory = InMemoryFiles.GetMatchingFiles(deletedRows);

            deleteGridViewRowsFromMemory(deletedRows);

            
        }

        private IList<DataGridViewRow> DisplayFileDtoInDataGridView(IList<FileToConvertDTO> filesToDisplay) 
        {
            var gridRows = fileGridView.Rows;
            var addedRows = new List<DataGridViewRow>(); 

            foreach (FileToConvertDTO fileToDisplay in filesToDisplay)
            {
                var fileObj = fileToDisplay.FileObj;
                gridRows.Add(false, fileObj.FileName, fileObj.FileExtension);

                // get the last added row


                DataGridViewRow addedRow = gridRows[gridRows.Count - 1];
                addedRows.Add(addedRow);

                if (fileObj.FileExtension != "txt")
                {
                    addedRow.Cells[addedRow.Cells.Count - 1].ReadOnly = true;
                }

                InMemoryFiles.AddRowToList(addedRow, fileObj);
              
            }

            return addedRows;
        }
        private string getDirectoryFromUserPrompt()
        {
            using (FolderBrowserDialog saveDir = new FolderBrowserDialog())
            {
                var saveDialog = saveDir.ShowDialog();
                if (saveDialog == DialogResult.OK)
                {
                    string path = saveDir.SelectedPath;
                    return path;
                }
            }

            return "";
        }
        private List<DataGridViewRow> getCheckedItems()
        {
            var dataViewRows = fileGridView.Rows;
            var checkedRows = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dataViewRows)
            {
                DataGridViewCheckBoxCell checkRow = (DataGridViewCheckBoxCell)row.Cells[0];
                bool checkedValue = (bool)checkRow.Value;

                if (checkedValue)
                {
                    // delete the row && the in-memory data of that row
                    checkedRows.Add(row);
                }
            }

          

            return checkedRows;
        }


        private List<DataGridViewRow> deleteDataGridViewRows(List<DataGridViewRow> rowsToDelete)
        {
            var dataGridRows = fileGridView.Rows;
            var deletedRows = new List<DataGridViewRow>();

            foreach (DataGridViewRow rowToDelete in rowsToDelete)
            {
                deletedRows.Add(rowToDelete);
                dataGridRows.Remove(rowToDelete);
            }

            return deletedRows;
        }

        private void deleteGridViewRowsFromMemory(List<DataGridViewRow> rowsToDeleteFromMemory)
        {
            foreach(DataGridViewRow rowToDelete in rowsToDeleteFromMemory)
            {
                InMemoryFiles.RemoveSpecificFile(rowToDelete);
            }
        }

        private List<FileToConvertDTO> updateInMemoryValuesToUiOnes(List<DataGridViewRow> rowsToUpdate)
        {
            foreach(DataGridViewRow row in rowsToUpdate)
            {
                var currentDropDownCell = row.Cells[row.Cells.Count - 1];

                var dropdownValue = currentDropDownCell.Value != null ? (ConvertType)currentDropDownCell.Value : ConvertType.None;

                InMemoryFiles.ChangeFileConvertType(row, dropdownValue);
            }
            //for (int i = 0; i < rows.Count; i++)
            //{
            //    var currentRow = rows[i];
            //    var currentDropDownCell = currentRow.Cells[currentRow.Cells.Count - 1];

            //    var dropdownValue = currentDropDownCell.Value != null ? (ConvertType)currentDropDownCell.Value : ConvertType.None;
            //    InMemoryFiles.ChangeFileConvertType(currentRow, dropdownValue);
            //}

            return null;
        }

        private void UpdateUiValues(IList<DataGridViewRow> rows)
        {
            // that's how you change value to a cell
            // update ui values to the list

            foreach (var row in rows)
            {
                var currentItem = InMemoryFiles.FilesDictionary[row];
                row.Cells[0].Value = false;
                row.Cells[1].Value = currentItem.FileObj.FileName;
                row.Cells[2].Value = currentItem.FileObj.FileExtension;
                row.Cells[3].Value = null;

                row.Cells[3].ReadOnly = currentItem.FileObj.FileExtension != "txt";
                
            }

            // how you change the value of something
            //fileGridView.Rows[1].Cells[3].Value = ConvertType.Json;
        }

        private void convertSelectedButton_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> checkedItems = getCheckedItems();

            if (checkedItems.Count > 0)
            {
                updateInMemoryValuesToUiOnes(checkedItems);

                // List<FileToConvertDTO> matchingMemoryItems = InMemoryFiles.GetMatchingFiles(checkedItems);

                InMemoryFiles.ConvertFiles(checkedItems);

                UpdateUiValues(checkedItems);
            }
            
        }

        private void saveFilesAsZipButton_Click(object sender, EventArgs e)
        {
            var checkedFiles = getCheckedItems();

            if (checkedFiles.Count > 0)
            {
                saveAsZipDialog.ShowDialog();
            }
        }

        private void saveAsZipDialog_FileOk(object sender, CancelEventArgs e)
        {
            var eventInfo = (SaveFileDialog) sender;
            string fileName = eventInfo.FileName;

            if (!fileName.EndsWith(".zip"))
            {
                fileName += ".zip";
            }
            
            var matchedRows = getCheckedItems();

            var matchedMemoryFiles = InMemoryFiles.GetMatchingFiles(matchedRows);
            var filesOnly = matchedMemoryFiles.Select(item => item.FileObj).ToList();

            var zippedFile = FileProcessor.FilesToZip(filesOnly, fileName);
            
            // file path
            FileProcessor.SaveFile(zippedFile, fileName);
            uncheckAllRows();
            Process.Start(fileName);

        }

        private bool IsUnique(FileDTO file)
        {
            var dictionaryFilesValues = InMemoryFiles.FilesDictionary.Values;

            var existsInDictionary = dictionaryFilesValues.Select(memFile => memFile.FileObj)
                .Where(fileObj => fileObj.FileName == file.FileName && fileObj.FileExtension == file.FileExtension).ToArray();

            return existsInDictionary.Length == 0;
        }


        private bool overwriteExisting = true;

        private void replaceFilesCheckbox_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox form = (CheckBox)sender;
            overwriteExisting = form.Checked;
        }
    }
}
