namespace SimpleLogger
{
    public class TargetSettings
    {
        /// <summary>Разрешить кэширование сообщений</summary>
        public bool EnableCache = false;

        /// <summary>Количество записей кэша сообщений</summary>
        public int CacheSize = 5;

        /// <summary>Минимальный уровень кэширования</summary>
        public LogLevel CacheMinLevel = LogLevel.Trace;

        /// <summary>Порог, при котором будет выводиться кэш</summary>
        public LogLevel WriteCacheLevel = LogLevel.Error;
    }
}
