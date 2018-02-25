using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Systel_Task1
{
    public partial class signin : Form
    {
        static system_handdling fun = new system_handdling();
        static Users user1 = new Users();
        List<int> groupids = new List<int>();
        public signin()
        {
            InitializeComponent();
            groupids=fun.loadgroupid();
            foreach(int element in groupids)
            {
                gisu.Items.Add(element);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (unln.Text.ToString() == "" || passln.Text.ToString() == "")
            {
                MessageBox.Show("Enter Username and Password");
            }
            else
            {
                user1 = fun.getuser(unln.Text.ToString(), passln.Text.ToString());
                if(user1==null)
                {
                    unln.Clear(); passln.Clear();
                }
                else
                {
                    //to next form
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            user1.username = unsu.Text.ToString();
            user1.password = passsu.Text.ToString();
            user1.groupid = (int)gisu.SelectedItem;
            if (psu.Enabled == true)
                user1.privilege = Int32.Parse(psu.Text);
            fun.setuser(user1);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                psu.Enabled = true;
            }
            else
                psu.Enabled = false;
        }
    }
}
