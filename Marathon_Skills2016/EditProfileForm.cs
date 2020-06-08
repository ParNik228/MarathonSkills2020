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
    public partial class EditProfileForm : Form
    {
        static DateTime GetStartTime()
        {
            SqlConnClass scc = new SqlConnClass();
            string date = scc.Connection();
            return Convert.ToDateTime(date);
        }
        DateTime voteTime = GetStartTime();
        Timer tm = new Timer();
        int rannerId;
        public EditProfileForm(int id)
        {
            InitializeComponent();
            tm.Tick += timer1_Tick;
            tm.Interval = 1000;
            tm.Enabled = true;
            tm.Start();
            rannerId = id;
            EditProfileForm epf = this;
            SqlConnClass scc = new SqlConnClass();
            scc.GetEditRunnerProfile(epf,rannerId);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan TimeRemaining = voteTime - DateTime.Now;
            labelTimer.Text = TimeRemaining.Days + " дней " + TimeRemaining.Hours + " часов " + TimeRemaining.Minutes + " минут до старта марафона!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnClass scc = new SqlConnClass();
            if (textBox2.Text == textBox3.Text)
            {
                if(textBox4.Text == ""&&textBox5.Text==""&&textBox2.Text=="")
                {

                    scc.UpdateRecInRunner(label14.Text,rannerId,0, textBox2.Text, textBox4.Text, textBox5.Text, comboBox1.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm:ss"), textBox7.Text, comboBox2.Text);
                }
                if (textBox4.Text != "" && textBox5.Text == "" && textBox2.Text == "")
                {

                    scc.UpdateRecInRunner(label14.Text, rannerId,1, textBox2.Text, textBox4.Text, textBox5.Text, comboBox1.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm:ss"), textBox7.Text, comboBox2.Text);
                }
                if (textBox4.Text != "" && textBox5.Text != "" && textBox2.Text == "")
                {
                    scc.UpdateRecInRunner(label14.Text, rannerId,2, textBox2.Text, textBox4.Text, textBox5.Text, comboBox1.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm:ss"), textBox7.Text, comboBox2.Text);
                }
                if (textBox4.Text == "" && textBox5.Text != "" && textBox2.Text == "")
                {
                    scc.UpdateRecInRunner(label14.Text, rannerId,3, textBox2.Text, textBox4.Text, textBox5.Text, comboBox1.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm:ss"), textBox7.Text, comboBox2.Text);
                }
                if (textBox4.Text != "" && textBox5.Text != "" && textBox2.Text != "")
                {
                    scc.UpdateRecInRunner(label14.Text, rannerId,4, textBox2.Text, textBox4.Text, textBox5.Text, comboBox1.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm:ss"), textBox7.Text, comboBox2.Text);
                }
                if (textBox4.Text == "" && textBox5.Text == "" && textBox2.Text != "")
                {
                    scc.UpdateRecInRunner(label14.Text, rannerId, 5, textBox2.Text, textBox4.Text, textBox5.Text, comboBox1.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm:ss"), textBox7.Text, comboBox2.Text);
                }
                if (textBox4.Text == "" && textBox5.Text != "" && textBox2.Text != "")
                {
                    scc.UpdateRecInRunner(label14.Text, rannerId, 6, textBox2.Text, textBox4.Text, textBox5.Text, comboBox1.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm:ss"), textBox7.Text, comboBox2.Text);
                }
                if (textBox4.Text != "" && textBox5.Text == "" && textBox2.Text != "")
                {
                    scc.UpdateRecInRunner(label14.Text, rannerId, 7, textBox2.Text, textBox4.Text, textBox5.Text, comboBox1.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm:ss"), textBox7.Text, comboBox2.Text);
                }
            }
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(textBox4.Text == "")
            {
                label17.Visible = true;
            }
            else
            {
                label17.Visible = false;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                label18.Visible = true;
            }
            else
            {
                label18.Visible = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                label15.Visible = true;
            }
            else
            {
                label15.Visible = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                label16.Visible = true;
            }
            else
            {
                label16.Visible = false;
            }
        }
    }
}
