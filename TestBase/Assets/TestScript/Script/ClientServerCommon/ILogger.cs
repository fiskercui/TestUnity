namespace ClientServerCommon
{
    using System;

    public interface ILogger
    {
        void Debug(object msg);
        void Debug(string format, params object[] args);
        void Error(object msg);
        void Error(string format, params object[] args);
        void Info(object msg);
        void Info(string format, params object[] args);
        void Warn(object msg);
        void Warn(string format, params object[] args);
    }
}

