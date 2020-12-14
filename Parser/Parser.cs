using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace Parser
{
     public abstract class Parser
    {
        protected string path;
        public Parser(string path)
        {
            this.path = path;
        }
        public abstract T Get<T>() where T : new();
         public T DeserializeObject<T>(List<ParserObject> objects) where T: new()
        {
            T instance = (T)Activator.CreateInstance(typeof(T));

            foreach(var obj in (objects))
            {
                var property = typeof(T).GetProperty(obj.Name);
                if(obj.Type == ParserObject.ParserObjectType.Simple)
                { 
                        property.SetValue(instance, Convert.ChangeType(obj.Value, property.PropertyType));
                }
                else
                {
                    var type = property.PropertyType;
                    var method = typeof(Parser).GetMethod(nameof(DeserializeObject));
                    property.SetValue(instance, method.MakeGenericMethod(type).Invoke(this,parameters: new object[] { obj.Value }));
                }
            }
            return instance;
        }
        abstract public List<ParserObject> Split(string str);
        abstract public ParserObject Parse(string str);
        protected bool IsNumber(string str)
        {
            foreach (var c in str)
                if (c < '0' || c > '9')
                    return false;
            return true;
        }
        

    };
}
