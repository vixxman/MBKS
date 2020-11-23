using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MBKS3_16
{
    public partial class EditAttr : Form
    {
        string path;
        public EditAttr(string path)
        {
            InitializeComponent();
            label1.Text = path.Substring(path.LastIndexOf('\\')+1, path.Length- path.LastIndexOf('\\')-1);
            this.path = path;
            FileAttributes fa = File.GetAttributes(path);
            string str = fa.ToString();
            if (str.Contains("ReadOnly")) checkBox1.Checked = true;
            if (str.Contains("Hidden")) checkBox2.Checked = true;
            if (str.Contains("System")) checkBox3.Checked = true;
            if (str.Contains("Archive")) checkBox4.Checked = true;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            FileAttributes fa = File.GetAttributes(path);
            for (int i = 0; i < 4; i++)
            {
                if(((CheckBox)Controls["checkBox" + (i + 1).ToString()]).Checked == true)
                {
                    switch (i)
                    {
                        case 0:
                            File.SetAttributes(path, fa | FileAttributes.ReadOnly);
                            fa = File.GetAttributes(path);
                            break;
                        case 1:
                            File.SetAttributes(path, fa | FileAttributes.Hidden);
                            fa = File.GetAttributes(path);
                            break;
                        case 2:
                            File.SetAttributes(path, fa | FileAttributes.System);
                            fa = File.GetAttributes(path);
                            break;
                        case 3:
                            File.SetAttributes(path, fa| FileAttributes.Archive);
                            fa = File.GetAttributes(path);
                            break;
                    }
                }
                else
                {
                    switch (i)
                    {
                        case 0:
                            fa = RemoveAttribute(fa, FileAttributes.ReadOnly);
                            File.SetAttributes(path, fa);
                            fa = File.GetAttributes(path);
                            break;
                        case 1:
                            fa =RemoveAttribute(fa, FileAttributes.Hidden);
                            File.SetAttributes(path, fa);
                            fa = File.GetAttributes(path);
                            break;
                        case 2:
                            fa= RemoveAttribute(fa, FileAttributes.System);
                            File.SetAttributes(path, fa);
                            fa = File.GetAttributes(path);
                            break;
                        case 3:
                            fa = RemoveAttribute(fa, FileAttributes.Archive);
                            File.SetAttributes(path, fa);
                            fa = File.GetAttributes(path);
                            break;
                    }
                }
            }
            Dispose();
        }


        private FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }
    }
}
