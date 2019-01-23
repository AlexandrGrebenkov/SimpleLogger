using System.Collections.Generic;

namespace SimpleLogger
{    
    /// <summary> Логгер </summary>
    public class Log
    {
        /// <summary>Список мест, куда и как писать лог</summary>
        public List<Target> Targets = new List<Target>();

        /// <summary>логирование сообщений о критических ошибках(только критические сообщения)</summary>
        public void Fatal(object message) => WriteLog(message, LogLevel.Fatal);
        /// <summary>логирование сообщений об ошибках</summary>
        public void Error(object message) => WriteLog(message, LogLevel.Error);
        /// <summary>логирование сообщений о предупреждениях</summary>
        public void Warning(object message) => WriteLog(message, LogLevel.Warning);
        /// <summary>логирование информационных сообщений</summary>
        public void Info(object message) => WriteLog(message, LogLevel.Info);
        /// <summary>отладочное логирование, менее детально чем Trace</summary>
        public void Debug(object message) => WriteLog(message, LogLevel.Debug);
        /// <summary>детальное логирование (все сообщения)</summary>
        public void Trace(object message) => WriteLog(message, LogLevel.Trace);

        void WriteLog(object message, LogLevel level)
        {
            foreach (var target in Targets)
            {
                if (target.LogLevel >= level)
                    target.write($"{level} - {message}");
            }
        }
    }
}
