using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA2
{
    class Multiplexer
    {
        private bool destination = false;
        private string zero;
        private string one;
        public bool Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        public string Zero
        {
            get { return zero; }
            set { zero = value; }
        }
        public string One
        {
            get { return one; }
            set { one = value; }
        }
        public string Result()
        {
            if (destination)
                return One;
            else return Zero;
        }
    }
}
