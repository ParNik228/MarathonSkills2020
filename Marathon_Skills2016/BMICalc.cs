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
    public partial class BMICalc : Form
    {
        public BMICalc()
        {
            InitializeComponent();
            //Bitmap image1 = new Bitmap("images//male-icon.png");

            pictureBox1.Image = Properties.Resources.male_icon;
            pictureBox2.Image = Properties.Resources.female_icon;
            pictureBox4.Image = Properties.Resources.icons8_sort_down_32;
            pictureBox5.Image = Properties.Resources.icons8_sort_down_32;
            pictureBox6.Image = Properties.Resources.icons8_sort_down_32;
            pictureBox7.Image = Properties.Resources.icons8_sort_down_32;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal bmi = 0;
            try
            {
                bmi = numericUpDown2.Value / (numericUpDown1.Value*numericUpDown1.Value) * 10000;
                bmi = Math.Round(bmi, 2);
                if (Convert.ToDouble(bmi) < 18.5)
                {
                    panel7.Visible = true;
                    panel10.Visible = false;
                    panel8.Visible = false;
                    panel9.Visible = false;
                    label8.Text = bmi.ToString();
                    pictureBox3.Image = Properties.Resources.bmi_underweight_icon;
                }
                if (Convert.ToDouble(bmi) >= 18.5 && Convert.ToDouble(bmi) <= 24.9)
                {
                    panel8.Visible = true;
                    panel10.Visible = false;
                    panel7.Visible = false;
                    panel9.Visible = false;
                    label9.Text = bmi.ToString();
                    pictureBox3.Image = Properties.Resources.bmi_healthy_icon;
                }
                if (Convert.ToDouble(bmi) >= 25 && Convert.ToDouble(bmi) <= 29.9)
                {
                    panel9.Visible = true;
                    panel10.Visible = false;
                    panel7.Visible = false;
                    panel8.Visible = false;
                    label10.Text = bmi.ToString();
                    pictureBox3.Image = Properties.Resources.bmi_overweight_icon;
                }
                if (Convert.ToDouble(bmi) >= 30)
                {
                    panel10.Visible = true;
                    panel7.Visible = false;
                    panel8.Visible = false;
                    panel9.Visible = false;
                    label12.Text = bmi.ToString();
                    pictureBox3.Image = Properties.Resources.bmi_obese_icon;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source, "Оповещение системы!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            MoreInfoForm mif = new MoreInfoForm();
            mif.ShowDialog();
            Close();
        }
    }
}
