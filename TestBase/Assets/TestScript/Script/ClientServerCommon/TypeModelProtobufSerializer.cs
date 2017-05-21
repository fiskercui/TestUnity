namespace ClientServerCommon
{
    using ProtoBuf.Meta;
    using System;
    using System.IO;

    internal class TypeModelProtobufSerializer : IProtobufSerializer
    {
        private TypeModel typeModelSerializer;

        public TypeModelProtobufSerializer(TypeModel typeMode)
        {
            this.typeModelSerializer = typeMode;
        }

        public object Deserialize(Stream source, Type type)
        {
            return this.typeModelSerializer.Deserialize(source, null, type);
        }

        public void Serialize<T>(Stream dest, T value)
        {
            this.typeModelSerializer.Serialize(dest, value);
        }
    }
}

