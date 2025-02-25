using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace data_person
{
    public partial class dataForm: Form
    {
        Form1 form1 = new Form1();
        public StreamReader sr;

        public dataForm()
        {
            InitializeComponent();
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            return;
        }

        private void dataForm_Load(object sender, EventArgs e)
        {
            sr = new StreamReader(form1.folder + @"\" + form1.file);
            string line = sr.ReadToEnd();
            string[] data = line.Split('\n');

            for (int i = 0; i < data.Length-1; i++)
            {
                list.Items.Add(data[i]);
            }
        }
    }
}
