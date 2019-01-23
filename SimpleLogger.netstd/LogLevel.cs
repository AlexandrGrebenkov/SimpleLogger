namespace SimpleLogger
{
    /// <summary>Уровень записи</summary>
    public enum LogLevel
    {
        /// <summary>логирование сообщений не производиться</summary>
        Off,
        /// <summary>логирование сообщений о критических ошибках(только критические сообщения)</summary>
        Fatal,
        /// <summary>логирование сообщений об ошибках</summary>
        Error,
        /// <summary>логирование сообщений о предупреждениях</summary>
        Warning,
        /// <summary>логирование информационных сообщений</summary>
        Info,
        /// <summary>отладочное логирование, менее детально чем Trace</summary>
        Debug,
        /// <summary>детальное логирование (все сообщения)</summary>
        Trace,
    }
}
