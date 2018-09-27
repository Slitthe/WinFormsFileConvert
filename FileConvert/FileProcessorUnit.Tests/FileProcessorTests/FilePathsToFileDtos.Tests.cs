using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileConvert;
using FileConvert.DTOs;

namespace FileProcessorUnit.Tests
{
    [TestClass]
    public class FilePathsToFileDTOs
    {
        [TestMethod]
        public void ConvertFilePathsToFileDTOs_WithValidData()
        {

            string fullFilePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileTwo.html";


            string result =  FileConvertors.getFullFileName(fullFilePath);

            string expected = "fileTwo.html";

            Assert.AreEqual(expected, result);
        }

    }
}
