using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab10
{
    class MainForm : Form
    {
        Label l;
        Button b1, b2;
        public MainForm()
        {
            Text = "Лабораторная работа 9 - А.Исабеков";
            l = new Label();
            l.Text = "Выберите тип объектов";
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.Font = new Font("Calibri", 14);
            l.Size = new Size(225, 50);
            l.Location = new Point(35, 25);
            l.Parent = this;
            b1 = new Button();
            b1.Text = "Array";
            b1.Font = new Font("Calibri", 18);
            b1.Size = new Size(100, 50);
            b1.Location = new Point(100, 100);
            b1.Parent = this;
            b1.Click += new EventHandler(B1_Click);
            b2 = new Button();
            b2.Text = "List";
            b2.Font = new Font("Calibri", 18);
            b2.Size = new Size(100, 50);
            b2.Location = new Point(100, 175);
            b2.Parent = this;
            b2.Click += new EventHandler(B2_Click);
        }
        private void B2_Click(object sender, EventArgs e)
        {
            /* MyForm mf = new MyForm(this, new PList());
            mf.Activate();
            mf.Visible = true;
            Visible = false; */
        }
        private void B1_Click(object sender, EventArgs e)
        {
            /* MyForm mf = new MyForm(this, new PArray());
            mf.Activate();
            mf.Visible = true;
            Visible = false; */
        }
    }
}
