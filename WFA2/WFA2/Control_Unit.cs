using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA2
{
    class Control_Unit
    {
        private string opcode;
        public string Opcode
        {
            get { return opcode; }
            set { opcode = value; }
        }
        public bool set_controls(ref Register_File rf, ref Multiplexer alu_src, ref Memory mem,
                                 ref ALU alu, ref Multiplexer memtoreg, ref Branch_AND_Gate bag,
                                 ref Multiplexer regdest, ref Multiplexer ec,
                                 ref Multiplexer writedt_dest, ref Multiplexer jalr_or_pc,
                                 ref Multiplexer jump_or_pc)
        {
            switch(Opcode)
            {
                case "0000":
                    regdest.Destination = true;
                    alu_src.Destination = false;
                    memtoreg.Destination = true;
                    rf.RegWrite = true;
                    mem.MemRead = false;
                    mem.MemWrite = false;
                    bag.Control_Unit = false;
                    //ec.Destination = true; don't care
                    writedt_dest.Destination = true;
                    jalr_or_pc.Destination = false;
                    jump_or_pc.Destination = false;
                    alu.Alu_Ctrl = "000";
                    break;// extension control = don't care

                case "0001":
                    regdest.Destination = true;
                    alu_src.Destination = false;
                    memtoreg.Destination = true;
                    rf.RegWrite = true;
                    mem.MemRead = false;
                    mem.MemWrite = false;
                    bag.Control_Unit = false;
                    //ec.Destination = false; don't care
                    writedt_dest.Destination = true;
                    jalr_or_pc.Destination = false;
                    jump_or_pc.Destination = false;
                    alu.Alu_Ctrl = "001";
                    break;
                case "0010":
                    regdest.Destination = true;
                    alu_src.Destination = false;
                    memtoreg.Destination = true;
                    rf.RegWrite = true;
                    mem.MemRead = false;
                    mem.MemWrite = false;
                    bag.Control_Unit = false;
                    //ec.Destionation
                    writedt_dest.Destination = true;
                    jalr_or_pc.Destination = false;
                    jump_or_pc.Destination = false;
                    alu.Alu_Ctrl = "010";
                    break;

                case "0011":
                    regdest.Destination = true;
                    alu_src.Destination = false;
                    memtoreg.Destination = true;
                    rf.RegWrite = true;
                    mem.MemRead = false;
                    mem.MemWrite = false;
                    bag.Control_Unit = false;
                    //ec.Destination
                    writedt_dest.Destination = true;
                    jalr_or_pc.Destination = false;
                    jump_or_pc.Destination = false;
                    alu.Alu_Ctrl = "011";
                    break;

                case "0100":
                    regdest.Destination = true;
                    alu_src.Destination = false;
                    memtoreg.Destination = true;
                    rf.RegWrite = true;
                    mem.MemRead = false;
                    mem.MemWrite = false;
                    bag.Control_Unit = false;
                    //ec.Destination
                    writedt_dest.Destination = true;
                    jalr_or_pc.Destination = false;
                    jump_or_pc.Destination = false;
                    alu.Alu_Ctrl = "100";
                    break;

                case "0101":
                    regdest.Destination = false;
                    alu_src.Destination = true;
                    memtoreg.Destination = true;
                    rf.RegWrite = true;
                    mem.MemRead = false;
                    mem.MemWrite = false;
                    bag.Control_Unit = false;
                    ec.Destination = false;
                    writedt_dest.Destination = true;
                    jalr_or_pc.Destination = false;
                    jump_or_pc.Destination = false;
                    alu.Alu_Ctrl = "000";
                    break;

                case "0110":
                    regdest.Destination = false;
                    alu_src.Destination = true;
                    memtoreg.Destination = true;
                    rf.RegWrite = true;
                    mem.MemRead = false;
                    mem.MemWrite = false;
                    bag.Control_Unit = false;
                    ec.Destination = false;
                    writedt_dest.Destination = true;
                    jalr_or_pc.Destination = false;
                    jump_or_pc.Destination = false;
                    alu.Alu_Ctrl = "010";
                    break;

                case "0111":
                    regdest.Destination = false;
                    alu_src.Destination = true;
                    memtoreg.Destination = true;
                    rf.RegWrite = true;
                    mem.MemRead = false;
                    mem.MemWrite = false;
                    bag.Control_Unit = false;
                    ec.Destination = true;
                    writedt_dest.Destination = true;
                    jalr_or_pc.Destination = false;
                    jump_or_pc.Destination = false;
                    alu.Alu_Ctrl = "011";
                    break;

                case "1000":
                    regdest.Destination = false;
                    alu_src.Destination = true;
                    memtoreg.Destination = true;
                    rf.RegWrite = true;
                    mem.MemRead = false;
                    mem.MemWrite = false;
                    bag.Control_Unit = false;
                    ec.Destination = true;
                    writedt_dest.Destination = true;
                    jalr_or_pc.Destination = false;
                    jump_or_pc.Destination = false;
                    alu.Alu_Ctrl = "111";
                    break;

                case "1001":
                    regdest.Destination = false;
                    alu_src.Destination = true;
                    memtoreg.Destination = false;
                    rf.RegWrite = true;
                    mem.MemRead = true;
                    mem.MemWrite = false;
                    bag.Control_Unit = false;
                    ec.Destination = false;
                    writedt_dest.Destination = true;
                    jalr_or_pc.Destination = false;
                    jump_or_pc.Destination = false;
                    alu.Alu_Ctrl = "000";
                    break;

                case "1010":
                    //regdest.Destination = false; don't care
                    alu_src.Destination = true;
                    //memtoreg.Destination = false; don't care
                    rf.RegWrite = false;
                    mem.MemRead = false;
                    mem.MemWrite = true;
                    bag.Control_Unit = false;
                    ec.Destination = false;
                    writedt_dest.Destination = true;
                    jalr_or_pc.Destination = false;
                    jump_or_pc.Destination = false;
                    alu.Alu_Ctrl = "000";
                    break;

                case "1011":
                    //regdest.Destination = false; don't care
                    alu_src.Destination = false;
                    //memtoreg.Destination = false; don't care
                    rf.RegWrite = false;
                    mem.MemRead = false;
                    mem.MemWrite = false;
                    bag.Control_Unit = true;
                    ec.Destination = false;
                    writedt_dest.Destination = true;
                    jalr_or_pc.Destination = false;
                    jump_or_pc.Destination = false;
                    alu.Alu_Ctrl = "001";
                    break;

                case "1100":
                    regdest.Destination = false;
                    //alu_src.Destination = true;
                    memtoreg.Destination = false;
                    rf.RegWrite = true;
                    mem.MemRead = false;
                    mem.MemWrite = false;
                    bag.Control_Unit = false;
                    ec.Destination = false;
                    writedt_dest.Destination = false;
                    jalr_or_pc.Destination = true;
                    jump_or_pc.Destination = false;
                    alu.Alu_Ctrl = "000";
                    break;

                case "1101":
                    //regdest.Destination = false; don't care
                    alu_src.Destination = true;
                    memtoreg.Destination = false;
                    rf.RegWrite = false;
                    mem.MemRead = false;
                    mem.MemWrite = false;
                    bag.Control_Unit = false;
                    ec.Destination = false;
                    writedt_dest.Destination = true;
                    jalr_or_pc.Destination = false;
                    jump_or_pc.Destination = true;
                    alu.Alu_Ctrl = "000";
                    break;

                case "1110":
                    return true;
            }
            return false;
           
        }
    }
}
