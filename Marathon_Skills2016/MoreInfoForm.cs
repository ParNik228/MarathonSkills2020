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
        static DateTime GetStartTime()
        {
            SqlConnClass scc = new SqlConnClass();
            string date = scc.Connection();
            return Convert.ToDateTime(date);
        }
        DateTime voteTime = GetStartTime();
        Timer tm = new Timer();
        public MoreInfoForm()
        {
            InitializeComponent();
            tm.Tick += timer1_Tick;
            tm.Interval = 1000;
            tm.Enabled = true;
            tm.Start();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan TimeRemaining = voteTime - DateTime.Now;
            label21.Text = TimeRemaining.Days + " дней " + TimeRemaining.Hours + " часов " + TimeRemaining.Minutes + " минут до старта марафона!";
        }
    }
}
