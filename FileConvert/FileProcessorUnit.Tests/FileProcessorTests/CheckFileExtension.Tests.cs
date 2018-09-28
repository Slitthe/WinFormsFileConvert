using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileConvert;
using FileConvert.DTOs;
using System.Collections.Generic;

namespace FileProcessorUnit.Tests
{
    [TestClass]
    public class CheckFileExtension
    {
        [TestMethod]
        public void WithCorrectValues()
        {
            string fileName = "something.not.actualExtension";
            string fileExtension = "actualExtension";

            bool extensionCheck = FileProcessor.CheckFileExtension(fileName, fileExtension);

            Assert.AreEqual(true, extensionCheck);
        }

        [TestMethod]
        public void WithWrongFileExtension()
        {
            string fileName = "something.not.actualExtension";
            string fileExtension = "actualExtesion";

            bool extensionCheck = FileProcessor.CheckFileExtension(fileName, fileExtension);

            Assert.AreEqual(false, extensionCheck);
        }

        [TestMethod]
        public void WithNoExtensionFile()
        {
            string fileName = "somethingnotactualExtension";
            string fileExtension = "actualExtension";

            bool extensionCheck = FileProcessor.CheckFileExtension(fileName, fileExtension);

            Assert.AreEqual(false, extensionCheck);
        }


    }
}
