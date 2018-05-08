using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Attributes;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //var str = "{\"sfzh\":\"abc\", \"xm\": \"gavin\"}";
            var str = "{\"end\":\"100\",\"isone\":\"0\",\"start\":\"1\",\"xh\":\"1\"}";
            var encryptedStr = CustomMessageHandler.Encrypt(str);
            var decryptedStr = CustomMessageHandler.Decrypt(encryptedStr);
            Assert.AreEqual(str, decryptedStr);
        }
    }
}
