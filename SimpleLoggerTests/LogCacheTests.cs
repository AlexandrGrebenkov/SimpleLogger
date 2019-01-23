using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleLogger;

namespace SimpleLoggerTests
{
    [TestClass]
    public class LogCacheTests
    {
        [TestMethod]
        public void TraceThenErrorTest()
        {
            Log log = new Log();
            var settings = new TargetSettings()
            {
                EnableCache = true,
                CacheMinLevel = LogLevel.Trace,
                CacheSize = 2,
                WriteCacheLevel = LogLevel.Error
            };
            log.Targets.Add(new Target(LogLevel.Error, message => Console.WriteLine(message), settings));

            log.Trace("Trace 1");
            log.Trace("Trace 2");
            log.Trace("Trace 3");
            log.Trace("Trace 4");
            log.Trace("Trace 5");
            log.Error("Error!");

            Assert.IsFalse(false);
        }

        [TestMethod]
        public void TraceThenErrorWithInfoTest()
        {
            Log log = new Log();
            var settings = new TargetSettings()
            {
                EnableCache = true,
                CacheMinLevel = LogLevel.Trace,
                CacheSize = 4,
                WriteCacheLevel = LogLevel.Error
            };
            log.Targets.Add(new Target(LogLevel.Info, message => Console.WriteLine(message), settings));

            log.Trace("Trace 1");
            log.Trace("Trace 2");
            log.Trace("Trace 3");
            log.Trace("Trace 4");
            log.Info("Info");
            log.Trace("Trace 5");
            log.Error("Error!");

            Assert.IsFalse(false);
        }

        [TestMethod]
        public void ErrorWithoutTraceTest()
        {
            Log log = new Log();
            var settings = new TargetSettings()
            {
                EnableCache = true,
                CacheMinLevel = LogLevel.Trace,
                CacheSize = 4,
                WriteCacheLevel = LogLevel.Error
            };
            log.Targets.Add(new Target(LogLevel.Info, message => Console.WriteLine(message), settings));

            log.Error("Error!");

            Assert.IsFalse(false);
        }

        [TestMethod]
        public void TraceThen2ErrorTest()
        {
            Log log = new Log();
            var settings = new TargetSettings()
            {
                EnableCache = true,
                CacheMinLevel = LogLevel.Trace,
                CacheSize = 4,
                WriteCacheLevel = LogLevel.Error
            };
            log.Targets.Add(new Target(LogLevel.Info, message => Console.WriteLine(message), settings));

            log.Trace("Trace 1");
            log.Trace("Trace 2");
            log.Trace("Trace 3");
            log.Trace("Trace 4");
            log.Trace("Trace 5");
            log.Error("Error!");
            log.Trace("Trace 6");
            log.Error("Error!");

            Assert.IsFalse(false);
        }
    }
}
