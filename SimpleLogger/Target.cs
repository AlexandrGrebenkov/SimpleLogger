using System;

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
        public Action<object> write;
    }
}
