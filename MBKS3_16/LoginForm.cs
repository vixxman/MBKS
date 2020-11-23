using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MBKS3_16
{
    public partial class LoginForm : Form
    {
        Form1 f;
        string[] pass = new string[] { "admin", "user1", "user2", "user3" };

        public LoginForm()
        {
            InitializeComponent();
        }


        public LoginForm(Form1 f)
        {
            this.f = f;
            InitializeComponent();
            f.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pass[comboBox1.SelectedIndex] == textBoxPass.Text)
            {
                f.SelectedUser1 = comboBox1.SelectedItem.ToString();
                f.Text = "Welcome " + f.SelectedUser1;
                this.Close();
                f.Enabled = true;
                if (f.SelectedUser1 != "admin")
                {
                    f.contextMenuStrip1.Enabled = true;
                    f.button2.Enabled = false;
                    f.Enabled = true;
                    f.listView1.Enabled = true;
                    f.checkRule();
                }
                else
                {
                    f.button2.Enabled = true;
                    f.contextMenuStrip1.Enabled = false;
                }
            }
            else MessageBox.Show("Неверный пароль!");
        }
    }
}
