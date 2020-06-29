using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA2
{
    class Zero_Extension
    {
        public string extension(string str)
        {
            string result = str;
            while (result.Length < 32)
                result = result.Insert(0, "0");
            return result;
        }
    }
}
