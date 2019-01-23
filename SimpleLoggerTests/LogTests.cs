using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SimpleLogger.Tests
{
    [TestClass()]
    public class LogTests
    {
        [TestMethod()]
        public void FatalTest()
        {
            Log log = new Log();
            log.Targets.Add(new Target(LogLevel.Trace, message => Console.WriteLine(message)));
            log.Targets.Add(new Target(LogLevel.Fatal, message => Console.WriteLine(message)));

            log.Fatal("Fatal");
            log.Fatal(15);
            Assert.IsFalse(false);
        }

        [TestMethod()]
        public void FatalTest_Null_Input()
        {
            Log log = new Log();
            log.Targets.Add(new Target(LogLevel.Trace, message => Console.WriteLine(message)));

            log.Fatal(null);

            Assert.IsFalse(false);
        }

        [TestMethod()]
        public void FatalTest_Empty_Input()
        {
            Log log = new Log();
            log.Targets.Add(new Target(LogLevel.Trace, message => Console.WriteLine(message)));

            log.Fatal(string.Empty);

            Assert.IsFalse(false);
        }
    }
}