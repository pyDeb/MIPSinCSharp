using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA2
{
    class Register_File
    {
        private bool regwrite = false;
        private string readRegister1, readRegister2, writeRegister, writeData;
        private string[] registers = new string[16];
        private string readData1, readData2;

        public bool RegWrite
        {
            get { return regwrite; }
            set { regwrite = value; }
        }
        public string ReadRegister1
        {
            get { return readRegister1; }
            set { readRegister1 = value; }
        }
        public string ReadRegister2
        {
            get { return readRegister2; }
            set { readRegister2 = value; }
        }
        public string WriteRegister
        {
            get { return writeRegister; }
            set { writeRegister = value; }
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
        public string[] Registers
        {
            get { return registers; }
            set { registers = value; }
        }
        public void get_data(ref ALU alu, ref Multiplexer alu_src, ref Multiplexer ec, ref Memory mem)
        {
            //Don't forget to remove these
            registers[0] = "0";
            int index1 = Convert.ToInt32(ReadRegister1, 2);
            int index2 = Convert.ToInt32(ReadRegister2, 2);
            ReadData1 = registers[index1];
            ReadData2 = registers[index2];
            alu.ReadData1 = ReadData1;
            alu_src.Zero = ReadData2;
            alu_src.One = ec.Result();
            mem.Write_Data = Convert.ToInt32(ReadData2, 2);
        }
        public void write_to_reg (ref Multiplexer writedt_dest, int pc_plus4, ref Multiplexer memtoreg)
        {
            writeData = writedt_dest.Result();
            if (RegWrite)
                registers[Convert.ToInt32(writeRegister, 2)] = writeData;
        }
    }
}
