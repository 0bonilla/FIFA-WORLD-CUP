using Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        
        public void GetScore()
        {
            int scoreA = 2;
            Level level = new Level();
            var expectedScore = level.scoreArg + scoreA;
            level.Score();
            var actualScore = level.scoreArg;
            Assert.AreEqual(expectedScore, actualScore);
        }
    }
}
