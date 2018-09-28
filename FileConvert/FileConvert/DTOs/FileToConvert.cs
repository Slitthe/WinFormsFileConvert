using FileConvert.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvert.DTOs
{
    public class FileToConvert
    {
        public FileDTO file { get; set; }
        public ConvertType ConvertMode { get; set; }
    }
}
