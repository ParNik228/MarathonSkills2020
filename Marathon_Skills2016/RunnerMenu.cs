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
    public partial class RunnerMenu : Form
    {
        static DateTime GetStartTime()
        {
            SqlConnClass scc = new SqlConnClass();
            string date = scc.Connection();
            return Convert.ToDateTime(date);
        }
        DateTime voteTime = GetStartTime();
        Timer tm = new Timer();
        int runnerId;
        public RunnerMenu(int id)
        {
            InitializeComponent();
            tm.Tick += timer1_Tick;
            tm.Interval = 1000;
            tm.Enabled = true;
            tm.Start();
            runnerId = id;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            RegEventForm reg = new RegEventForm(runnerId);
            reg.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            Form1 fr = new Form1();
            fr.ShowDialog();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            EditProfileForm epf = new EditProfileForm(runnerId);
            epf.ShowDialog();
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            MyResForm mrf = new MyResForm(runnerId);
            mrf.ShowDialog();
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            MySponsorForm msf = new MySponsorForm();
            msf.ShowDialog();
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Для получения дополнительной информации \nпожалуйста свяжитесь с координаторами\n\nТелефон: +55 11 9988 7766\nEmail: dean.pinilla@gmail.com\n\nvernon.ankeny@nster.g\nw.bubash@manda.com", "Контакты");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan TimeRemaining = voteTime - DateTime.Now;
            label21.Text = TimeRemaining.Days + " дней " + TimeRemaining.Hours + " часов " + TimeRemaining.Minutes + " минут до старта марафона!";
        }
    }
}
