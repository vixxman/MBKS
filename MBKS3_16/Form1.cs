using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Security.AccessControl;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace MBKS3_16
{
    public partial class Form1 : Form
    {
        string SelectedUser = "";
        public string Path = "";
        DirectorySecurity Dirsec;
        public List<string> AllFiles = new List<string>();
        public string[] AllUsers = new string[] {"user1", "user2", "user3" };
        bool readAllow = false;
        string pathFile = "";
        public Roles roles;
        public Users users;


        public Form1()
        {
            InitializeComponent();
        }

        public string SelectedUser1 { get => SelectedUser; set => SelectedUser = value; }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm(this);
            lf.ShowDialog();
            this.Text = "Welcome " + SelectedUser;
            if (SelectedUser != "admin")
            {
                button2.Enabled = false;
            }
            else
            {
                listView1.Enabled = false;
                contextMenuStrip1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            textBox1.Text = Path = dialog.SelectedPath;
            Dirsec = Directory.GetAccessControl(Path);
            UnlockDir(Path);
            treeView1.Nodes.Clear();
            TreeNode dirNode = new TreeNode();
            treeView1.Nodes.Add(Path);
            FillTreeNode(treeView1.Nodes[0], Path);
            if (AllFiles.Contains(Path + "\\Users.txt") && AllFiles.Contains(Path + "\\Roles.txt"))
            {
                SoapFormatter formatter = new SoapFormatter();
                using (FileStream fs = new FileStream(Path + "\\Roles.txt", FileMode.Open))
                {
                    this.roles = (Roles)formatter.Deserialize(fs);
                    fs.Close();
                }
                using (FileStream fs = new FileStream(Path + "\\Users.txt", FileMode.Open))
                {
                    this.users = (Users)formatter.Deserialize(fs);
                    fs.Close();
                }
            }
            else
            {
                FileStream ff = File.Create(Path + "\\Roles.txt");
                ff.Close();
                FileStream af = File.Create(Path + "\\Users.txt");
                af.Close();
                AllFiles.Add(Path + "\\Roles.txt");
                AllFiles.Add(Path + "\\Users.txt");
                this.roles = new Roles(); 
                this.users = new Users();
            }
            if(SelectedUser!="admin")
            {
                checkRule();
            }
            writeRoles(roles);
            writeUsers(users);
            LockDir(Path);
        }

        public void writeUsers(Users users)
        {
            this.users = users;
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream fs = new FileStream(Path + "\\Users.txt", FileMode.Create))
            {
                formatter.Serialize(fs, users);
                fs.Close();
            }
        }

        public void writeRoles(Roles roles)
        {
            this.roles = roles;
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream fs = new FileStream(Path + "\\Roles.txt", FileMode.Create))
            {
                formatter.Serialize(fs, roles);
                fs.Close();
            }
        }


        private void FillTreeNode(TreeNode driveNode, string path)
        {
            string[] dirs = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);
            if (files.Length != 0)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    AllFiles.Add(files[i]);
                }
            }
            if (dirs.Length == 0) { return; }

            for (int i = 0; i < dirs.Length; i++)
            {
                TreeNode dirNode = new TreeNode();
                dirNode.Text = dirs[i].Remove(0, dirs[i].LastIndexOf("\\") + 1);
                driveNode.Nodes.Add(dirNode);
                FillTreeNode(dirNode, dirs[i]);
            }
        }

        private string getFullPath(TreeNode node)
        {
            string str = "";
            if (node.Text != Path)
            {

                str = str.Insert(0, getFullPath(node.Parent));
                str += node.Text;
                str += "\\";
            }
            else
            {
                str = str.Insert(0, Path);
                str += "\\";
            }
            return str;
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            listView1.Clear();
            string fullPath = getFullPath(e.Node);
            UnlockDir(Path);
            string[] files = Directory.GetFiles(fullPath);
            for (int i = 0; i < files.Length; i++)
            {
                if (!AllFiles.Contains(files[i])) AllFiles.Add(files[i]);
                ListViewItem lvi = new ListViewItem();
                lvi.Text = files[i].Remove(0, files[i].LastIndexOf('\\') + 1);
                lvi.ImageIndex = 0;
                listView1.Items.Add(lvi);
            }
            LockDir(Path);
        }

        public void LockDir(string Path)
        {
            FileSystemAccessRule fsa = new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny);
            Dirsec.AddAccessRule(fsa);
            Directory.SetAccessControl(Path, Dirsec);

        }

        private void UnlockDir(string Path)
        {
            FileSystemAccessRule fsa = new FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny);
            Dirsec.RemoveAccessRule(fsa);
            Directory.SetAccessControl(Path, Dirsec);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            UnlockDir(Path);
            string[] Files = Directory.GetFiles(Path, listView1.SelectedItems[0].SubItems[0].Text, SearchOption.AllDirectories);
            pathFile = Files[0];
            if (SelectedUser == "admin")
                readAllow = false;
            if (readAllow)
            {
                FileInfo info = new FileInfo(pathFile);
                Process proc = new Process();
                info.Attributes = FileAttributes.ReadOnly;
                proc.StartInfo.FileName = info.FullName;
                proc.Start();
                LockDir(Path);
                while (!proc.HasExited)
                {
                    System.Threading.Thread.Sleep(2000);
                }
                info.Attributes = FileAttributes.Normal;
            }
            else MessageBox.Show("Чтение недоступно!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditRoles er = new EditRoles(this);
            er.ShowDialog();
        }

        public void checkRule()
        {
            int n = Int32.Parse(SelectedUser.Substring(SelectedUser.Length - 1, 1));
            n--;
            int ruleNum = Int32.Parse(users.users[n]);
            if (roles.roles[ruleNum - 1, 0] == 1) readAllow = true;
            else readAllow=false;
            if (roles.roles[ruleNum-1, 1] == 1) перезаписатьToolStripMenuItem.Enabled = true;
            else перезаписатьToolStripMenuItem.Enabled = true;
            if (roles.roles[ruleNum-1, 2] == 1) изменитьРасширениеToolStripMenuItem.Enabled = true;
            else изменитьРасширениеToolStripMenuItem.Enabled = false;
            if (roles.roles[ruleNum-1, 3] == 1) просмотретьАтрибутыToolStripMenuItem.Enabled = true;
            else просмотретьАтрибутыToolStripMenuItem.Enabled = false;
            if (roles.roles[ruleNum-1, 4] == 1) изменитьАтрибутыToolStripMenuItem.Enabled = true;
            else изменитьАтрибутыToolStripMenuItem.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm(this);
            lf.ShowDialog();
        }

        private void перезаписатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnlockDir(Path);
            string[] Files = Directory.GetFiles(Path, listView1.SelectedItems[0].SubItems[0].Text, SearchOption.AllDirectories);
            pathFile = Files[0];
            FileStream fs = new FileStream(pathFile, FileMode.Create);
            fs.Close();
            FileInfo info = new FileInfo(pathFile);
            Process proc = new Process();
            proc.StartInfo.FileName = info.FullName;
            proc.Start();
            LockDir(Path);
            while (!proc.HasExited)
            {
                System.Threading.Thread.Sleep(2000);
            }
        }

        private void изменитьРасширениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnlockDir(Path);
            string[] Files = Directory.GetFiles(Path, listView1.SelectedItems[0].SubItems[0].Text, SearchOption.AllDirectories);
            pathFile = Files[0];
            EditExc ex = new EditExc(pathFile, this);
            ex.Show();

        }

        private void просмотретьАтрибутыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnlockDir(Path);
            string[] Files = Directory.GetFiles(Path, listView1.SelectedItems[0].SubItems[0].Text, SearchOption.AllDirectories);
            pathFile = Files[0];
            FileAttributes fa = File.GetAttributes(pathFile);
            MessageBox.Show(fa.ToString());
            LockDir(Path);
        }

        private void изменитьАтрибутыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnlockDir(Path);
            string[] Files = Directory.GetFiles(Path, listView1.SelectedItems[0].SubItems[0].Text, SearchOption.AllDirectories);
            pathFile = Files[0];
            EditAttr ea = new EditAttr(pathFile);
            ea.Show();
            LockDir(Path);
        }
    }
}
