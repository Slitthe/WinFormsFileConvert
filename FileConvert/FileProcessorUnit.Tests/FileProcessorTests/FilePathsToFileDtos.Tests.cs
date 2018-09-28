using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileConvert;
using FileConvert.DTOs;
using System.IO;
using System.Collections;

namespace FileProcessorUnit.Tests
{
    [TestClass]
    public class FilePathsToFileDTOs
    {
        [TestMethod]
        public void WithValidData()
        {
            var file1FullPath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileOne.txt";
            byte[] file1Bytes = File.ReadAllBytes(file1FullPath);

            //var file2FullPath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileTwo.html";
            //byte[] file2Bytes = File.ReadAllBytes(file2FullPath);

            var expected = new FileDTO()
            {
                Content = file1Bytes,
                FileName = "fileOne",
                FileExtension = "txt"
            };

            FileDTO actual = FileConvertors.filePathsToFileDTO(file1FullPath);

            Assert.AreEqual(true, StructuralComparisons.StructuralEqualityComparer.Equals(expected.Content, actual.Content));
            Assert.AreEqual(expected.FileExtension, actual.FileExtension);
            Assert.AreEqual(expected.FileName, actual.FileName);
            
        }

        [TestMethod]
        public void WithInvalidPath()
        {
            var file1CorrectFullPath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileOne.txt";
            var file1WrongFullPath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\filne.txt";

            byte[] file1Bytes = File.ReadAllBytes(file1CorrectFullPath);

            //var file2FullPath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileTwo.html";
            //byte[] file2Bytes = File.ReadAllBytes(file2FullPath);

            FileDTO expected = null;

            FileDTO actual = FileConvertors.filePathsToFileDTO(file1WrongFullPath);

            Assert.AreEqual(expected, actual);

        }


    }
    
}
