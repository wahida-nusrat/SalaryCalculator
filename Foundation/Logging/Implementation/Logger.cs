using log4net;
using Logging.Interface;
namespace Logging.Implementation
{
    public class Logger : Ilogger
    {
        private static readonly ILog  log = LogManager.GetLogger(typeof(Logger));
        
        public Logger()
        {
            LoggingConfigure.Configure();
        }
        public void Error(string message)
        {
            log.Error(message);
        }

        public void Info(string message)
        {
            log.Info(message);
        }
        public void Warn(string message)
        {
            log.Warn(message);
        }
        public  void Debug(string message) 
        {
            log.Debug(message);
        }

    }
}
