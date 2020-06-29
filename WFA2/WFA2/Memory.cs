using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA2
{
    class Memory
    {
        private bool memread, memwrite;
        private int[] memArray = new int[16384];
        private int address, write_data, read_data, read_instruction;

        public bool MemRead
        {
            get { return memread; }
            set { memread = value; }
        }
        public bool MemWrite
        {
            get { return memwrite; }
            set { memwrite = value; }
        }
        public int[] MemArray
        {
            get { return memArray; }
            set { memArray = value; }
        }
        public int Address
        {
            get { return address; }
            set { address = value; }
        }
        public int Write_Data
        {
            get { return write_data; }
            set { write_data = value; }
        }
        public int Read_Data
        {
            get { return read_data; }
            set { read_data = value; }
        }
        public int Read_Instruction
        {
            get { return read_instruction; }
            set { read_instruction = value; }
        }
        
        public void get_or_set_data(ref Multiplexer memtoreg)
        {
            if (memread)
                memtoreg.Zero = Convert.ToString(memArray[address], 2);
            else if (memwrite)
                memArray[address] = write_data;
            return;
        }
    }
}
