# Простой .net-логгер

## Пример использования:  
> Log log = new Log();  
> log.Targets.Add(new Target(LogLevel.Trace, message => Console.WriteLine(message)));  
> log.Error("Ошибка чтения файла!");