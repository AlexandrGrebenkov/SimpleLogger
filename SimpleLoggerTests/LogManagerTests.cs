using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SimpleLogger.Tests
{
    [TestClass()]
    public class LogManagerTests
    {
        [TestMethod()]
        public void GetLogTest()
        {
            var targets = new List<Target>();
            targets.Add(new Target(LogLevel.Trace, message => Console.WriteLine($"{DateTime.Now}: {message}")));
            LogManager.Init(targets);

            var log = LogManager.GetLog();
            Assert.IsNotNull(log);
            log.Info("Проверка");
        }
    }
}