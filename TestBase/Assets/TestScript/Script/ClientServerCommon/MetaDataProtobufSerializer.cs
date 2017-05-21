namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.IO;

    public class MetaDataProtobufSerializer : IProtobufSerializer
    {
        public object Deserialize(Stream source, Type type)
        {
            return Serializer.NonGeneric.Deserialize(type, source);
        }

        public void Serialize<T>(Stream dest, T value)
        {
            Serializer.Serialize<T>(dest, value);
        }
    }
}

