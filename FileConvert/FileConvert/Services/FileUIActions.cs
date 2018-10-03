using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileConvert.DTOs;
using FileConvert.Enums;
using FileConvert.Storage;

namespace FileConvert.Services
{
    public class FileUIActions
    {
        

        public FileUIActions(DataGridView fileGridView)
        {
            _fileGridView = fileGridView;
        }
        public IList<DataGridViewRow> DisplayFileDtoInDataGridView(IList<FileToConvertDTO> filesToDisplay)
        {
            var gridRows = _fileGridView.Rows;
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

        public void AddFilesData(string[] filePaths)
        {
            var gridRows = _fileGridView.Rows;

            foreach (string filePath in filePaths)
            {
                FileDTO file = FileConvertors.FilePathsToFileDTO(filePath);

                bool isUnique = IsUnique(file);

                if (isUnique)
                {
                    gridRows.Add(false, file.FileName, file.FileExtension);
                    DataGridViewRow addedRow = gridRows[gridRows.Count - 1];

                    if (file.FileExtension != "txt")
                    {
                        addedRow.Cells[addedRow.Cells.Count - 1].ReadOnly = true;
                    }

                    InMemoryFiles.AddRowToList(addedRow, file);
                }

            }

        }
        public void UncheckAllRows()
        {
            var rows = _fileGridView.Rows;
            foreach (DataGridViewRow row in rows)
            {
                row.Cells[0].Value = false;
            }
        }
        public string getDirectoryFromUserPrompt()
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
        public List<DataGridViewRow> CheckedItems
        {
            get
            {
                var dataViewRows = _fileGridView.Rows;
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
        }

        public List<DataGridViewRow> DeleteDataGridViewRows(List<DataGridViewRow> rowsToDelete)
        {
            var dataGridRows = _fileGridView.Rows;
            var deletedRows = new List<DataGridViewRow>();

            foreach (DataGridViewRow rowToDelete in rowsToDelete)
            {
                deletedRows.Add(rowToDelete);
                dataGridRows.Remove(rowToDelete);
            }

            return deletedRows;
        }
        public void DeleteGridViewRowsFromMemory(List<DataGridViewRow> rowsToDeleteFromMemory)
        {
            foreach (DataGridViewRow rowToDelete in rowsToDeleteFromMemory)
            {
                InMemoryFiles.RemoveSpecificFile(rowToDelete);
            }
        }
        public List<FileToConvertDTO> UpdateInMemoryValuesToUiOnes(List<DataGridViewRow> rowsToUpdate)
        {
            foreach (DataGridViewRow row in rowsToUpdate)
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
        public void UpdateUiValues(IList<DataGridViewRow> rows)
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
        public bool IsUnique(FileDTO file)
        {
            var dictionaryFilesValues = InMemoryFiles.FilesDictionary.Values;

            var existsInDictionary = dictionaryFilesValues.Select(memFile => memFile.FileObj)
                .Where(fileObj => fileObj.FileName == file.FileName && fileObj.FileExtension == file.FileExtension).ToArray();

            return existsInDictionary.Length == 0;
        }

        private readonly DataGridView _fileGridView;
    }
}
