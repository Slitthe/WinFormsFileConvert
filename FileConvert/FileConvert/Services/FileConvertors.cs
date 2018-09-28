using FileConvert.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvert.Services
{
    public static class FileConvertors
    {
        public static IList<FileDTO> ConvertFiles(IList<FileToConvert> files)
        {
            List<FileDTO> convertedFiles = new List<FileDTO>();

            for(int i = 0; i < files.Count; i++)
            {
                FileDTO fileToAdd = files[i].file;

                switch (files[i].ConvertMode)
                {
                    case Enums.ConvertType.Json:
                        fileToAdd = FileProcessor.TextFileToJson(fileToAdd);
                        break;
                    case Enums.ConvertType.Binary:
                        fileToAdd = FileProcessor.TextToBinary(fileToAdd);
                        break;
                }

                convertedFiles.Add(files[i].file);
            }

            return null;
        }
    }
}
