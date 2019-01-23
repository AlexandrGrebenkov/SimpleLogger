using System;
using System.Collections.Concurrent;

namespace SimpleLogger
{
    /// <summary>Таргет записи (Куда и как писать лог)</summary>
    public class Target
    {
        /// <summary>Порог записи. В лог пишутся записи равные и выше заданного уровня</summary>
        public LogLevel LogLevel;

        /// <summary>
        /// Метод записи. <para/>
        /// Пример: write = message => Console.WriteLine(message);
        /// </summary>
        public Action<object> Write;

        /// <summary>Настройки записи</summary>
        public TargetSettings TargetSettings;

        public Target(LogLevel logLevel, Action<object> write, TargetSettings targetSettings = null)
        {
            LogLevel = logLevel;
            Write = write;
            TargetSettings = targetSettings ?? new TargetSettings();
        }

        ConcurrentQueue<object> cache = new ConcurrentQueue<object>();

        void AddToCache(object obj)
        {
            if (!TargetSettings.EnableCache) return;

            cache.Enqueue(obj);
            if (cache.Count > TargetSettings.CacheSize)
            {
                bool result;
                do
                {
                    result = cache.TryDequeue(out object old);
                } while (!result);
            }
        }

        void WriteCache()
        {
            bool result;
            while (cache.Count != 0)
            {
                do
                {
                    result = cache.TryDequeue(out object old);
                    Write(old);
                } while (!result);
            }
        }

        public void AddMessage(object obj, LogLevel level)
        {
            var message = $"{DateTime.Now}: {level} - {obj}";

            if (TargetSettings.EnableCache && level <= TargetSettings.WriteCacheLevel) // Порог отображения записей кэша           
                WriteCache();

            if (level <= LogLevel)
                Write(message);
            else
                AddToCache(message);
        }
    }
}
