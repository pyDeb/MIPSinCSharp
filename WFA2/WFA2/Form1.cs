using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA2
{
    public partial class Form1 : Form
    {
        BaseClass bs = new BaseClass();
        string[] results = new string[19];// it has amount of registers (0-15) n those three fields (16-18)
        public static string directory;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.ShowDialog();
            directory = openFileDialog1.FileName;
        }

        
        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            results = bs.startProject(directory);
            textBox1.Text = Convert.ToInt32(results[0], 2).ToString();// it converts it to decimal then string :D
            textBox2.Text = Convert.ToInt32(results[1], 2).ToString();
            textBox3.Text = Convert.ToInt32(results[2], 2).ToString();
            textBox4.Text = Convert.ToInt32(results[3], 2).ToString();
            textBox5.Text = Convert.ToInt32(results[4], 2).ToString();
            textBox6.Text = Convert.ToInt32(results[5], 2).ToString();
            textBox7.Text = Convert.ToInt32(results[6], 2).ToString();
            textBox8.Text = Convert.ToInt32(results[7], 2).ToString();
            textBox9.Text = Convert.ToInt32(results[8], 2).ToString();
            textBox10.Text = Convert.ToInt32(results[9], 2).ToString();
            textBox11.Text = Convert.ToInt32(results[10], 2).ToString();
            textBox12.Text = Convert.ToInt32(results[11], 2).ToString();
            textBox13.Text = Convert.ToInt32(results[12], 2).ToString();
            textBox14.Text = Convert.ToInt32(results[13], 2).ToString();
            textBox15.Text = Convert.ToInt32(results[14], 2).ToString();
            textBox16.Text = Convert.ToInt32(results[15], 2).ToString();
            textBox17.Text = Convert.ToDouble(results[16]).ToString() + "%";
            textBox18.Text = Convert.ToDouble(results[17]).ToString() + "%";
            textBox19.Text = Convert.ToInt32(results[18]).ToString();

        }

        private void Registers_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textBox1.Text = Convert.ToInt32(registers[0], 2).ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }
        public string TextBox1
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public string TextBox2
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public string TextBox3
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }
        public string TextBox4
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }
        public string TextBox5
        {
            get { return textBox5.Text; }
            set { textBox5.Text = value; }
        }
        public string TextBox6
        {
            get { return textBox6.Text; }
            set { textBox6.Text = value; }
        }
        public string TextBox7
        {
            get { return textBox7.Text; }
            set { textBox7.Text = value; }
        }
        public string TextBox8
        {
            get { return textBox8.Text; }
            set { textBox8.Text = value; }
        }
        public string TextBox9
        {
            get { return textBox9.Text; }
            set { textBox9.Text = value; }
        }
        public string TextBox10
        {
            get { return textBox10.Text; }
            set { textBox10.Text = value; }
        }
        public string TextBox11
        {
            get { return textBox11.Text; }
            set { textBox11.Text = value; }
        }
        public string TextBox12
        {
            get { return textBox12.Text; }
            set { textBox12.Text = value; }
        }
        public string TextBox13
        {
            get { return textBox13.Text; }
            set { textBox13.Text = value; }
        }
        public string TextBox14
        {
            get { return textBox14.Text; }
            set { textBox14.Text = value; }
        }
        public string TextBox15
        {
            get { return textBox15.Text; }
            set { textBox15.Text = value; }
        }
        public string TextBox16
        {
            get { return textBox16.Text; }
            set { textBox16.Text = value; }
        }
        public string TextBox17
        {
            get { return textBox17.Text; }
            set { textBox17.Text = value; }
        }
        public string TextBox18
        {
            get { return textBox18.Text; }
            set { textBox18.Text = value; }
        }
        public string TextBox19
        {
            get { return textBox19.Text; }
            set { textBox19.Text = value; }
        }

    }
}
