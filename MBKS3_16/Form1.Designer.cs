using System.IO;

namespace MBKS3_16
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            UnlockDir(Path);
            File.Delete(Path + "\\Label.txt");
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.перезаписатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьРасширениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотретьАтрибутыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьАтрибутыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(271, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(290, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "Выбрать папку";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(13, 40);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(142, 186);
            this.treeView1.TabIndex = 3;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Location = new System.Drawing.Point(162, 40);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(253, 292);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.SmallIcon;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.перезаписатьToolStripMenuItem,
            this.изменитьРасширениеToolStripMenuItem,
            this.просмотретьАтрибутыToolStripMenuItem,
            this.изменитьАтрибутыToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(204, 114);
            // 
            // перезаписатьToolStripMenuItem
            // 
            this.перезаписатьToolStripMenuItem.Name = "перезаписатьToolStripMenuItem";
            this.перезаписатьToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.перезаписатьToolStripMenuItem.Text = "Перезаписать";
            this.перезаписатьToolStripMenuItem.Click += new System.EventHandler(this.перезаписатьToolStripMenuItem_Click);
            // 
            // изменитьРасширениеToolStripMenuItem
            // 
            this.изменитьРасширениеToolStripMenuItem.Name = "изменитьРасширениеToolStripMenuItem";
            this.изменитьРасширениеToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.изменитьРасширениеToolStripMenuItem.Text = "Изменить расширение";
            this.изменитьРасширениеToolStripMenuItem.Click += new System.EventHandler(this.изменитьРасширениеToolStripMenuItem_Click);
            // 
            // просмотретьАтрибутыToolStripMenuItem
            // 
            this.просмотретьАтрибутыToolStripMenuItem.Name = "просмотретьАтрибутыToolStripMenuItem";
            this.просмотретьАтрибутыToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.просмотретьАтрибутыToolStripMenuItem.Text = "Просмотреть атрибуты";
            this.просмотретьАтрибутыToolStripMenuItem.Click += new System.EventHandler(this.просмотретьАтрибутыToolStripMenuItem_Click);
            // 
            // изменитьАтрибутыToolStripMenuItem
            // 
            this.изменитьАтрибутыToolStripMenuItem.Name = "изменитьАтрибутыToolStripMenuItem";
            this.изменитьАтрибутыToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.изменитьАтрибутыToolStripMenuItem.Text = "Изменить атрибуты";
            this.изменитьАтрибутыToolStripMenuItem.Click += new System.EventHandler(this.изменитьАтрибутыToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 284);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 48);
            this.button2.TabIndex = 5;
            this.button2.Text = "Настройка прав доступа";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 232);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(142, 46);
            this.button3.TabIndex = 6;
            this.button3.Text = "Сменить пользователя";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 344);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView treeView1;
        public System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem перезаписатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьРасширениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem просмотретьАтрибутыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьАтрибутыToolStripMenuItem;
    }
}

