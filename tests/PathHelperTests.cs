using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeodeInstaller.Tests
{
    [TestClass]
    public class PathHelperTests
    {
        [TestMethod]
        public void SanitizePath_RemovesQuotes()
        {
            string input = "\"C:/Program Files/GD\"";
            string result = PathHelper.SanitizePath(input);
            Assert.IsFalse(result.Contains("\""));
        }

        [TestMethod]
        public void IsValidGDPath_ReturnsFalseForNull()
        {
            Assert.IsFalse(PathHelper.IsValidGDPath(null));
            Assert.IsFalse(PathHelper.IsValidGDPath(""));
        }
    }
}