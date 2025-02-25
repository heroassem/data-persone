using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace data_person
{
    public partial class Form1: Form
    {
        public string folder = @"C:\Users\Admin\Desktop\data folder";
        public string file = "data.txt";
        public StreamWriter sw;
        public string boxs;
        public string idPattern = @"^\d{3}$";
        public string namePattern = @"^[a-zA-Z]+$";
        public string passwordPattern = @"^[a-zA-Z0-9!@#$%^&*()_+=-]+$";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            Directory.CreateDirectory(folder);
            if (!File.Exists(folder + @"\" + file))
            {
                sw = new StreamWriter(folder + @"\" + file, true);
                sw.Close();
            }   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex id = new Regex(idPattern);
            Regex name = new Regex(namePattern);
            Regex password = new Regex(passwordPattern);

            if ((box1.Text.Trim() == "" || box2.Text.Trim() == "" || box3.Text.Trim() == "") || (box1.Text.Length < 3 || box2.Text.Length < 4 || box3.Text.Length < 8))
            {
                MessageBox.Show("Please fill all the boxes");
            }
            else if(!id.IsMatch(box1.Text))
            {
                MessageBox.Show("ID must be 3 digits");
            }
            else if (!name.IsMatch(box2.Text))
            {
                MessageBox.Show("Name must be alphabetic");
            }
            else if (!password.IsMatch(box3.Text))
            {
                MessageBox.Show("Password must be alphanumeric");
            }
            else
            {
                sw = new StreamWriter(folder + @"\" + file, true);
                sw.WriteLine("{0}/{1}/{2}\n", box1.Text, box2.Text, box3.Text);
                sw.Close();
                MessageBox.Show("Data saved");
                box1.Clear(); box2.Clear(); box3.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataForm df = new dataForm();
            df.Show();
        }
    }
}