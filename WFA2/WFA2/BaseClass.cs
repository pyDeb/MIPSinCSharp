using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA2
{
    public class BaseClass
    {
        int pc_plus_one = 0;// representing PC
        double used_memory = 0;
        Instruction_Decode id = new Instruction_Decode();
        Register_File rf = new Register_File();
        Multiplexer memtoreg = new Multiplexer();
        Multiplexer alusrc = new Multiplexer();
        Multiplexer reg_des = new Multiplexer();
        Control_Unit cu = new Control_Unit();
        Sign_Extension se = new Sign_Extension();
        Memory mem = new Memory();
        Instruction_Memory im = new Instruction_Memory();
        Zero_Extension ze = new Zero_Extension();
        Multiplexer ec = new Multiplexer();
        Multiplexer extension_ctrl = new Multiplexer();
        Multiplexer beq_or_pc = new Multiplexer();// beq
        Multiplexer writedt_dest = new Multiplexer();
        Multiplexer jalr_or_pc = new Multiplexer();//jalr
        Multiplexer jump_or_pc = new Multiplexer();//jump
        Branch_AND_Gate bag = new Branch_AND_Gate();
        ALU alu = new ALU();
        public string[] startProject(string directory)
        {
            
     
            string[] lines = System.IO.File.ReadAllLines(directory);// Don't forget to change it
            for(; used_memory < lines.Length; used_memory++) // inserting texts in memory
                mem.MemArray[(int)used_memory] = Convert.ToInt32(lines[(int)used_memory]); 
            
            while (true) //don't forget to change it
            {
                if (!im.MemArray.ContainsKey(pc_plus_one))// IM miss, so it should be filled again
                    for (int i = 0, j = pc_plus_one; i < 10; i++,j++)
                        im.MemArray.Add(j, mem.MemArray[j]);
                string instr = Convert.ToString(im.MemArray[pc_plus_one++], 2);

                id.decode(ref instr, ref reg_des, ref rf, ref cu);
                string sign_extended = se.load(instr.Substring(16, 16));
                string zero_extened = ze.extension(instr.Substring(16, 16));

                ec.Zero = sign_extended;
                ec.One = zero_extened;

                if (cu.set_controls(ref rf, ref alusrc, ref mem, ref alu, ref memtoreg, ref bag, ref reg_des, ref ec,
                    ref writedt_dest, ref jalr_or_pc, ref jump_or_pc))
                    break;// it was halt so we're done

                rf.WriteRegister = reg_des.Result();
                rf.get_data(ref alu, ref alusrc, ref ec, ref mem);
                alu.calculate(ref alusrc, ref mem, ref memtoreg, ref bag);

                int pc_plus_sign_ext = Convert.ToInt32(sign_extended, 2) + pc_plus_one;
                beq_or_pc.Zero = Convert.ToString(pc_plus_one, 2);
                beq_or_pc.One = Convert.ToString(pc_plus_sign_ext, 2);

                if (bag.ALU_Zero && bag.Control_Unit)
                    beq_or_pc.Destination = true;

                mem.get_or_set_data(ref memtoreg);

                jalr_or_pc.Zero = beq_or_pc.Result();
                jalr_or_pc.One = rf.ReadData1;// amount of $rs

                writedt_dest.Zero = Convert.ToString(pc_plus_one, 2);
                writedt_dest.One = memtoreg.Result();

                rf.write_to_reg(ref writedt_dest, pc_plus_one, ref memtoreg);// choose whether write pc or memtoreg result

                jump_or_pc.Zero = jalr_or_pc.Result();
                jump_or_pc.One = zero_extened;
                pc_plus_one = Convert.ToInt32(jump_or_pc.Result(), 2);
                if (rf.Registers[1] == "0")
                    rf.Registers[0] = "0";
            }
            double used_register = 0;
            for (int i = 0; i < 16; i++)
                if (rf.Registers[i] != null)
                    used_register++;

            string[] results = new string[19];

            for (int i = 0; i < 16; i++)
                results[i] = rf.Registers[i];
            results[16] = Convert.ToString((used_register / 16) * 100);
            results[17] = Convert.ToString((used_memory / 16384) * 100);
            results[18] = Convert.ToString(pc_plus_one);
            return results;
    }

            
   }
}          




