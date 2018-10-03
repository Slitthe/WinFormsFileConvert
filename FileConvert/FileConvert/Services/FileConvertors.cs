using FileConvert.DTOs;
using FileConvert.Enums;
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

        
        public static FileDTO ConvertFile(FileToConvertDTO file)
        {
            FileDTO convertedFile = file.FileObj;

            //Action<string, string> runtTest = (x,y) => Test(x, y);
            //runtTest.Invoke("x", "y");
            //Func<int, int, string> runCalc = (x, y) => Sum(x, y);
            //runCalc.Invoke(1, 2);

            // create an enum -> methods dictionary
            // Func<FileDTO, FileDTO> creates an anonymous delegate with FileDTO input and FileDTO output
            //var convertor = new Dictionary<Enums.ConvertType, Func<FileDTO, FileDTO>>();

            //// add functions to the dictionary
            //convertor[Enums.ConvertType.Json] = FileProcessor.TextFileToJson;
            //convertor[Enums.ConvertType.Binary] = FileProcessor.TextToBinary;

            //convertedFiles = files.Where(x => x != null)  //non-null files
            //    .Select(x => convertor[x.ConvertMode].Invoke(x.FileObj)) // select method based on enum and execute it
            //    .ToList(); // convert it to list



                if (file != null)
                {
                    FileDTO fileToAdd = file.FileObj;
                    switch (file.ConvertMode)
                    {
                        case Enums.ConvertType.Json:
                            convertedFile = FileProcessor.TextFileToJson(fileToAdd);
                            break;
                        case Enums.ConvertType.Binary:
                            convertedFile = FileProcessor.TextToBinary(fileToAdd);
                            break;
                    }
                
               }
            

            return convertedFile;
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
