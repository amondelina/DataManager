using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Parser
{
    public class JSONParser : Parser
    {
        
        public JSONParser(string path):base(path)
        { }

        override public T Get<T>() 
        {
            var text = File.ReadAllText(path).Trim();
            if (text[0] != '{' || text[text.Length - 1] != '}')
                throw new Exception();
            text = text.Substring(1, text.Length - 2).Trim();

            return DeserializeObject<T>(Split(text));
            


        }
        public override ParserObject Parse(string str)
        {
            var obj = new ParserObject();
            int i = 1;
            while(str[i] != '"')
            {
                i++;
            }
            obj.Name = str.Substring(1, i - 1);
            i++;
            while (str[i] == ' ' || str[i] == ':')
                i++;
            var oc = str[i];
            char cc = (char)0;
            if (oc == '{')
            {
                obj.Type = ParserObject.ParserObjectType.Complex;
                cc = '}';
            }
            else
            if (oc == '[')
            {
                obj.Type = ParserObject.ParserObjectType.Array;
                cc = ']';
            }
            else
            {
                obj.Type = ParserObject.ParserObjectType.Simple;
                if (oc == '"')
                    cc = '"';
            }
            var j = i+1;
            var count = 1;
            while(count != 0 && j < str.Length)
            {
                
                if (str[j] == cc)
                    count--;
                else
                    if (str[j] == oc)
                    count++;
                j++;
            }
            var value = str.Substring(i + 1, j - 2 - i).Trim();
            if (obj.Type != ParserObject.ParserObjectType.Simple)
                obj.Value = Split(value);
            else
                obj.Value = value;
            
            return obj;
            

        }
        public override List<ParserObject> Split(string str)
        {
            var list = new List<ParserObject>();
            while (str.Length != 0)
            {
                var quotes = 0;
                var squared = 0;
                var figured = 0;
                int i = 0;
                do
                {
                    var c = str[i];
                    if (c == '"')
                        quotes++;
                    if (c == ']')
                        squared--;
                    if (c == '}')
                        figured--;
                    if (c == '{')
                        figured++;
                    if (c == '[')
                        squared++;
                    i++;
                } while (i < str.Length && !(str[i] == ',' && figured == 0 && squared == 0 && quotes % 2 == 0));
                
                var subStr = str.Substring(0, i);
                list.Add(Parse(subStr));
                if (i == str.Length)
                    break;
                i++;
                str = str.Substring(i, str.Length - i).Trim();
            }
            return list;
        }
    }
}
