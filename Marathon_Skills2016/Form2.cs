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
    public partial class Form2 : Form
    {
        static DateTime GetStartTime()
        {
            SqlConnClass scc = new SqlConnClass();
            string date = scc.Connection();
            return Convert.ToDateTime(date);
        }
        DateTime voteTime = GetStartTime();
        Timer tm = new Timer();
        public Form2()
        {
            InitializeComponent();
            tm.Tick += timer1_Tick;
            tm.Interval = 1000;
            tm.Enabled = true;
            tm.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            AuthorizForm af = new AuthorizForm();
            af.ShowDialog();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            Form1 fr = new Form1();
            fr.ShowDialog();
            Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            RegForm rf = new RegForm();
            rf.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            AuthorizForm af = new AuthorizForm();
            af.ShowDialog();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan TimeRemaining = voteTime - DateTime.Now;
            label4.Text = TimeRemaining.Days + " дней " + TimeRemaining.Hours + " часов " + TimeRemaining.Minutes + " минут до старта марафона!";
        }
    }
}
