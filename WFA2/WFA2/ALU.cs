using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA2
{
    class ALU
    {
        private string alu_ctrl, readData1, readData2;
        public string Alu_Ctrl
        {
            get { return alu_ctrl; }
            set { alu_ctrl = value; }
        }
        public string ReadData1
        {
            get { return readData1; }
            set { readData1 = value; }
        }
        public string ReadData2
        {
            get { return readData2; }
            set { readData2 = value; }
        }
        public void calculate(ref Multiplexer alu_scr, ref Memory mem, ref Multiplexer memtoreg, ref Branch_AND_Gate bag)
        {
            
            switch (Alu_Ctrl)
            {
                case "000":
                    int operand1 = Convert.ToInt32(ReadData1, 2);
                    int operand2 = Convert.ToInt32(alu_scr.Result(), 2);
                    int result =operand1 + operand2;
                    mem.Address = result;
                    memtoreg.One = Convert.ToString(result, 2);
                    break;

                case "001":
                    operand1 = Convert.ToInt32(ReadData1, 2);
                    operand2 = Convert.ToInt32(alu_scr.Result(), 2);
                    result = operand1 - operand2;
                    if (result == 0)
                        bag.ALU_Zero = true;
                    mem.Address = result;
                    memtoreg.One = Convert.ToString(result, 2);
                    break;

                case "010":
                    operand1 = Convert.ToInt32(ReadData1, 2);
                    operand2 = Convert.ToInt32(alu_scr.Result(), 2);
                    if (operand1 < operand2)
                        result = 1;
                    else result = 0;
                    mem.Address = result;
                    memtoreg.One = Convert.ToString(result, 2);
                    break;

                case "011":
                    operand1 = Convert.ToInt32(ReadData1, 2);
                    operand2 = Convert.ToInt32(alu_scr.Result(), 2);
                    result = operand2 | operand2;
                    mem.Address = result;
                    memtoreg.One = Convert.ToString(result, 2);
                    break;

                case "100":
                    operand1 = Convert.ToInt32(ReadData1, 2);
                    operand2 = Convert.ToInt32(alu_scr.Result(), 2);
                    result = operand1 ^ operand2;
                    mem.Address = result;
                    memtoreg.One = Convert.ToString(result, 2);
                    break;

                case "111":
                    operand2 = Convert.ToInt32(alu_scr.Result(), 2);
                    result = operand2 << 16;
                    mem.Address = result;
                    memtoreg.One = Convert.ToString(result, 2);
                    break;
            }
                
        }
    }
}
