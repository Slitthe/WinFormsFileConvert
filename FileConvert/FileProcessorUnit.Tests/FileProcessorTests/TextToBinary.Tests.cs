using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileConvert;
using FileConvert.DTOs;
using System.Text;
using System.IO;

namespace FileProcessorUnit.Tests
{
    [TestClass]
    public class TextToBinary
    {
        [TestMethod]
        public void WithCorrectFile()
        {
            
            // Test data
            string file1Extension = "txt";
            string file1Name = "unitTestExample1";
            string expectedString = "I am a string and nothing more";

            byte[] file1AsArrayOfBytes = Encoding.Default.GetBytes(expectedString);
            FileDTO file1Dto = new FileDTO()
            {
                FileName = file1Name,
                FileExtension = file1Extension,
                Content = file1AsArrayOfBytes
            };

            // Convert
            FileDTO fileAsBinary = FileProcessor.TextToBinary(file1Dto);
            byte[] file1 = fileAsBinary.Content;
            
            MemoryStream memoryStream = new MemoryStream();
            BinaryReader binReader = new BinaryReader(memoryStream);

            memoryStream.Write(file1, 0, file1.Length);
            memoryStream.Position = 0;

            string resultString = binReader.ReadString();

            memoryStream.Close();
            binReader.Close();


            // Assert
            Assert.AreEqual(expectedString, resultString);

        }

    }
}
