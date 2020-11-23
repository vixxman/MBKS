using System;
using System.Linq;
using System.Windows.Forms;

namespace MBKS3_16
{
    public partial class EditRoles : Form
    {
        Form1 f;
        Roles r;
        Users u;
        public EditRoles(Form1 f)
        {
            InitializeComponent();
            this.f = f;
            r = f.roles;
            u = f.users;
            for (int i = 0; i < f.AllUsers.Length; i++)
            {
                comboBoxUsersList.Items.Add(f.AllUsers[i]);
            }
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    if (r.roles[i,j]==1)
                        ((CheckBox)Controls["checkBox" + (i * 5 + j + 1).ToString()]).Checked = true;
                    else ((CheckBox)Controls["checkBox" + (i * 5 + j + 1).ToString()]).Checked = false;
                }
                
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            f.roles = r;
            f.users = u;
            f.writeRoles(r);
            f.writeUsers(u);
            Dispose();
        }

        private void comboBoxUsersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxUsersRoles.Text = u.users[comboBoxUsersList.Items.IndexOf(comboBoxUsersList.Text)];
        }

        private void textBoxUsersRoles_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUsersRoles.Text.Length == 1)
            {
                u.users[comboBoxUsersList.Items.IndexOf(comboBoxUsersList.Text)] = textBoxUsersRoles.Text;
            }
            else MessageBox.Show("Некорректная роль!");
        }

        private void checkBoxChanged(object sender, EventArgs e)
        {
            CheckBox ch = (CheckBox)sender;
            int n = Int32.Parse(ch.Name.TrimStart('c', 'h', 'e', 'k', 'B', 'o', 'x'));
            if (ch.Checked)
            {
                if (n-1 < 5) r.roles[0, n - 1] = 1;
                else {
                    if (n-1 < 10 && n-1 > 4) r.roles[1, ((n-1) % 5)] = 1;
                    else r.roles[2, ((n-1) % 5)] = 1;
                }
            }
            else
            {
                if (n-1 < 5) r.roles[0, n - 1] = 0;
                else {
                    if (n-1 < 10 && n-1 > 4) r.roles[1, ((n-1) % 5)] = 0;
                    else r.roles[2, ((n-1) % 5) ] = 0;
                }
            }
        }
    }
}
