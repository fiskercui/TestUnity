namespace ClientServerCommon
{
    using System;
    using System.Collections.Generic;

    internal class LoggerManager
    {
        private static LoggerManager instance;
        private List<ILogger> loggers = new List<ILogger>();

        public void AddLogger(ILogger logger)
        {
            if (!this.loggers.Contains(logger))
            {
                this.loggers.Add(logger);
            }
        }

        public void Debug(object msg)
        {
            foreach (ILogger logger in this.loggers)
            {
                logger.Debug(msg);
            }
        }

        public void Debug(string format, params object[] args)
        {
            foreach (ILogger logger in this.loggers)
            {
                logger.Debug(format, args);
            }
        }

        public void Error(object msg)
        {
            foreach (ILogger logger in this.loggers)
            {
                logger.Error(msg);
            }
        }

        public void Error(string format, params object[] args)
        {
            foreach (ILogger logger in this.loggers)
            {
                logger.Error(format, args);
            }
        }

        public void Info(object msg)
        {
            foreach (ILogger logger in this.loggers)
            {
                logger.Info(msg);
            }
        }

        public void Info(string format, params object[] args)
        {
            foreach (ILogger logger in this.loggers)
            {
                logger.Info(format, args);
            }
        }

        public void RemoveLogger(ILogger logger)
        {
            this.loggers.Remove(logger);
        }

        public void Warn(object msg)
        {
            foreach (ILogger logger in this.loggers)
            {
                logger.Warn(msg);
            }
        }

        public void Warn(string format, params object[] args)
        {
            foreach (ILogger logger in this.loggers)
            {
                logger.Warn(format, args);
            }
        }

        public static LoggerManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoggerManager();
                }
                return instance;
            }
        }
    }
}

