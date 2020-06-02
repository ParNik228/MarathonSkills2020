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
        public RunnerMenu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            RegEventForm reg = new RegEventForm();
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
            EditProfileForm epf = new EditProfileForm();
            epf.ShowDialog();
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            MyResForm mrf = new MyResForm();
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
    }
}
