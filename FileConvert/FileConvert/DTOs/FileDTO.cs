using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConvert.DTOs
{
    public class FileDto
    {
        public string FileExtension { get; set; }
        public string FileName { get; set; }
        public byte[] Content { get; set; }
    }
}
