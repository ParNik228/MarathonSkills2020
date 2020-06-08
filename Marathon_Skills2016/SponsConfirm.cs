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
    public partial class SponsConfirm : Form
    {
        static DateTime GetStartTime()
        {
            SqlConnClass scc = new SqlConnClass();
            string date = scc.Connection();
            return Convert.ToDateTime(date);
        }
        DateTime voteTime = GetStartTime();
        Timer tm = new Timer();
        public SponsConfirm(string name,string charity,string sum)
        {
            InitializeComponent();
            tm.Tick += timer1_Tick;
            tm.Interval = 1000;
            tm.Enabled = true;
            tm.Start();
            label4.Text = name;
            label5.Text = charity;
            label6.Text = sum;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            Form1 fr = new Form1();
            fr.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            Form1 fr = new Form1();
            fr.ShowDialog();
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan TimeRemaining = voteTime - DateTime.Now;
            label21.Text = TimeRemaining.Days + " дней " + TimeRemaining.Hours + " часов " + TimeRemaining.Minutes + " минут до старта марафона!";
        }
    }
}
