using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using FileConvert.DTOs;
using System.IO.Compression;
using System.Text.RegularExpressions;

namespace FileConvert
{
    public static class FileProcessor
    {
        #region Convertors

        public static FileDTO TextToBinary(FileDTO file)
        {
            var convertedFile = file;

            if (file.FileExtension == "txt")
            {
                string fileText = Encoding.Default.GetString(file.Content);

                using (MemoryStream memStream = new MemoryStream())
                using (BinaryWriter binWriter = new BinaryWriter(memStream, Encoding.UTF8))
                {
                    binWriter.Write(fileText);

                    convertedFile = new FileDTO()
                    {
                        FileName = file.FileName,
                        FileExtension = "",
                        Content = memStream.ToArray()
                    };

                }
            }

            return convertedFile;

        }
        public static FileDTO TextFileToJson(FileDTO file)
        {
            var convertedFileDto = file;

            if (file.FileExtension == "txt")
            {
                string fileContentAsString = Encoding.Default.GetString(file.Content);

                TextFileAsJsonDTO objectForJsonSerializer = new TextFileAsJsonDTO()
                {
                    FileName = file.FileName,
                    FileExtension = file.FileExtension,
                    Content = fileContentAsString
                };

                string fileAsJson = JsonConvert.SerializeObject(objectForJsonSerializer);

                byte[] jsonFileAsBytesArray = Encoding.Default.GetBytes(fileAsJson);


                convertedFileDto = new FileDTO()
                {
                    FileName = file.FileName,
                    FileExtension = "json",
                    Content = jsonFileAsBytesArray
                };
                
            }

            return convertedFileDto;
        }

        public static FileDTO FilesToZip(IList<FileDTO> files, string zipName)
        {
            byte[] fileZip = FileDtoListToZip(files);

            FileDTO zipFile = new FileDTO
            {
                Content = fileZip,
                FileName = zipName,
                FileExtension = "zip"
            };
            
            return zipFile;
        }

        public static void SaveFiles(IList<FileDTO> files, string outputDirectoryPath, bool overwriteExisting)
        {

            foreach (var file in files)
            {
                if( file != null )
                {
                    string fullPath = $"{outputDirectoryPath}\\{file.FileName}.{file.FileExtension}";
                    
                    var fileInfo = new FileInfo(fullPath);

                    // wtf logic?!
                    if(fileInfo.Exists)
                    {
                        if (overwriteExisting)
                        {
                            File.WriteAllBytes(fullPath, file.Content);
                        }
                    }
                    else
                    {
                        File.WriteAllBytes(fullPath, file.Content);
                    }
                }
            }
        }


        public static void SaveFile(FileDTO file, string fileOutputFullPath)
        {
            File.WriteAllBytes(fileOutputFullPath, file.Content); 
        }

        // C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileOne.txt

        public static FileDTO FilePathsToFileDTO(string fullFilePath)
        {
            var filePathList = new List<string>() { fullFilePath };
            bool fileExists = FilesExistanceChecker(filePathList);

            FileDTO fileDto = null;
            if(fileExists)
            {
                fileDto = new FileDTO();
                fileDto.Content = File.ReadAllBytes(fullFilePath);
                fileDto.FileExtension = GetFileExtension(fullFilePath);
                fileDto.FileName = GetFileName(fullFilePath);

            }
            return fileDto;
        }

        public static IList<FileDTO> FilePathsListToFileDTOList(IList<string> fullFilePaths)
        {
            IList<FileDTO> filesDTO = new List<FileDTO>();

            foreach(string filePath in fullFilePaths)
            {
                FileDTO pathToFileDTO = FilePathsToFileDTO(filePath);
                filesDTO.Add(pathToFileDTO);
            }

            return filesDTO;
        }

        #endregion







        #region Helpers
        public static string GetFileName(string fullFilePath)
        {
            string resultString = "";

            string fileName = GetFullFileName(fullFilePath);
            string fileExtension = GetFileExtension(fullFilePath);

            int fileExtensionLength = fileExtension.Length;
            int startRemoveExtensionIndex = fileName.Length - fileExtension.Length;
            if(fileExtensionLength != 0 && startRemoveExtensionIndex != 0)
            {
                resultString = fileName.Remove(startRemoveExtensionIndex - 1, fileExtensionLength + 1);
            }
            
            return resultString;
        }

        public static string GetFullFileName(string fullFilePath)
        {
            return Regex.Match(fullFilePath, pathToFileExpression).Value;
        }

        public static string GetFileExtension(string fullFilePath)
        {
            string extension = "";

            var fileName = GetFullFileName(fullFilePath);
            if (fileName.Contains('.'))
            {
                extension = Regex.Match(fileName, fileNameToExtensionExpression).Value;
            }

            return extension;
        }

        public static bool FilesExistanceChecker(IList<string> fullFilePaths)
        {
            bool exists = false;
            foreach (string filePath in fullFilePaths)
            {
                FileInfo fileInfo = new FileInfo(filePath);

                exists = fileInfo.Exists;

                if(!exists)
                {
                    exists = false;
                    break;
                }
            }

            return exists;
        }

        public static bool CheckFileExtension(string fileName, string extension)
        {
            bool valid = fileName.EndsWith(extension) && fileName.Contains('.');

            return valid;
        }

        private static byte[] FileDtoListToZip(IList<FileDTO> files)
        {
            if (files.Count > 0)
            {
                byte[] zipFileBytes;
                var zipFile = new MemoryStream();
                // create/open archive

                using (var archive = new ZipArchive(zipFile, ZipArchiveMode.Create))
                {
                    foreach (FileDTO file in files)
                    {
                        // add each file to archive
                        string fileName = file.FileName + '.' + file.FileExtension;
                        var curentEntry = archive.CreateEntry(fileName);

                        using (var openedEntry = curentEntry.Open())
                        {
                            openedEntry.Write(file.Content, 0, file.Content.Length);
                        }

                    }

                    archive.Dispose();
                    // get archive as bytes
                    zipFileBytes = zipFile.ToArray();
                }

                return zipFileBytes;
            }

            return null;

        }
        private static string pathToFileExpression = @"[^\\]+?$";

        private static string fileNameToExtensionExpression = @"[^\.]+?$";
        #endregion
    }
}
