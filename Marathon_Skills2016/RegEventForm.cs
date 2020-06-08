using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marathon_Skills2016
{
    public partial class RegEventForm : Form
    {
        int chb1 = 0;
        int chb2 = 0;
        int chb3 = 0;
        int rb = 0;
        string kit;
        int summary;

        int runnerId;
        
        static DateTime GetStartTime()
        {
            SqlConnClass scc = new SqlConnClass();
            string date = scc.Connection();
            return Convert.ToDateTime(date);
        }
        DateTime voteTime = GetStartTime();
        Timer tm = new Timer();
        public RegEventForm(int id)
        {
            InitializeComponent();
            tm.Tick += timer1_Tick;
            tm.Interval = 1000;
            tm.Enabled = true;
            tm.Start();
            runnerId = id;
            SqlConnClass scc = new SqlConnClass();
            RegEventForm rf = this;
            scc.RegEventLoad(rf);
            sumCalc();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan TimeRemaining = voteTime - DateTime.Now;
            label19.Text = TimeRemaining.Days + " дней " + TimeRemaining.Hours + " часов " + TimeRemaining.Minutes + " минут до старта марафона!";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public void sumCalc()
        {
            SqlConnClass scc = new SqlConnClass();
            if (checkBox1.Checked)
            {
                chb1 = 145;
                
            }
            else
            {
                chb1 = 0;
            }
            if (checkBox2.Checked)
            {
                    chb2 = 75;
                    
            }
            else { chb2 = 0; }
            if (checkBox3.Checked)
                    {
                        chb3 = 20;
                       
                    }
            else { chb3 = 0; }
            if (radioButton1.Checked)
                        {
                            rb = scc.RegEventCalc("SELECT Cost FROM racekitoption WHERE RaceKitOption = 'Runner''s bib + RFID bracelet'");
                kit = "A";
                        }
                        else
                        {
                            if (radioButton2.Checked)
                            {
                                rb = scc.RegEventCalc("SELECT Cost FROM racekitoption WHERE RaceKitOption = 'Option A + hat + water bottle'");
                    kit = "B";
                            }
                            else
                            {
                                if (radioButton3.Checked)
                                {
                                    rb = scc.RegEventCalc("SELECT Cost FROM racekitoption WHERE RaceKitOption = 'Option B + T-shirt + souvenir booklet'");
                        kit = "C";
                                }
                            }
                        }
            
               //sum = Convert.ToInt32(textBox1.Text);
            summary = chb1 + chb2 + chb3 + rb;
            label8.Text = "$" + summary.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            sumCalc();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            sumCalc();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            sumCalc();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            sumCalc();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            sumCalc();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            sumCalc();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label14.Visible = true;
                
            }
            else
            {
                label14.Visible = false;
                
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==""||comboBox1.Text=="")
            {
                MessageBox.Show("Не все поля заполнены!!!");
            }
            else
            {
                SqlConnClass scc = new SqlConnClass();

                scc.InsDataFromRegistration(runnerId,DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),kit,summary,comboBox1.Text,Convert.ToInt32(textBox1.Text));
                
                ActiveForm.Hide();
                RegConfirm rf = new RegConfirm(runnerId);
                rf.ShowDialog();
                Close();

            }
        }
    }
}
