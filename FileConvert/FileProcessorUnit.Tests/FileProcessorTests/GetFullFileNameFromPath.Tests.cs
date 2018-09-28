using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileConvert;
using FileConvert.DTOs;

namespace FileProcessorUnit.Tests
{
    [TestClass]
    public class GetFullFileNameFromPath
    {
        [TestMethod]
        public void WithSimplePathAndFileName()
        {
            string fullFilePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileTwo.html";


            string result =  FileConvertors.getFullFileName(fullFilePath);

            string expected = "fileTwo.html";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WithMultipleDotsInFileName()
        {
            string fullFilePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileTwo.something.html";


            string result = FileConvertors.getFullFileName(fullFilePath);

            string expected = "fileTwo.something.html";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WithNoFileExtension()
        {
            string fullFilePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileTwo";


            string result = FileConvertors.getFullFileName(fullFilePath);

            string expected = "fileTwo";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WithNoFileInPath()
        {
            string fullFilePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\";


            string result = FileConvertors.getFullFileName(fullFilePath);

            string expected = "";

            Assert.AreEqual(expected, result);
        }

    }
}
