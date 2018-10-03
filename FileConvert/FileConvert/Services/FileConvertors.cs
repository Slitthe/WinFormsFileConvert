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
using FileConvert.Services;

namespace FileConvert
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
            //convertor[Enums.ConvertType.Json] = FileConvertors.TextFileToJson;
            //convertor[Enums.ConvertType.Binary] = FileConvertors.TextToBinary;

            //convertedFiles = files.Where(x => x != null)  //non-null files
            //    .Select(x => convertor[x.ConvertMode].Invoke(x.FileObj)) // select method based on enum and execute it
            //    .ToList(); // convert it to list




            FileDTO fileToAdd = file.FileObj;
            switch (file.ConvertMode)
            {
                case Enums.ConvertType.Json:
                    convertedFile = TextFileToJson(fileToAdd);
                    break;
                case Enums.ConvertType.Binary:
                    convertedFile = TextToBinary(fileToAdd);
                break;
            }

            return convertedFile;
        }
        public static FileDTO TextToBinary(FileDTO file)
        {
            var convertedFile = file;

            if (file.FileExtension == "txt")
            {
                
                string fileText = Encoding.UTF8.GetString(file.Content);

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
        public static FileDTO FilePathsToFileDTO(string fullFilePath)
        {
            var filePathList = new List<string>() { fullFilePath };
            bool fileExists = FileNameHelpers.FilesExistenceChecker(filePathList);

            FileDTO fileDto = null;
            if(fileExists)
            {
                fileDto = new FileDTO();
                fileDto.Content = File.ReadAllBytes(fullFilePath);
                fileDto.FileExtension = FileNameHelpers.GetFileExtension(fullFilePath);
                fileDto.FileName = FileNameHelpers.GetFileName(fullFilePath);

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


        
        
    }
}
