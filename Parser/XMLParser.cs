using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Parser
{
    public class XMLParser : Parser
    {

        public XMLParser(string path) : base(path)
        { }

        override public async Task<T> Get<T>()
        {
            var text = (await File.ReadAllTextAsync(path)).Trim();
            return DeserializeObject<T>(Split(text));
        }
        
        public override ParserObject Parse(string str)
        {
            var obj = new ParserObject();
            if (!str.Contains("<"))
            {
                obj.Type = ParserObject.ParserObjectType.Simple;
                var i = str.IndexOf('=');
                obj.Name = str.Substring(1, i - 1).Trim();
                obj.Value = str.Substring(i + 1, str.Length - i);

            }
            else
            {
                var tag = str.Substring(1, str.IndexOf('>') - 1);
                var closingTag = "</" + tag + ">";
                string prop = "<>";
                if (str.Contains(closingTag))
                {
                    prop = str.Replace("</" + tag + ">", "").Replace("<" + tag + ">", "");
                    if (!prop.Contains("<"))
                    {
                        obj.Type = ParserObject.ParserObjectType.Simple;
                        obj.Name = tag;
                        obj.Value = prop;
                        return obj;

                    }
                }

                obj.Type = ParserObject.ParserObjectType.Complex;
                if (tag.Contains("="))
                {
                    var i = str.IndexOf(' ');
                    obj.Name = str.Substring(0, i).Trim();
                    obj.Value = Split(str.Substring(i + 1, str.Length - i - 1).Trim());
                    if (tag.EndsWith("/"))
                        return obj;
                }
                else
                {
                    obj.Name = tag.Trim();
                    obj.Value = new List<ParserObject>();

                }
                var list = obj.Value as List<ParserObject>;
                prop = str.Replace("</" + obj.Name + ">", "").Replace(tag, "");
                list.AddRange(Split(prop));

            } 
            return obj;
        }
        
        public override List<ParserObject> Split(string str)
        {
            var list = new List<ParserObject>();
            if(!str.Contains("<"))
            {
                while(str.Length > 0)
                {
                    var i = str.IndexOf(' ');
                    list.Add(Parse(str.Substring(0, i)));
                    str = str.Substring(i + 1, str.Length - i - 1);
                }
                return list;
            }
            else
            {
                while (str.Length > 0)
                {

                    var tag = str.Substring(1, str.IndexOf('>') - 1);
                    var cstr = str;
                    var closingTag = "</" + tag + ">";
                    while (!cstr.EndsWith(closingTag))
                        cstr = cstr.Substring(0, cstr.LastIndexOf('>'));
                    list.Add(Parse(cstr));
                    if (cstr == str)
                        break;
                    str = str.Substring(cstr.Length);

                }
                return list;
            }


            
        }
    }
}
