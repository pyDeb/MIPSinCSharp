using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Miniature
{
    public partial class Form1 : Form
    {
        int memory_index = 0;
        int tempArray_index = 1; // represents pc+1
        string[] tempArray;
        public void error_check ()
        {
            Environment.Exit(0);
        }
        
        public static string ReverseString(string str)
            {
                char[] arr = str.ToCharArray();
                Array.Reverse(arr);
                return new string(arr);
            }
        public string four_bits_converter(string str)
        {
            
            string binary_offset = "";
            int offset = Convert.ToInt32(str);

            binary_offset = Convert.ToString(offset, 2);
            while (binary_offset.Length < 4)
                binary_offset = binary_offset.Insert(0, "0");
            binary_offset = binary_offset.Substring(binary_offset.Length - 4, 4);
            binary_offset = ReverseString(binary_offset);
            return binary_offset;
        }

        public string sixteen_bits_converter(string str, bool sts)
        {

            string binary_offset = "";
            int offset = Convert.ToInt32(str);

            if (offset > 32767 || offset < -32768)
            {
             MessageBox.Show("Offset doesn't fit in 16 bits");
                Array.Clear(tempArray, 0, tempArray.Length);
        }

            if (sts)
                offset = offset - memory_index - 1;
            binary_offset = Convert.ToString(offset, 2);
            while (binary_offset.Length < 32)
              binary_offset = binary_offset.Insert(0,Convert.ToString(binary_offset[0])); // zero index implies whether it is signed or unsigned
            binary_offset = binary_offset.Substring(16, 16);
            binary_offset = ReverseString(binary_offset);
            return binary_offset;
        }

        int[] memory = new int[16384];
        public Form1()
        {
            InitializeComponent();
        }

        public bool check_duplicate_label(string[] tempArray)
        {
            for (int i = 0; i < tempArray.Length;i++)
            {
                string[] divided_by_bs = tempArray[i].Split('\t');
                if (divided_by_bs.Length < 3 || divided_by_bs[0] =="")
                    continue;
                string test = divided_by_bs[0];
                for (int j = i+1; j < tempArray.Length;j++)
                {
                    string[] divided_by_bs1 = tempArray[j].Split('\t');
                    if (divided_by_bs1.Length < 3)
                        continue;
                    if (test == divided_by_bs1[0])
                        return false;
                }
            }


            return true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            

            tempArray = richTextBox1.Lines;
           if( !check_duplicate_label(tempArray))
            {
                MessageBox.Show("Duplicate labels error found");
                Array.Clear(tempArray, 0, tempArray.Length);
                goto end;
            }
            if (tempArray[0] != null)
            {
                for (int i = 0; i < tempArray.Length; i++) // converting symbolic address into numeric one and delete label
                                                           // characters from beginning of each line
                {
                    string[] divided_by_sharp = tempArray[i].Split('#');
                    if (divided_by_sharp.Length > 1)
                    {
                        tempArray[i] = divided_by_sharp[0];
                        tempArray[i] = tempArray[i].Remove(tempArray[i].Length - 1);
                    }



                    int index = 0, element_index = 0;
                    for (; tempArray[i][index] == '\t' || tempArray[i][index] == ' '; index++) ; // Avoids tabs pressed in the beginning of each line
                    tempArray[i] = tempArray[i].Remove(0, index);

                    string[] divided_by_bs = tempArray[i].Split('\t');
                    string[] divided_by_comma = { "" };

                    if (divided_by_bs.Length == 2) // if it doesn't have label its size is two otherwise it's theree
                        divided_by_comma = divided_by_bs[1].Split(',');
                    else if (divided_by_bs.Length == 3)
                        divided_by_comma = divided_by_bs[2].Split(',');
                    if (divided_by_bs.Length == 1)
                        continue;

                    int used_for_out;
                    
                    if (!(int.TryParse(divided_by_comma[divided_by_comma.Length - 1], out used_for_out)) && divided_by_comma[divided_by_comma.Length - 1] != "halt")
                    {
                        bool label_available = false;
                        for (int k = 0; k < tempArray.Length; k++, element_index++)
                        {

                            string[] tmp2 = tempArray[k].Split('\t');
                            if (divided_by_comma[divided_by_comma.Length - 1] == tmp2[0])
                            {
                                label_available = true;
                                divided_by_comma[divided_by_comma.Length - 1] = k.ToString();
                                string final_result = "";

                                if (divided_by_bs.Length == 2)
                                    final_result += divided_by_bs[0];
                                else final_result += (divided_by_bs[0] + '\t' + divided_by_bs[1]);

                                final_result += '\t';
                                if (divided_by_comma.Length == 3)
                                    final_result += (divided_by_comma[0] + ',' + divided_by_comma[1] + ',' + divided_by_comma[2]);

                                else if (divided_by_comma.Length == 2)
                                    final_result += (divided_by_comma[0] + ',' + divided_by_comma[1]);

                                else final_result += divided_by_comma[0];
                                tempArray[i] = final_result;

                                //   string new_tempArray = tmp2[1];
                                //   new_tempArray += ("\t" + tmp2[2]);
                                //   tempArray[k] = new_tempArray;


                                break;
                            }
                            
                        }
                        if (!label_available)
                        {
                            MessageBox.Show("Label used in line " + i + " is not available");
                            this.Close();
                            Array.Clear(tempArray, 0, tempArray.Length);
                            goto end;

                        }
                    }



                }
            }
            if (tempArray[0]!=null)
            {
                foreach (string element in tempArray)
                {

                    string[] temp = element.Split('\t');
                    string result = "";
                    string[] just_for_nothing;
                    string compare = "";
                    int temp_index = 0;// to differ for lines whit or without label
                    if (temp.Length == 2)
                    {
                        just_for_nothing = temp[1].Split(',');
                        int used_for_out;
                        if (just_for_nothing.Length > 1 || int.TryParse(temp[1], out used_for_out)) // second one used for (j  offset)
                            compare = temp[0];
                        else compare = temp[1]; // it's like (label halt)
                        temp_index = 1;
                    }
                    else if (temp.Length == 3)
                    {
                        compare = temp[1];
                        temp_index = 2;
                    }
                    else
                    {
                        compare = temp[0];
                    }
                    if (compare == "add")
                    {
                        result = "000000000000";
                        string[] registers = temp[temp_index].Split(',');
                        string rd = four_bits_converter(registers[0]);
                        result += rd;

                        string rt = four_bits_converter(registers[2]);
                        result += rt;

                        string rs = four_bits_converter(registers[1]);
                        result += rs;

                        result += "00000000";
                    }
                    else if (compare == "sub")
                    {
                        result = "000000000000";
                        string[] registers = temp[temp_index].Split(',');
                        string rd = four_bits_converter(registers[0]);
                        result += rd;

                        string rt = four_bits_converter(registers[2]);
                        result += rt;

                        string rs = four_bits_converter(registers[1]);
                        result += rs;

                        result += "10000000";
                    }
                    else if (compare == "slt")
                    {
                        result = "000000000000";
                        string[] registers = temp[temp_index].Split(',');
                        string rd = four_bits_converter(registers[0]);
                        result += rd;

                        string rt = four_bits_converter(registers[2]);
                        result += rt;

                        string rs = four_bits_converter(registers[1]);
                        result += rs;

                        result += "01000000";

                    }
                    else if (compare == "or")
                    {
                        result = "000000000000";
                        string[] registers = temp[temp_index].Split(',');
                        string rd = four_bits_converter(registers[0]);
                        result += rd;

                        string rt = four_bits_converter(registers[2]);
                        result += rt;

                        string rs = four_bits_converter(registers[1]);
                        result += rs;
                        result += "11000000";
                    }
                    else if (compare == "nand")
                    {
                        result = "000000000000";
                        string[] registers = temp[temp_index].Split(',');
                        string rd = four_bits_converter(registers[0]);
                        result += rd;

                        string rt = four_bits_converter(registers[2]);
                        result += rt;

                        string rs = four_bits_converter(registers[1]);
                        result += rs;
                        result += "00100000";
                    }
                    else if (compare == "addi")
                    {
                        string[] registers = temp[temp_index].Split(',');

                        result = sixteen_bits_converter(registers[2], false);

                        string rt = four_bits_converter(registers[0]);
                        result += rt;

                        string rs = four_bits_converter(registers[1]);
                        result += rs;

                        result += "10100000";

                    }
                    else if (compare == "slti")
                    {
                        string[] registers = temp[temp_index].Split(',');

                        result = sixteen_bits_converter(registers[2], false);

                        string rt = four_bits_converter(registers[0]);
                        result += rt;

                        string rs = four_bits_converter(registers[1]);
                        result += rs;

                        result += "01100000";
                    }
                    else if (compare == "ori")
                    {
                        string[] registers = temp[temp_index].Split(',');
                        result = sixteen_bits_converter(registers[2], false);

                        string rt = four_bits_converter(registers[0]);
                        result += rt;

                        string rs = four_bits_converter(registers[1]);
                        result += rs;

                        result += "11100000";
                    }
                    else if (compare == "lui") // is it really right?
                    {
                        string[] registers = temp[temp_index].Split(',');
                        result = sixteen_bits_converter(registers[1], false);

                        string rt = four_bits_converter(registers[0]);
                        result += rt;

                        result += "0000000000010000";

                    }
                    else if (compare == "lw")
                    {
                        string[] registers = temp[temp_index].Split(',');

                        result = sixteen_bits_converter(registers[2], false);

                        string rt = four_bits_converter(registers[0]);
                        result += rt;

                        string rs = four_bits_converter(registers[1]);
                        result += rs;

                        result += "10010000";
                    }
                    else if (compare == "sw")
                    {
                        string[] registers = temp[temp_index].Split(',');

                        result = sixteen_bits_converter(registers[2], false);

                        string rt = four_bits_converter(registers[0]);
                        result += rt;

                        string rs = four_bits_converter(registers[1]);
                        result += rs;

                        result += "01010000";
                    }
                    else if (compare == "beq")
                    {
                        string[] registers = temp[temp_index].Split(',');

                        result = sixteen_bits_converter(registers[2], true);

                        string rt = four_bits_converter(registers[0]);
                        result += rt;

                        string rs = four_bits_converter(registers[1]);
                        result += rs;

                        result += "11010000";
                    }
                    else if (compare == "jalr")
                    {
                        string[] registers = temp[temp_index].Split(',');
                        result += "0000000000000000";
                        string rt = four_bits_converter(registers[0]);
                        result += rt;

                        string rs = four_bits_converter(registers[1]);
                        result += rs;

                        result += "00110000";
                    }
                    else if (compare == "j")
                    {
                        result = sixteen_bits_converter(temp[temp_index], false);

                        result += "00000000"; // 16-23
                        result += "10110000";
                    }
                    else if (compare == "halt") // Put zero except for opcode
                    {
                        result = "00000000000000000000000001110000";
                    }

                    else if (compare == ".space")
                    {
                        int offset = Convert.ToInt32(temp[1]);
                    }
                    else if (temp[0] == ".fill" || temp[1] == ".fill") //used for .fill
                    {
                        
                        int used_for_out;
                        int offset;
                        if (int.TryParse(temp[1], out used_for_out))
                            offset = Convert.ToInt32(temp[1]);
                        else
                            offset = Convert.ToInt32(temp[2]);

                        memory[memory_index++] = offset;
                        tempArray_index++;
                        continue;
                    }
                    else
                    {
                        MessageBox.Show("Wrong ussage of opcode");
                        goto end;
                    }
                    result = ReverseString(result);
                    int final_result = Convert.ToInt32(result, 2);
                    memory[memory_index++] = final_result;
                    tempArray_index++;
                }
            }
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Javad\Desktop\assembly.mc"))
            {
                for (int i = 0; i < tempArray.Length; i++)
                {
                    sw.WriteLine(memory[i]);
                }
       
     }
            MessageBox.Show("Hope to see you soon again! :)");
        end:        Application.Exit();
        }
       
    }
}

