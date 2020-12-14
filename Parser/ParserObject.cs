using System;
using System.Collections.Generic;
using System.Text;

namespace Parser
{
    public class ParserObject
    {
        public enum ParserObjectType {Simple, Complex, Array}
        public ParserObjectType Type { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }


    }
}
