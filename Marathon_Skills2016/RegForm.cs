using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marathon_Skills2016
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
            RegForm rf = this;
            SqlConnClass scc = new SqlConnClass();
            scc.RegFormLoad(rf);
        }

        private void label3_Click(object sender, EventArgs e)
        {

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                label15.Visible = true;
            }
            else
                label15.Visible = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                label16.Visible = true;
            }
            else
                label16.Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                label17.Visible = true;
            }
            else
                label17.Visible = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                label18.Visible = true;
            }
            else
                label18.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            //string fileText = System.IO.File.ReadAllText(filename);
            pictureBox1.Load(filename);
            textBox7.Text = filename;
            label10.Visible = false;
        }
        bool validateEmail(string email)
        {
            string[] words = email.Split('@');
            if (words.Length != 2)
                return false;
            string[] dotdomen = words[1].Split('.');
            if (dotdomen.Length != 2)
                return false;
            return true;
        }
        bool passCheck(string password)
        {
            if (password.Length > 5)
            {
                string symb = "ABCDEFGHIJKLMNOPRSTUVWXYZ123456789!#$%@^";
                if (password.IndexOfAny(symb.ToCharArray()) == -1)
                {
                   // Console.Write("Пароль неверный");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int year = DateTime.Now.Year - dateTimePicker1.Value.Year;
            
            bool psCheck = passCheck(textBox2.Text);
            bool emCheck=validateEmail(textBox1.Text);
           if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "" || comboBox2.Text == ""||textBox7.Text=="")
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                if (year >= 10)
                {
                if (emCheck)
                {
                    if (psCheck)
                    {
                        MessageBox.Show("True");
                    if (textBox2.Text == textBox3.Text)
                    {
                        SqlConnClass scc = new SqlConnClass();
                        string dt = dateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm:ss");
                        scc.RegRunnrAdd(textBox1.Text, textBox4.Text, textBox5.Text, textBox2.Text, comboBox1.Text, dt, comboBox2.Text,textBox7.Text);
                        ActiveForm.Hide();
                        RegEventForm rf = new RegEventForm();
                        rf.ShowDialog();
                        Close();
                        }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают");
                    }
                    }
                    else
                    {
                        MessageBox.Show("Пароль не удовлетворяет требованиям\n-Минимум 6 символов\n-Минимум 1 прописная буква\n-По крайней мере один из следующих символов: ! @ # $ % ^");
                    }

                    
                }
                else
                    MessageBox.Show("Неверный адрес эл. почты");
                }
                else
                {
                    MessageBox.Show("В марафоне могут принять участие люди достигшие 10 лет и старше!");
                }
               
            }
               
            
        }
    }
}
