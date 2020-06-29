using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA2
{
    class Instruction_Memory
    {
        private SortedDictionary<int,int> memarray = new SortedDictionary<int, int>();
        public SortedDictionary<int,int> MemArray
        {
            get { return memarray; }
            set { memarray = value; }
        }
        
    }
}
