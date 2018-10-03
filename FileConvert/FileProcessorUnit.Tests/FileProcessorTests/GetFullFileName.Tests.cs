using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileConvert;
using FileConvert.DTOs;
using FileConvert.Services;

namespace FileProcessorUnit.Tests
{
    [TestClass]
    public class GetFullFileName
    {
        [TestMethod]
        public void WithSimplePathAndFileName()
        {
            string fullFilePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileTwo.html";


            string result = FileNameHelpers.GetFullFileName(fullFilePath);

            string expected = "fileTwo.html";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WithMultipleDotsInFileName()
        {
            string fullFilePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileTwo.something.html";


            string result = FileNameHelpers.GetFullFileName(fullFilePath);

            string expected = "fileTwo.something.html";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WithNoFileExtension()
        {
            string fullFilePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileTwo";


            string result = FileNameHelpers.GetFullFileName(fullFilePath);

            string expected = "fileTwo";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WithNoFileInPath()
        {
            string fullFilePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\";


            string result = FileNameHelpers.GetFullFileName(fullFilePath);

            string expected = "";

            Assert.AreEqual(expected, result);
        }

    }
}
