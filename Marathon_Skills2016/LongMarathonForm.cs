﻿using System;
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
    public partial class LongMarathonForm : Form
    {
        static DateTime GetStartTime()
        {
            SqlConnClass scc = new SqlConnClass();
            string date = scc.Connection();
            return Convert.ToDateTime(date);
        }
        DateTime voteTime = GetStartTime();
        Timer tm = new Timer();
        public LongMarathonForm()
        {
            InitializeComponent();
            tm.Tick += timer1_Tick;
            tm.Interval = 1000;
            tm.Enabled = true;
            tm.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            MoreInfoForm mif = new MoreInfoForm();
            mif.ShowDialog();
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan TimeRemaining = voteTime - DateTime.Now;
            labelTimer.Text = TimeRemaining.Days + " дней " + TimeRemaining.Hours + " часов " + TimeRemaining.Minutes + " минут до старта марафона!";
        }
    }
}
