using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA2
{
    class Instruction_Decode
    {

        public void decode(ref string instr, ref Multiplexer reg_des, ref Register_File rf, ref Control_Unit cu)
        {
            while (instr.Length < 32)
                instr = instr.Insert(0, "0");
           rf.ReadRegister1 = instr.Substring(8, 4);//it sends rs to reg file    
           rf.ReadRegister2 = instr.Substring(12, 4);
           reg_des.Zero = instr.Substring(12, 4);
           reg_des.One = instr.Substring(16, 4);
           cu.Opcode = instr.Substring(4, 4);
        }
    }
}
