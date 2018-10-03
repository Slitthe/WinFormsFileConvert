using FileConvert.DTOs;
using FileConvert.Enums;
using FileConvert.Services;
using System.Collections.Generic;
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

        public static List<FileToConvertDTO> GetMatchingFiles(IList<DataGridViewRow> rows)
        {
            var matchingFiles = new List<FileToConvertDTO>();

            foreach(var row in rows)
            {
                if(FilesDictionary.ContainsKey(row))
                {
                    matchingFiles.Add(FilesDictionary[row]);
                }    
            }

            return matchingFiles;
        }
        public static void ChangeFileConvertType(DataGridViewRow row, ConvertType newConvertType)
        {
            if(FilesDictionary.ContainsKey(row))
            {
                FilesDictionary[row].ConvertMode = newConvertType;
            }
        }

        public static void RemoveSpecificFile(DataGridViewRow rowToRemove)
        {
            FilesDictionary.Remove(rowToRemove);
        }

        public static void ConvertFiles(List<DataGridViewRow> rows)
        {
            foreach (var row in rows)
            {
                var currentFile = FilesDictionary[row];
                var convertedFile = new FileToConvertDTO()
                {
                    ConvertMode = ConvertType.None,
                    FileObj = FileConvertors.ConvertFile(currentFile)
                };
                FilesDictionary[row] = convertedFile;
            }
            
        }

        public static void RemoveAllFiles()
        {
            FilesDictionary.Clear();
        }
    }
}
