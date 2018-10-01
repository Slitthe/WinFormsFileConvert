using FileConvert.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvert.DTOs
{
    public class FileToConvertDTO
    {
        public FileDTO FileObj { get; set; }
        public ConvertType ConvertMode { get; set; }
    }
}
