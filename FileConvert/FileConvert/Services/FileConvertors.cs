using FileConvert.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvert.Services
{
    public static class FileConvertors
    {
        public static IList<FileDTO> ConvertFiles(IList<FileToConvertDTO> files)
        {
            List<FileDTO> convertedFiles = new List<FileDTO>();

            for(int i = 0; i < files.Count; i++)
            {
                if(files[i] != null)
                {
                    FileDTO fileToAdd = files[i].FileObj;
                    {
                        switch (files[i].ConvertMode)
                        {
                            case Enums.ConvertType.Json:
                                fileToAdd = FileProcessor.TextFileToJson(fileToAdd);
                                break;
                            case Enums.ConvertType.Binary:
                                fileToAdd = FileProcessor.TextToBinary(fileToAdd);
                                break;
                        }

                        convertedFiles.Add(fileToAdd);
                    }
                }
            }

            return convertedFiles;
        }

       
        //public static void ReplaceFiles(List<FileToConvertDTO> filesToConvert, string saveDirectoryFullPath)
        //{
        //    List<FileDTO> filesToReplace = new List<FileDTO>();

        //    foreach(FileToConvertDTO fileToConvert in filesToConvert)
        //    {
        //        if(fileToConvert.FileObj.FileExtension == "txt" && fileToConvert.ConvertMode != null)
        //        {
        //            filesToReplace.Add(fileToConvert.FileObj);
        //        }
        //    }
            
            
        //    var saveDirectoryInfo = new DirectoryInfo(saveDirectoryFullPath);
        //    var filesInSaveDirectory = saveDirectoryInfo.GetFiles();
            

        //}
    }
}
