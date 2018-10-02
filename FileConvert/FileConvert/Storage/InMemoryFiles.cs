using FileConvert.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileConvert.Storage
{
    public static class InMemoryFiles
    {
        public static Dictionary<DataGridViewRow, FileToConvertDTO> FilesDictionary { get; set; }

        static InMemoryFiles()
        {
            FilesDictionary = new Dictionary<DataGridViewRow, FileToConvertDTO>();
        }

        public static void AddRowToList(DataGridViewRow row, FileDTO fileToAdd)
        {
            // create the FileToConvertDto from the fileAdded

            FileToConvertDTO fileToConvert = new FileToConvertDTO()
            {
                FileObj = fileToAdd
            };

            FilesDictionary.Add(row, fileToConvert);
        }

        public static void ChangeFileConvertType()
        {

        }

        public static void RemoveSpecificFile(DataGridViewRow rowToRemove)
        {
            FilesDictionary.Remove(rowToRemove);
        }

        public static void RemoveAllFiles()
        {
            FilesDictionary.Clear();
        }
    }
}
