using FileConvert.DTOs;
using FileConvert.Enums;
using System.Collections.Generic;
using System.Windows.Forms;
using FileConvert.Services;

namespace FileConvert.Storage
{
    public static class InMemoryFiles
    {
        static InMemoryFiles()
        {
            FilesDictionary = new Dictionary<DataGridViewRow, FileToConvertDto>();
        }
        public static Dictionary<DataGridViewRow, FileToConvertDto> FilesDictionary { get; set; }
        public static void AddRowToList(DataGridViewRow row, FileDto fileToAdd)
        {
            FileToConvertDto fileToConvert = new FileToConvertDto()
            {
                FileObj = fileToAdd
            };

            FilesDictionary.Add(row, fileToConvert);
        }
        public static List<FileToConvertDto> GetMatchingFiles(IList<DataGridViewRow> rows)
        {
            var matchingFiles = new List<FileToConvertDto>();

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
                var convertedFile = new FileToConvertDto()
                {
                    ConvertMode = ConvertType.None,
                    FileObj = FileConvertors.ConvertFile(currentFile)
                };
                FilesDictionary[row] = convertedFile;
            }
            
        }
    }
}
