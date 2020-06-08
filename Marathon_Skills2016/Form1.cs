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
    public partial class Form1 : Form
    {
      
        static DateTime GetStartTime()
        {
            SqlConnClass scc = new SqlConnClass();
            string date = scc.Connection();
            return Convert.ToDateTime(date);
        }

        DateTime voteTime = GetStartTime(); //new DateTime(2020,11,24,6,0,0);
        public Form1()
        {
            InitializeComponent();
           
            tm.Tick += timer2_Tick;
            tm.Interval = 1000;
            tm.Enabled = true;
            tm.Start();
        }
        Timer tm = new Timer();

       
        private void button1_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            Form2 frm = new Form2();
            frm.ShowDialog();
            Close();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {

            ActiveForm.Hide();
           AuthorizForm af = new AuthorizForm();
            af.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
            ActiveForm.Hide();
            SponsorForm sf = new SponsorForm();
            sf.ShowDialog();
            Close();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            MoreInfoForm mif = new MoreInfoForm();
            mif.ShowDialog();
            Close();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            TimeSpan TimeRemaining = voteTime - DateTime.Now;
            label4.Text = TimeRemaining.Days + " дней " + TimeRemaining.Hours + " часов " + TimeRemaining.Minutes + " минут до старта марафона!";
        }
    }
}
