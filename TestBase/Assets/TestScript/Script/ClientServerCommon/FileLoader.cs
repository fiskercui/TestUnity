namespace ClientServerCommon
{

    using System;
    using System.IO;
    using System.Security;
    using Mono.Xml;


    public class FileLoader : IFileLoader
    {
        public Stream LoadAsSteam(string filePath)
        {
            return File.Open(filePath, FileMode.Open);
        }

        public SecurityElement LoadAsXML(string filePath)
        {
            StreamReader reader = File.OpenText(filePath);
            if (reader == null)
            {
                throw new Exception("Can not open file : " + filePath);
            }
            SecurityParser parser = new SecurityParser();
            parser.LoadXml(reader.ReadToEnd());
            reader.Close();
            return parser.ToXml();
        }
    }
}

