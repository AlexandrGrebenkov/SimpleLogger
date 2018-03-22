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
    public class LogTests
    {
        [TestMethod()]
        public void FatalTest()
        {
            Log log = new Log();
            log.Targets.Add(new Target { LogLevel = LogLevel.Trace, write = message => Console.WriteLine($"{DateTime.Now}: {message}") });
            log.Targets.Add(new Target { LogLevel = LogLevel.Fatal, write = message => Console.WriteLine(message) });

            log.Fatal("Fatal");
            log.Fatal(15);
            Assert.IsFalse(false);
        }

        [TestMethod()]
        public void FatalTest_Null_Input()
        {
            Log log = new Log();
            log.Targets.Add(new Target { LogLevel = LogLevel.Trace, write = message => Console.WriteLine($"{DateTime.Now}: {message}") });

            log.Fatal(null);

            Assert.IsFalse(false);
        }

        [TestMethod()]
        public void FatalTest_Empty_Input()
        {
            Log log = new Log();
            log.Targets.Add(new Target { LogLevel = LogLevel.Trace, write = message => Console.WriteLine($"{DateTime.Now}: {message}") });

            log.Fatal(String.Empty);

            Assert.IsFalse(false);
        }
    }
}