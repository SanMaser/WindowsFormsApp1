using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public Size size;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
 if (checkBox1.Checked)
            {
                size = new Size(320, 240);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                size = new Size(640, 480);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                size = new Size(800, 600);
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                groupBox1.Enabled = false;
                textBox1.Enabled = true; 
                textBox2.Enabled=true;
            }
            else if (!checkBox4.Checked)
            {
                groupBox1.Enabled = true;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            }
        }
        int x, y;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            x= Convert.ToInt32(textBox1.Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!groupBox1.Enabled)
            {
                size = new Size(x, y);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            y= Convert.ToInt32(textBox2.Text);
        }
    }
}
