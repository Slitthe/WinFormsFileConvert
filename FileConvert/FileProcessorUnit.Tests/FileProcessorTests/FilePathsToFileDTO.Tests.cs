using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileConvert;
using FileConvert.DTOs;
using System.IO;
using System.Collections;
using FileConvert.Services;

namespace FileProcessorUnit.Tests
{
    [TestClass]
    public class FilePathsToFileDto
    {
        [TestMethod]
        public void WithValidData()
        {
            var file1FullPath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileOne.txt";
            byte[] file1Bytes = File.ReadAllBytes(file1FullPath);

            var expected = new FileDto()
            {
                Content = file1Bytes,
                FileName = "fileOne",
                FileExtension = "txt"
            };

            FileDto actual = FileConvertors.FilePathsToFileDto(file1FullPath);

            Assert.AreEqual(true, StructuralComparisons.StructuralEqualityComparer.Equals(expected.Content, actual.Content));
            Assert.AreEqual(expected.FileExtension, actual.FileExtension);
            Assert.AreEqual(expected.FileName, actual.FileName);
            
        }

        [TestMethod]
        public void WithInvalidPath()
        {
            var file1WrongFullPath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\filne.txt";

            FileDto expected = null;

            FileDto actual = FileConvertors.FilePathsToFileDto(file1WrongFullPath);

            Assert.AreEqual(expected, actual);

        }


    }
    
}
