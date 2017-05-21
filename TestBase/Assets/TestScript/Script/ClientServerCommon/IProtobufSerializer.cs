namespace ClientServerCommon
{
    using System;
    using System.IO;

    public interface IProtobufSerializer
    {
        object Deserialize(Stream source, Type type);
        void Serialize<T>(Stream dest, T value);
    }
}

