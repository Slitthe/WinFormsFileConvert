using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileConvert;
using FileConvert.DTOs;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace FileProcessorUnit.Tests
{
    [TestClass]
    public class TextFilesToJsonConvert
    {
        [TestMethod]
        public void WithExpectedValues()
        {
            string outputDirectory = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\SaveFiles";

            string file1Extension = "txt";
            string file1Name = "unitTestExample1";
            string file1AsString = "I am a string and nothing more";
            byte[] file1AsArrayOfBytes = Encoding.Default.GetBytes(file1AsString);

            var file1Dto = new FileDTO()
            {
                FileName = file1Name,
                FileExtension = file1Extension,
                Content = file1AsArrayOfBytes
            };

            var file1AsJson = FileConvertors.TextFileToJson(file1Dto);

            var file1JsonText = Encoding.Default.GetString(file1AsJson.Content);


        }

        

    }
}
