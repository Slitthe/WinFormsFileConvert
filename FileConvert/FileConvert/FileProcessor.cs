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
    public static class FileConvertors
    {
        #region Convertors

        /// <summary>
        /// .txt -> .json convertor (as byte[])
        /// </summary>
        //public static byte[] TextFileToJson(string fullFilePath, string )
        //{
        //    if(checkFileExtension(fileName, "txt"))
        //    {
        //        string toJsonText = "";

        //        FileDTO jsonObject = new FileDTO() { }
        //        jsonObject.FileName = fileName;

        //        string fileContent = File.ReadAllText(fullFilePath);
        //        jsonObject.Content = fileContent;

        //        toJsonText = JsonConvert.SerializeObject(jsonObject);

        //        return Encoding.Default.GetBytes(toJsonText);
        //    }

        //    throw new ArgumentException("File is invalid format, only .txt accepted");
            
        //}
        
        /// <summary>
        /// files -> .zip (as bytes array)
        /// </summary>
        //public static byte[] FilePathsToZipBytesArray(IList<FileDTO> files)
        //{
        //    if (files.Count > 0)
        //    {
        //        byte[] zipFileBytes;
        //        var zipFile = new MemoryStream();
        //        // create/open archive

        //        using (ZipArchive archive = new ZipArchive(zipFile, ZipArchiveMode.Create))
        //        {
        //            foreach(FileDTO file in files)
        //            {
        //                // add each file to archive
        //                string fileName = file.FileName + file.FileExtension;
        //                var curentEntry = archive.CreateEntry(fileName);

        //                using( var openedEntry = curentEntry.Open() )
        //                {
        //                    openedEntry.Write(file.Content, 0, file.Content.Length);
        //                }
                        
        //            }

        //            // get archive as bytes
        //            zipFileBytes = zipFile.ToArray();
        //        }

        //        return zipFileBytes;
        //    }
        //    else
        //    {
        //        throw new FileNotFoundException("One or more of the inputs file couldn't be found");
        //    }

        //}

        /// <summary>
        /// .txt -> binary data (as bytes array)
        /// </summary>
        //public static byte[] TextToBinaryBytesArray(string fullFilePath, string fileName)
        //{
        //    if (checkFileExtension(fileName, "txt") && filesExistanceChecker(fullFilePath))
        //    {
        //        string fileText = File.ReadAllText(fullFilePath);

        //        using (MemoryStream memStream = new MemoryStream())
        //        using (BinaryWriter binWriter = new BinaryWriter(memStream, Encoding.UTF8))
        //        {
        //            binWriter.Write(fileText);
        //            return memStream.ToArray();
        //        }
        //    }

        //    throw new ArgumentException("File is invalid format, only .txt accepted");

        //}

        // TODO 
        // maybe move this to an extenal class/file
        // bytes[] -> file convert || example byte[] (.zip) to actual .zip file which is savable on the disk

        public static FileDTO filePathsToFileDTO(string fullFilePath)
        {
            var fileExists = filesExistanceChecker(fullFilePath);
            FileDTO fileDto = null;
            if(fileExists)
            {
                fileDto = new FileDTO();
                fileDto.Content = File.ReadAllBytes(fullFilePath);
                fileDto.FileExtension = getFileExtension(fullFilePath);
                fileDto.FileName = getFileName(fullFilePath);

            }
            return fileDto;
        }



        public static void SaveFiles(IList<FileDTO> files, string outputDirectoryPath)
        {

            foreach (var file in files)
            {
                string fullPath = $"{outputDirectoryPath}\\{file.FileName}.{file.FileExtension}";
                File.WriteAllBytes(fullPath, file.Content);
            }
        }

        //public static void SaveFilesAsZip(IList<FileDTO> files, string outputDirectory)
        //{
        //    foreach (var file in files)
        //    {
        //        string fullPath = $"{outputDirectory}\\{file.FileName}.{file.FileExtension}";

        //        File.WriteAllBytes(fullPath, file.Content);
        //    }
        //}


        #endregion

        #region Helpers

        public static string getFileName(string fullFilePath)
        {
            string resultString = "";

            string fileName = getFullFileName(fullFilePath);
            string fileExtension = getFileExtension(fullFilePath);

            int fileExtensionLength = fileExtension.Length;
            int startRemoveExtensionIndex = fileName.Length - fileExtension.Length;
            if(fileExtensionLength != 0 && startRemoveExtensionIndex != 0)
            {
                resultString = fileName.Remove(startRemoveExtensionIndex - 1, fileExtensionLength + 1);
            }
            
            return resultString;
        }

        public static string getFullFileName(string fullFilePath)
        {
            return Regex.Match(fullFilePath, pathToFileExpression).Value;
        }

        public static string getFileExtension(string fullFilePath)
        {
            string extension = "";

            var fileName = getFullFileName(fullFilePath);
            if (fileName.Contains('.'))
            {
                extension = Regex.Match(fileName, fileNameToExtensionExpression).Value;
            }

            return extension;
        }

        public static bool filesExistanceChecker(IList<string> fullFilePaths)
        {
            bool exists = false;
            foreach (string filePath in fullFilePaths)
            {
                exists = filesExistanceChecker(filePath);

                if(!exists)
                {
                    exists = false;
                    break;
                }
            }

            return exists;
        }

        public static bool filesExistanceChecker(string fullFilePath)
        {
            FileInfo fileInfo = new FileInfo(fullFilePath);

            bool fileExistance = fileInfo.Exists;

            return fileExistance;
        }

        public static bool checkFileExtension(string fileName, string extension)
        {
            bool valid = fileName.EndsWith(extension) && fileName.Contains('.');

            return valid;
        }


        private static string pathToFileExpression = @"[^\\]+?$";

        private static string fileNameToExtensionExpression = @"[^\.]+?$";
        #endregion
    }
}
