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
    public partial class EditExc : Form
    {
        string path = "";
        Form1 f;
        public EditExc(string path, Form1 f)
        {
            InitializeComponent();
            this.path = path;
            this.f = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ind = path.LastIndexOf('\\');
            string newName = path.Remove(path.LastIndexOf('.'), path.Length - path.LastIndexOf('.')) + '.' + textBox1.Text;
            File.Move(path, newName);
            Dispose();
        }
    }
}
