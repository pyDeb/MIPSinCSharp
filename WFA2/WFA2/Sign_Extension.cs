using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA2
{
    class Sign_Extension
    {
        public string load(string imm_value)
        {
            string result = "";
            result = imm_value;
            if (imm_value[0] == '0')
            {
                while (result.Length < 32)
                    result = result.Insert(0, "0");
            }
            else
                while (result.Length < 32)
                    result = result.Insert(0, "1");
            return result;
        }
    }
}
