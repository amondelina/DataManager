using System;
using System.Collections.Generic;
using System.Text;

namespace Parser
{
    public class ParserToXML
    {
        string Indent(int lvl)
        {
            var ind = "";
            for (int i = 0; i < lvl; i++)
                ind += "    ";
            return ind;
        }
        public string GenerateXml(object obj, int lvl)
        {
            var indent = Indent(lvl);
            var content = "";
            if (obj == null)
                return indent + "null\r\n";
            foreach(var prop in obj.GetType().GetProperties())
            {
                string name = prop.Name;
                string openTag = indent + "<" + name + ">\r\n";
                string closeTag = indent + "</" + name + ">\r\n";
                var value = prop.GetValue(obj);

                var propType = prop.PropertyType;
                if(value == null)
                {
                    content += openTag + Indent(lvl+1) +"null\r\n" + closeTag;
                    continue;
                }
                if (propType == typeof(int) || propType == typeof(string) || propType == typeof(DateTime) || propType == typeof(Guid))
                    content += openTag + Indent(lvl+1) + value.ToString() + "\r\n" + closeTag;
                else
                    content += openTag + GenerateXml(value, lvl+1) + closeTag;

            }
            return content;
            
        }
        public string GenerateXML(object obj)
        {
            var type = obj.GetType();
            string name = type.Name;
            string openTag = "<" + name + ">\r\n";
            string closeTag = "</" + name + ">\r\n";
            string content = "";
            if (type == typeof(int) || type == typeof(string) || type == typeof(DateTime) || type == typeof(Guid))
                content = Indent(1) + obj.ToString() + "\r\n";
            else
                content = GenerateXml(obj, 1);
            return openTag + content + closeTag;

        }
        public string GenerateXSD<T>(int lvl)
        {
            var type = typeof(T);
            var indent = Indent(lvl);
            string name = "xs:element";
            string openTag = indent + "<" + name + ">\n";
            string closeTag = indent + "</" + name + ">\n";
            string content = "";

            foreach (var prop in type.GetProperties())
            {
                indent = Indent(lvl + 1);
                var propType = prop.PropertyType;
                if (propType == typeof(int) || propType == typeof(string) || propType == typeof(DateTime) || propType == typeof(Guid))             
                    content += indent + "<xs:element name=\"" + prop.Name + "\" type=\"xs: " + propType.ToString() + " \"/>\n";
                else
                {
                    var method = typeof(ParserToXML).GetMethod(nameof(GenerateXSD));
                    content += indent + "<xs:complexType> \n" + Indent(lvl+2) +"<xs:sequence > " +
                                method.MakeGenericMethod(propType).Invoke(this, new object[] {lvl+1}) +
                                Indent(lvl+2) + "</xs:sequence> \n" + indent + "</xs:complexType >\n";                
                }
            }
            return openTag + content + closeTag;

        }
        public string GenerateXSDSchema<T>()
        {
            return  "<xs:schema xmlns: xs = \"http://www.w3.org/2001/XMLSchema \" >" +
                    GenerateXSD<T>(1) +
                    "</xs:schema >";

        }


    }
}
