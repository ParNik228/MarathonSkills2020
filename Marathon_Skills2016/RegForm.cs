using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marathon_Skills2016
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
            RegForm rf = this;
            SqlConnClass scc = new SqlConnClass();
            scc.RegFormLoad(rf);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label14.Visible = true;
            }
            else
                label14.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                label15.Visible = true;
            }
            else
                label15.Visible = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                label16.Visible = true;
            }
            else
                label16.Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                label17.Visible = true;
            }
            else
                label17.Visible = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                label18.Visible = true;
            }
            else
                label18.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            //string fileText = System.IO.File.ReadAllText(filename);
            pictureBox1.Load(filename);
            textBox7.Text = filename;
            label10.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
