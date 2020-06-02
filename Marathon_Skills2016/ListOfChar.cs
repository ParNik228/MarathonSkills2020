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
    public partial class ListOfChar : Form
    {
       public List<string> ls;
        public ListOfChar()
        {
            InitializeComponent();
            SqlConnClass scc = new SqlConnClass();
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGridView1.AllowUserToAddRows = false;
            ListOfChar loc = this;
            
           
 
            scc.ListOfCharReader(loc);

            //ls = scc.listLs();
            //imgAdd();
        }
        public void imgAdd(string str,string about)
        {
            ListViewItem lvi = new ListViewItem();
            ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
            if (str == "arise-logo.png")
            {
                lvi.ImageIndex = 0;
            }
           
            if(str== "aves-do-brazil-logo.png")
            {
                    lvi.ImageIndex = 1;
            }        
               
            if(str== "clara-santos-oliveira-institute-logo.png")
            {
                        lvi.ImageIndex = 2;
            }      
                    
             if(str== "conquer-cancer-brazil.png")
             {
                            lvi.ImageIndex = 3;
             }
                       
             if(str== "diabetes-brazil-logo.png")
              {
                                lvi.ImageIndex = 4;
              }
            if(str== "heart-health-sao-paulo-logo.png")
            {
                lvi.ImageIndex = 5;
            }
            if (str == "human-rights-centre-logo.png")
                lvi.ImageIndex = 6;
            if (str == "oxfam-international-logo.png")
                lvi.ImageIndex = 7;
            if (str == "querstadtein-logo.png")
                lvi.ImageIndex = 8;
            if(str== "save-the-children-fund-logo.png")
            {
                lvi.ImageIndex = 9;
            }
            if (str == "stay-pumped-logo.png")
                lvi.ImageIndex = 10;
            if (str == "the-red-cross-logo.png")
                lvi.ImageIndex = 11;
            if (str == "upbeat-logo.png")
                lvi.ImageIndex = 12;
            if (str == "wwsm-rescue-logo.png")
                lvi.ImageIndex = 13;
            lvsi.Text = about;
            lvi.SubItems.Add(lvsi);

            listView1.Items.Add(lvi);
           // listView1.Items.
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
