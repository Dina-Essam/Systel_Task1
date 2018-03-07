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
    public partial class devices : Form
    {
        internal Users u;
        static system_handdling fun = new system_handdling();
        List<int> groupids = new List<int>();

        internal devices(Users u)
        {
            InitializeComponent();
            this.u = u;
            groupids = fun.loadgroupid();
            foreach (int element in groupids)
            {
                comboBox1.Items.Add(element);
                gid.Items.Add(element);
            }
        }

        private void devices_Load(object sender, EventArgs e)
        {
            group.Text = "Group " +u.groupid;
            dataGridView1.DataSource = fun.allDevices(u.groupid);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fun.changeGroup((int)comboBox1.SelectedItem, u.userid);
            u.groupid = (int)comboBox1.SelectedItem;
            group.Text = "Group " + u.groupid;
            dataGridView1.DataSource = fun.allDevices(u.groupid);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fun.insertdevice(name.Text.ToString(), (int)gid.SelectedItem, Int32.Parse(pn.Text), Int32.Parse(cc.Text), Int32.Parse(mod.Text), ip.Text);
            clear();
            MessageBox.Show("Succefully Added");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clear();
        }
        void clear()
        {
            name.Text = "";
            gid.Text = "";
            pn.Text = "";
            cc.Text = "";
            mod.Text = "";
            ip.Text = "";
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if(dataGridView1.CurrentRow.Index !=-1)
                {
                    name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    gid.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    pn.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    cc.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    mod.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    if (dataGridView1.CurrentRow.Cells[6].Value != null)
                        ip.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    else
                        ip.Text = "";
                    button2.Enabled = true;
                    button1.Enabled = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fun.deletedevice((int)dataGridView1.CurrentRow.Cells[0].Value);
            clear();
        }
    }
}
