using FileConvert.DTOs;
using System.Collections.Generic;
using System.IO;
using FileConvert.Enums;

namespace FileConvertorsUnit.Tests
{
    public static class FilesObjGenerators
    {
        public static List<FileToConvertDto> GetFilesToConvertList()
        {
            string basePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests";

            var textFileContent = File.ReadAllBytes(basePath + @"\fileOne.txt");
            var nonTextFileContent = File.ReadAllBytes(basePath + @"\fileTwo.html");

            var filesList = new List<FileDto>()
            {
                new FileDto()
                {
                    Content = textFileContent,
                    FileExtension = "txt",
                    FileName = "textFileOne"
                },
                new FileDto()
                {
                    Content = textFileContent,
                    FileExtension = "txt",
                    FileName = "textFileTwo"
                },
                new FileDto()
                {
                    Content = nonTextFileContent,
                    FileExtension = "html",
                    FileName = "nonTextFile"
                }
            };

            var filesToConvertList = new List<FileToConvertDto>()
            {
                new FileToConvertDto()
                {
                    FileObj = filesList[0],
                    ConvertMode = ConvertType.Json
                },
                new FileToConvertDto()
                {
                    FileObj = filesList[1],
                    ConvertMode = ConvertType.Binary
                },
                new FileToConvertDto()
                {
                    FileObj = filesList[2]
                },
            };

            return filesToConvertList;

        }
    }
}
