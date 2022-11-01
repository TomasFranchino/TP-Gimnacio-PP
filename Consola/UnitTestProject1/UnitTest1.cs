using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]

    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            miClase UnaClase = new miClase();

            int unVale = UnaClase.MiClase(2, 3);
            
            Assert.AreEqual(unVale, -1);

            
        }
    }
}
