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
using FileConvert.Services;

namespace FileConvert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            InitDataGridViewTable();
            InitDialogSettings();
            _fileUIActions = new FileUiActions(fileGridView);
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
                Name = "fileName", HeaderText = "File Name", ReadOnly = true, ValueType = typeof(string)
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

            _fileUIActions.AddFilesData(fileList);
        }
        private void saveContentButton_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> checkedRows = _fileUIActions.CheckedItems;

            if (checkedRows.Count > 0)
            {
                string saveDirectory = _fileUIActions.getDirectoryFromUserPrompt();

                var itemsToSave = InMemoryFiles.GetMatchingFiles(checkedRows)
                    .Select(item => item.FileObj).ToList();

                if (!string.IsNullOrEmpty((saveDirectory)))
                {
                    _fileUIActions.UncheckAllRows();
                    FileConvertors.SaveFiles(itemsToSave, saveDirectory, _overwriteExisting);
                    Process.Start(saveDirectory);
                }
            }
            //deleteGridViewRowsFromMemory(deletedRows);
            // open the save files dialog to select a directory
        }
        private void deleteSelectedButton_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> checkedRows = _fileUIActions.CheckedItems;
            List<DataGridViewRow> deletedRows = _fileUIActions.DeleteDataGridViewRows(checkedRows);
            
            
            List<FileToConvertDto> checkedFilesFromMemory = InMemoryFiles.GetMatchingFiles(deletedRows);

            _fileUIActions.DeleteGridViewRowsFromMemory(deletedRows);

            
        }
        private void convertSelectedButton_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> checkedItems = _fileUIActions.CheckedItems;

            if (checkedItems.Count > 0)
            {
                _fileUIActions.UpdateInMemoryValuesToUiOnes(checkedItems);

                // List<FileToConvertDTO> matchingMemoryItems = InMemoryFiles.GetMatchingFiles(checkedItems);

                InMemoryFiles.ConvertFiles(checkedItems);

                _fileUIActions.UpdateUiValues(checkedItems);
            }
            
        }
        private void saveFilesAsZipButton_Click(object sender, EventArgs e)
        {
            var checkedFiles = _fileUIActions.CheckedItems;

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
            
            var matchedRows = _fileUIActions.CheckedItems;

            var matchedMemoryFiles = InMemoryFiles.GetMatchingFiles(matchedRows);
            var filesOnly = matchedMemoryFiles.Select(item => item.FileObj).ToList();

            var zippedFile = FileConvertors.FilesToZip(filesOnly, fileName);
            
            // file path
            FileConvertors.SaveFile(zippedFile, fileName);
            _fileUIActions.UncheckAllRows();
            Process.Start(fileName);

        }
        private void replaceFilesCheckbox_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox form = (CheckBox)sender;
            _overwriteExisting = form.Checked;
        }

        private bool _overwriteExisting = true;
        private readonly FileUiActions _fileUIActions;




    }
}
