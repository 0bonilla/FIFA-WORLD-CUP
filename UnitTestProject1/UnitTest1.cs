using Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VectorToStringOk()
        {
            int x = 2;
            int y = 3;

            var vector = new Vector2(x, y);
            var resultado = vector.ToString();

            var resultadoEsperado = $"X : {x} / Y : {y}";

            Assert.AreEqual(resultado, resultadoEsperado);
        }
    }
}
