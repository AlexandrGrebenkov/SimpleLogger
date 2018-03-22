using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Tests
{
    [TestClass()]
    public class LogManagerTests
    {
        [TestMethod()]
        public void GetLogTest()
        {
            var targets = new List<Target>();
            targets.Add(new Target { LogLevel = LogLevel.Trace, write = message => Console.WriteLine($"{DateTime.Now}: {message}") });
            LogManager.Init(targets);

            var log = LogManager.GetLog();
            Assert.IsNotNull(log);
            log.Info("Проверка");
        }
    }
}