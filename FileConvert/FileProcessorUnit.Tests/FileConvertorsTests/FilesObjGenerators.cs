using FileConvert.DTOs;
using System.Collections.Generic;
using System.IO;
using FileConvert.Enums;

namespace FileConvertorsUnit.Tests
{
    public static class FilesObjGenerators
    {
        public static List<FileToConvertDTO> GetFilesToConvertList()
        {
            string basePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests";

            var textFileContent = File.ReadAllBytes(basePath + @"\fileOne.txt");
            var nonTextFileContent = File.ReadAllBytes(basePath + @"\fileTwo.html");

            var filesList = new List<FileDTO>()
            {
                new FileDTO()
                {
                    Content = textFileContent,
                    FileExtension = "txt",
                    FileName = "textFileOne"
                },
                new FileDTO()
                {
                    Content = textFileContent,
                    FileExtension = "txt",
                    FileName = "textFileTwo"
                },
                new FileDTO()
                {
                    Content = nonTextFileContent,
                    FileExtension = "html",
                    FileName = "nonTextFile"
                }
            };

            var filesToConvertList = new List<FileToConvertDTO>()
            {
                new FileToConvertDTO()
                {
                    FileObj = filesList[0],
                    ConvertMode = ConvertType.Json
                },
                new FileToConvertDTO()
                {
                    FileObj = filesList[1],
                    ConvertMode = ConvertType.Binary
                },
                new FileToConvertDTO()
                {
                    FileObj = filesList[2]
                },
            };

            return filesToConvertList;

        }
    }
}
