using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileConvert.Services
{
    public static class FileNameHelpers
    {
        public static string GetFileName(string fullFilePath)
        {
            string resultString = "";

            string fileName = GetFullFileName(fullFilePath);
            string fileExtension = GetFileExtension(fullFilePath);


            int fileExtensionLength = fileExtension.Length;
            int startRemoveExtensionIndex = fileName.Length - fileExtension.Length;

            if (fileExtensionLength != 0 && startRemoveExtensionIndex != 0)
            {
                resultString = fileName.Remove(startRemoveExtensionIndex - 1, fileExtensionLength + 1);
            }
            else
            {
                resultString = fileName;
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
        public static bool FilesExistenceChecker(IList<string> fullFilePaths)
        {
            bool exists = false;
            foreach (string filePath in fullFilePaths)
            {
                FileInfo fileInfo = new FileInfo(filePath);

                exists = fileInfo.Exists;

                if (!exists)
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

        private static string pathToFileExpression = @"[^\\]+?$";

        private static string fileNameToExtensionExpression = @"[^\.]+?$";
    }
}
