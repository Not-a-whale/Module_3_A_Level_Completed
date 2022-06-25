using Module_3_App.Classes;
using Module_3_App.Services;

Logger logger = new Logger();
Starter starter = new Starter();
logger.Notify += starter.WriteToFile;
await logger.PrintAsync();
await logger.PrintAsyncSecond();
