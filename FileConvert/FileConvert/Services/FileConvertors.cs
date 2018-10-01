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

            //Action<string, string> runtTest = (x,y) => Test(x, y);
            //runtTest.Invoke("x", "y");
            //Func<int, int, string> runCalc = (x, y) => Sum(x, y);
            //runCalc.Invoke(1, 2);

            // create an enum -> methods dictionary
            // Func<FileDTO, FileDTO> creates an anonymous delegate with FileDTO input and FileDTO output
            var convertor = new Dictionary<Enums.ConvertType, Func<FileDTO, FileDTO>>();

            // add functions to the dictionary
            convertor[Enums.ConvertType.Json] = FileProcessor.TextFileToJson;
            convertor[Enums.ConvertType.Binary] = FileProcessor.TextToBinary;

            convertedFiles = files.Where(x => x != null)  //non-null files
                .Select(x => convertor[x.ConvertMode].Invoke(x.FileObj)) // select method based on enum and execute it
                .ToList(); // convert it to list


            //for (int i = 0; i < files.Count; i++)
            //{
            //    if (files[i] != null)
            //    {
            //        FileDTO fileToAdd = files[i].FileObj;
            //        switch (files[i].ConvertMode)
            //        {
            //            case Enums.ConvertType.Json:
            //                fileToAdd = FileProcessor.TextFileToJson(fileToAdd);
            //                break;
            //            case Enums.ConvertType.Binary:
            //                fileToAdd = FileProcessor.TextToBinary(fileToAdd);
            //                break;
            //        }

            //        convertedFiles.Add(fileToAdd);
            //    }
            //}

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
