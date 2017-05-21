namespace ClientServerCommon
{
    using System;
    using System.IO;
    using System.Security;

    public interface IFileLoader
    {
        Stream LoadAsSteam(string filePath);
        SecurityElement LoadAsXML(string filePath);
    }
}

