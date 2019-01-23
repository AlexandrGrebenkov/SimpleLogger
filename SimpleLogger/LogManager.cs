using System.Collections.Generic;

namespace SimpleLogger
{
    /// <summary>
    /// Менеджер работы с логами<para/>
    /// Init - создаёт статический лог. GetLog - возвращает созданный ранее лог
    /// </summary>
    public static class LogManager
    {
        static Log Log;
        /// <summary>Создание лога</summary>
        /// <param name="Targets">Куда и как писать лог</param>
        public static void Init(List<Target> Targets)
        {
            Log = new Log();
            Log.Targets = Targets;
        }
        /// <summary>
        /// Запрос лога. Перед вызовом необходимо проинициализировать лог(LogManager.Init(targets))
        /// </summary>
        /// <returns></returns>
        public static Log GetLog()
        {
            return Log;
        }
    }
}
