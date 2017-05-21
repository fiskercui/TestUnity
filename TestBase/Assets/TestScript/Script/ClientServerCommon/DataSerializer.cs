namespace ClientServerCommon
{
    using System;
    using System.IO;

    internal class DataSerializer
    {
        private static IProtobufSerializer protobufSerializer;

        public static object Deserialize(Stream stream, Type type)
        {
            if (protobufSerializer != null)
            {
                return protobufSerializer.Deserialize(stream, type);
            }
            return null;
        }

        public static void Initialize(bool useTypeMode)
        {
            if (useTypeMode)
            {
                

                //protobufSerializer = new TypeModelProtobufSerializer(new ClientCommon_c());
            }
            else
            {
                protobufSerializer = new MetaDataProtobufSerializer();
            }
        }

        public static void Serialize<T>(Stream stream, T value)
        {
            if (protobufSerializer != null)
            {
                protobufSerializer.Serialize<T>(stream, value);
            }
        }
    }
}

