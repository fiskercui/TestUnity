namespace WeihuaGames.ClientClass
{
    using System;
    using System.Collections.Generic;

    public class ClientDynamicValueData
    {
        private Dictionary<string, object> dynamicValues = new Dictionary<string, object>();

        public void AddDynamicValue(string key, object value)
        {
            if (this.dynamicValues.ContainsKey(key))
            {
                this.dynamicValues[key] = value;
            }
            else
            {
                this.dynamicValues.Add(key, value);
            }
        }

        public bool ContainerValue(string key)
        {
            return this.dynamicValues.ContainsKey(key);
        }

        public object GetValue(string key)
        {
            return this.dynamicValues[key];
        }

        public void RemoveDynamicValue(string key)
        {
            if (this.dynamicValues.ContainsKey(key))
            {
                this.dynamicValues.Remove(key);
            }
        }
    }
}

