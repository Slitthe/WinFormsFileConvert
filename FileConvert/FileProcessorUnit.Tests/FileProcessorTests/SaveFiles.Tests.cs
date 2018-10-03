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
    public class SaveFiles
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

            string file2Extension = "txt";
            string file2Name = "unitTestExample2";
            string file2AsString = "I am a another string and nothing more";
            byte[] file2AsArrayOfBytes = Encoding.Default.GetBytes(file2AsString);

            var file2Dto = new FileDTO()
            {
                FileName = file2Name,
                FileExtension = file2Extension,
                Content = file2AsArrayOfBytes
            };

            List<FileDTO> dummyFilesList = new List<FileDTO>() { file1Dto, file2Dto };


            FileConvertors.SaveFiles(dummyFilesList, outputDirectory, true);

            var file1Info = new FileInfo(@"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\SaveFiles\" + file1Name + "." + file1Extension);
            var file2Info = new FileInfo(@"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\SaveFiles\" + file2Name + "." + file2Extension);
            try
            {
                Assert.AreEqual(file1Info.Exists && file2Info.Exists, true);
            }
            finally
            {
                File.Delete(@"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\SaveFiles\" + file1Name + "." + file1Extension);
                File.Delete(@"C: \Users\silviu.gherman\Desktop\DirectoryForUnitTests\SaveFiles\" + file2Name + "." + file2Extension);
            }

        }

        [TestMethod]
        public void WithSomeNullValuesAsDtos()
        {
            string outputDirectory = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\SaveFiles";


            string file2Extension = "txt";
            string file2Name = "singleNonNullFile";
            string file2AsString = "I am a another string and nothing more";
            byte[] file2AsArrayOfBytes = Encoding.Default.GetBytes(file2AsString);

            var file2Dto = new FileDTO()
            {
                FileName = file2Name,
                FileExtension = file2Extension,
                Content = file2AsArrayOfBytes
            };

            List<FileDTO> dummyFilesList = new List<FileDTO>() { file2Dto, null };


            FileConvertors.SaveFiles(dummyFilesList, outputDirectory, true);

            var file2Info = new FileInfo(@"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\SaveFiles\" + file2Name + "." + file2Extension);
            try
            {
                Assert.AreEqual(file2Info.Exists, true);
            }
            finally
            {

                File.Delete(@"C: \Users\silviu.gherman\Desktop\DirectoryForUnitTests\SaveFiles\" + file2Name + "." + file2Extension);
            }


        }

    }
}
