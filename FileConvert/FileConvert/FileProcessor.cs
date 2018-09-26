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

        public static string TextFileToJson(string fullFilePath, string fileName)
        {
            if(checkFileExtension(fileName, "txt"))
            {

            }
            
            string toJsonText = "";


            TextToJsonModel jsonObject = new TextToJsonModel();
            jsonObject.FileName = fileName;

            string fileContent = File.ReadAllText(fullFilePath);
            jsonObject.Content = fileContent;

            toJsonText = JsonConvert.SerializeObject(jsonObject);

            return toJsonText;
        }
        
        private static bool filesExistanceChecker(IList<string> filePaths)
        {
            bool allFilesExist = true;
            foreach(string filePath in filePaths)
            {
                var info = new FileInfo(filePath);
                bool fileExists = info.Exists;

                if( !fileExists )
                {
                    allFilesExist = false;
                    break;
                }
            }

            return allFilesExist;
        }

        private static bool checkFileExtension(string fileName, string extension)
        {
            var valid = fileName.EndsWith(extension);

            return valid;
            
            
        }

        public static byte[] FilePathsToZipBytesArray(IList<string> filePaths)
        {
            if (filesExistanceChecker(filePaths))
            {
                byte[] zipFileBytes;
                var zipFile = new MemoryStream();
                using (ZipArchive archive = new ZipArchive(zipFile, ZipArchiveMode.Create))
                {
                    foreach (string filePath in filePaths)
                    {
                        string fileExtension = Regex.Match(filePath, PathToFileExpression).Value;
                        archive.CreateEntryFromFile(filePath, fileExtension);
                    }

                    zipFileBytes = zipFile.ToArray();
                }

                return zipFileBytes;
            }
            else
            {
                throw new FileNotFoundException("One or more of the inputs file couldn't be found");
            }

        }

        private static string PathToFileExpression = @"[^\\]+?$";


        /* 
            For file to binary use BinaryFormatter
        */
    }
}
