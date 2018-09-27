using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileConvert;
using FileConvert.DTOs;

namespace FileProcessorUnit.Tests
{
    [TestClass]
    public class CheckFileExtension
    {
        [TestMethod]
        public void CheckFileExtensionsWithCorrectValues()
        {
            string fileName = "something.not.actualExtension";
            string fileExtension = "actualExtension";

            bool extensionCheck = FileConvertors.checkFileExtension(fileName, fileExtension);

            Assert.AreEqual(true, extensionCheck);
        }

        [TestMethod]
        public void CheckFileExtensionWithWrongFileExtension()
        {
            string fileName = "something.not.actualExtension";
            string fileExtension = "actualExtesion";

            bool extensionCheck = FileConvertors.checkFileExtension(fileName, fileExtension);

            Assert.AreEqual(false, extensionCheck);
        }

        [TestMethod]
        public void CheckFileExtensionWithNoExtensionFile()
        {
            string fileName = "somethingnotactualExtension";
            string fileExtension = "actualExtension";

            bool extensionCheck = FileConvertors.checkFileExtension(fileName, fileExtension);

            Assert.AreEqual(false, extensionCheck);
        }
    }
}
