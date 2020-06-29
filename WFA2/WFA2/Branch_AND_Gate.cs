using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA2
{
    class Branch_AND_Gate
    {
        private bool control_unit = false, alu_zero = false;
        public bool Control_Unit
        {
            get { return control_unit; }
            set { control_unit = value; }
        }
        public bool ALU_Zero
        {
            get { return alu_zero; }
            set { alu_zero = value; }
        }
    }
}
