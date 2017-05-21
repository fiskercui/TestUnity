namespace ClientServerCommon
{
    using System;
    using System.Collections.Generic;

    public class TypeNameContainer<Type>
    {
        private static Dictionary<string, KeyValuePair<int, string>> container;
        private static string textSectionName;
        private static List<int> types;

        static TypeNameContainer()
        {
            TypeNameContainer<Type>.textSectionName = "Enum_Block";
            TypeNameContainer<Type>.types = new List<int>();
            TypeNameContainer<Type>.container = new Dictionary<string, KeyValuePair<int, string>>();
        }

        public static string GetDisplayNameByType(int type, ConfigDatabase cfgDB)
        {
            if (cfgDB.StringsConfig != null)
            {
                foreach (KeyValuePair<string, KeyValuePair<int, string>> pair in TypeNameContainer<Type>.container)
                {
                    if (pair.Value.Key == type)
                    {
                        return cfgDB.StringsConfig.GetString(TypeNameContainer<Type>.textSectionName, pair.Value.Value);
                    }
                }
            }
            return "";
        }

        public static string GetNameByType(int type)
        {
            foreach (KeyValuePair<string, KeyValuePair<int, string>> pair in TypeNameContainer<Type>.container)
            {
                if (pair.Value.Key == type)
                {
                    return pair.Key;
                }
            }
            return "";
        }

        public static int GetRegisterTypeByIndex(int idx)
        {
            return TypeNameContainer<Type>.types[idx];
        }

        public static int GetRegisterTypeCount()
        {
            return TypeNameContainer<Type>.types.Count;
        }

        public static int GetTypeByName(string name)
        {
            if (!TypeNameContainer<Type>.container.ContainsKey(name))
            {
                return 0;
            }
            KeyValuePair<int, string> pair = TypeNameContainer<Type>.container[name];
            return pair.Key;
        }

        public static bool IsValidType(string name)
        {
            return TypeNameContainer<Type>.container.ContainsKey(name);
        }

        public static int Parse(string typeName, int defValue)
        {
            if ((typeName == null) || (typeName == ""))
            {
                return defValue;
            }
            if (!TypeNameContainer<Type>.IsValidType(typeName))
            {
                Logger.Error(string.Format("Invalid Type {0} in {1}", typeName, typeof(Type)), new object[0]);
                return defValue;
            }
            return TypeNameContainer<Type>.GetTypeByName(typeName);
        }

        public static int ParseBitList(string typeNameList, int defValue)
        {
            if ((typeNameList == null) || (typeNameList == ""))
            {
                return defValue;
            }
            int num = 0;
            foreach (string str in typeNameList.Split(new char[] { ',' }))
            {
                num |= TypeNameContainer<Type>.Parse(str, defValue);
            }
            return num;
        }

        public static List<int> ParseList(string typeNameList, int defValue)
        {
            if (typeNameList == null)
            {
                return new List<int>();
            }
            string[] strArray = typeNameList.Split(new char[] { ',' });
            List<int> list = new List<int>();
            foreach (string str in strArray)
            {
                list.Add(TypeNameContainer<Type>.Parse(str, defValue));
            }
            return list;
        }

        protected static bool RegisterType(string typeName, int type)
        {
            return TypeNameContainer<Type>.RegisterType(typeName, type, typeName);
        }

        protected static bool RegisterType(string typeName, int type, string displayName)
        {
            if (TypeNameContainer<Type>.container.ContainsKey(typeName))
            {
                Logger.Error(string.Format("Invalid Type {0} in {1}", typeName, typeof(Type)), new object[0]);
                return false;
            }
            TypeNameContainer<Type>.types.Add(type);
            TypeNameContainer<Type>.container.Add(typeName, new KeyValuePair<int, string>(type, displayName));
            return true;
        }

        protected static void SetTextSectionName(string name)
        {
            TypeNameContainer<Type>.textSectionName = name;
        }
    }
}

