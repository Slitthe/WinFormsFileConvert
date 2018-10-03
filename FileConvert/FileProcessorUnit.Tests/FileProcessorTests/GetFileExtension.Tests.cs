using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileConvert;
using FileConvert.DTOs;
using FileConvert.Services;

namespace FileProcessorUnit.Tests
{
    [TestClass]
    public class GetFileExtension
    {
        [TestMethod]
        public void WithSimpeFileName()
        {
            string fullFilePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileTwo.html";


            string result = FileNameHelpers.GetFileExtension(fullFilePath);

            string expected = "html";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WithMoreComplexFileName()
        {
            string fullFilePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileTwo.sometthing.else.html";

            
            string result = FileNameHelpers.GetFileExtension(fullFilePath);

            string expected = "html";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WithNoFileInPath()
        {
            string fullFilePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\";


            string result = FileNameHelpers.GetFileExtension(fullFilePath);

            string expected = "";

            Assert.AreEqual(expected, result);
        }
    }
}
