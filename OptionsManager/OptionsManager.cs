using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsManager
{
    public class OptionsManager
    {
        protected List<Options> options;
        public OptionsManager()
        {
            options = new List<Options>();
        }
        public Options GetOptions<T>()
        {
           // if (options.Count == 0)
             //   return null;
            foreach (var option in options)
                if (option.GetType() == typeof(T))
                    return option;
            return null;
        }

        public void AddOptions(Options opt)
        {
            options.Add(opt);
        }
    }
}
