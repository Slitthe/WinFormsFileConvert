﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileConvert;
using FileConvert.DTOs;

namespace FileProcessorUnit.Tests
{
    [TestClass]
    public class GetFileExtension
    {
        [TestMethod]
        public void GetFileExtensionWithSimpeFileName()
        {
            string fullFilePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileTwo.html";


            string result =  FileConvertors.getFileExtension(fullFilePath);

            string expected = "html";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetFileExtensionWithMoreComplexFileName()
        {
            string fullFilePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\fileTwo.sometthing.else.html";

            
            string result = FileConvertors.getFileExtension(fullFilePath);

            string expected = "html";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetFileExtensionWithNoFileInPath()
        {
            string fullFilePath = @"C:\Users\silviu.gherman\Desktop\DirectoryForUnitTests\";


            string result = FileConvertors.getFileExtension(fullFilePath);

            string expected = "";

            Assert.AreEqual(expected, result);
        }
    }
}
