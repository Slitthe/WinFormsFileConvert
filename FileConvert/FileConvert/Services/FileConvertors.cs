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

            foreach(FileToConvert file in files)
            {
                switch (file.ConvertMode)
                {
                    case Enums.ConvertType.Json:
                        //file = // converted file;
                        break;
                    case Enums.ConvertType.Binary:
                        //file = // converted file;
                        break;
                }
            }

            return null;
        }
    }
}
