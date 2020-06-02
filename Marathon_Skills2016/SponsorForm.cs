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
    public partial class SponsorForm : Form
    {
        int sum;
        
        static DateTime GetStartTime()
        {
            SqlConnClass scc = new SqlConnClass();
            string date = scc.Connection();

            return Convert.ToDateTime(date);
        }

        DateTime voteTime = GetStartTime(); //new DateTime(2020,11,24,6,0,0);
        Timer tm = new Timer();
        public SponsorForm()
        {
            InitializeComponent();
            label19.Text = "$" + textBox2.Text;
            SponsorForm sf = this;
            SqlConnClass scc= new SqlConnClass();
            scc.ConectRunnerFoeSponsor(sf);
            
            tm.Tick += timer1_Tick;
            tm.Interval = 1000;
            tm.Enabled = true;
            tm.Start();
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                label12.Visible = true;
            }
            else
                label12.Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.MaxLength = 16;
            
            string cardnumber;
            int length;
            if (textBox4.Text == "")
            {
                label13.Visible = true;

            }
            else
            {
                label13.Visible = false;
                cardnumber = textBox4.Text;
                length = cardnumber.Length;
                
                /*if (length == 4||length==9||length==14)
                {
                    
                    textBox4.Text += " ";
                    textBox4.SelectionStart=length+1;
                    textBox4.Focus();
                }*/
               
            }
                
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.MaxLength = 2;
            if (textBox5.Text == "")
            {
                label15.Visible = true;
            }
            else
                label15.Visible = false;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.MaxLength = 4;
            if (textBox6.Text == "")
            {
                label16.Visible = true;
            }
            else
                label16.Visible = false;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox7.MaxLength = 3;
            if (textBox7.Text == "")
            {
                label17.Visible = true;
            }
            else
                label17.Visible = false;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                label19.Text = "$0";
                sum = 0;
            }else
            label19.Text = "$" + textBox2.Text;
            sum = Convert.ToInt32(textBox2.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                sum = 0;
                sum += 10;
                textBox2.Text = Convert.ToString(sum);
            }
            else
            {
                sum = Convert.ToInt32(textBox2.Text);
                sum += 10;
                textBox2.Text = Convert.ToString(sum);
            }
            
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                sum = 0;
                /*sum -= 10;
                textBox2.Text = Convert.ToString(sum);*/
            }
            else
            {
                sum = Convert.ToInt32(textBox2.Text);
                if (sum == 0)
                {

                }
                else
                {
                     sum -= 10;
                    textBox2.Text = Convert.ToString(sum);
                }
                
               
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            Form1 fr = new Form1();
            fr.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ""||comboBox1.Text==""||textBox3.Text==""|| textBox4.Text == ""|| textBox5.Text == ""|| textBox6.Text == ""|| textBox7.Text == ""||label19.Text=="$0")
            {
                MessageBox.Show("Какие то поля не заполнены либо сумма равна 0!");
            }
            else
            {
                ActiveForm.Hide();
                SponsConfirm sc = new SponsConfirm(comboBox1.Text,label20.Text,label19.Text);
                sc.ShowDialog();
                Close();
            }

           
            
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            string [] str1;
            str = comboBox1.Text;
            str1 = str.Split(' ');
            SqlConnClass scc = new SqlConnClass();
            SponsorForm sf = this;
            scc.CharityForRunner(sf, str1[0]);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan TimeRemaining = voteTime - DateTime.Now;
            label21.Text = TimeRemaining.Days + " дней " + TimeRemaining.Hours + " часов " + TimeRemaining.Minutes + " минут " + TimeRemaining.Seconds + " секунд";
        }
    }
}
