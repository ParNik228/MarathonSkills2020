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
    public partial class MoreInfoForm : Form
    {
        public MoreInfoForm()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            ListOfChar loc = new ListOfChar();
            loc.ShowDialog();
            Close();
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            Form1 fr = new Form1();
            fr.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            AboutForm af = new AboutForm();
            af.ShowDialog();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            PerviousForm pf = new PerviousForm();
            pf.ShowDialog();
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            BMICalc bmi = new BMICalc();
            bmi.ShowDialog();
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            LongMarathonForm lmf = new LongMarathonForm();
            lmf.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
