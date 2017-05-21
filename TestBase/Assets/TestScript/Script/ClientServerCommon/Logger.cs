namespace ClientServerCommon
{
    using System;

    internal class Logger
    {
        public static void Debug(object msg)
        {
            LoggerManager.Instance.Debug(msg);
        }

        public static void Debug(string format, params object[] args)
        {
            LoggerManager.Instance.Debug(format, args);
        }

        public static void Error(object msg)
        {
            LoggerManager.Instance.Error(msg);
        }

        public static void Error(string format, params object[] args)
        {
            LoggerManager.Instance.Error(format, args);
        }

        public static void Info(object msg)
        {
            LoggerManager.Instance.Info(msg);
        }

        public static void Info(string format, params object[] args)
        {
            LoggerManager.Instance.Info(format, args);
        }

        public static void Warn(object msg)
        {
            LoggerManager.Instance.Warn(msg);
        }

        public static void Warn(string format, params object[] args)
        {
            LoggerManager.Instance.Warn(format, args);
        }
    }
}

