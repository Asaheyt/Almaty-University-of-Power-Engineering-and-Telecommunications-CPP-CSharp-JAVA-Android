using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace lab7
{
    class FormA : Form
    {
        Button b = new Button();
        Button ba = new Button();
        TextBox ta = new TextBox();
        LinkLabel la = new LinkLabel();
        public FormA()
        {
            Text = "Form A";
            
            b.Parent = this;
            b.Text = "Go To Form B";
            b.Location = new Point(40, 40);
            b.Size = new Size(b.Width + 60, b.Height);
            b.Click += B_Click;

            ba.Parent = this;
            ba.Text = "KeyDown";
            ba.KeyDown += Ba_KeyDown;

            ta.Parent = this;
            ta.Text = "DoubleClick";
            ta.Top += 100;
            ta.DoubleClick += Ta_DoubleClick;

            la.Parent = this;
            la.Text = "Leave";
            la.Top += 75;
            la.Left += 100;
            la.Leave += La_Leave;
        }
        private void La_Leave(object sender, EventArgs e)
        {

            Label r = new Label();
            r.Parent = this;
            r.Location = new Point(100, 20);
            MessageBox.Show("RichTextBox Rtb_MouseMove\nThis is Leave on the top");


        }
        private void Ta_DoubleClick(object sender, EventArgs e)
        {
            ta.Top -= 20;
        }
        private void Ba_KeyDown(object sender, KeyEventArgs e)
        {
            ba.Top += 20;
        }
        private void B_Click(object sender, EventArgs e)
        {
            FormB b = new FormB(this);
            b.Activate();
            b.Visible = true;
            Visible = false;
        }
      
    }
    class FormB : Form
    {
        FormA aa;
        Label lb = new Label();
        CheckBox cb = new CheckBox();
        RichTextBox rtb = new RichTextBox();
        Button b = new Button();
        public FormB(FormA a)
        {
            aa = a;
            Text = "Form B";
            DoubleClick += FormB_DoubleClick;
            FormClosing += FormB_FormClosing;
            KeyPress += FormB_KeyPress;

            lb.Parent = this;
            lb.Size = new Size(40, 60);
            lb.Text = "MouseCaptureChanged";
            lb.MouseCaptureChanged += Lb_MouseCaptureChanged;
           

            cb.Parent = this;
            cb.Top = 200;
            cb.Text = "KeyPress";
            cb.KeyPress += Cb_KeyPress;

            rtb.Parent = this;
            rtb.Text = "Click";
            rtb.Top = 70;
            rtb.Click += Rtb_Click;
            

            b.Parent = this;
            b.Location = new Point(140, 100);
            b.Text = "Go To Form C";
            b.Size = new Size(b.Width + 60, b.Height);
            b.Click += B_Click;
        }

        

        private void B_Click(object sender, EventArgs e)
        {
            FormC c = new FormC(this);
            c.Activate();
            c.Visible = true;
            Visible = false;
        }

        private void Rtb_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Cb_KeyPress(object sender, EventArgs e)
        {
            bool colour = true;
            if (colour)
                this.ForeColor = System.Drawing.Color.Red;
            else
                this.ForeColor = System.Drawing.Color.Chocolate;
            colour = !colour;

        }

        private void Lb_MouseCaptureChanged(object sender, EventArgs e)
        {
            lb.Left += 20;
        }



        private void FormB_KeyPress(object sender, KeyPressEventArgs e)
        {
            Width -= 50;
        }
        private void FormB_FormClosing(object sender, FormClosingEventArgs e)
        {
            Location = new Point(Location.X, Location.Y - 50);
            aa.Visible = true;
        }
        private void FormB_DoubleClick(object sender, EventArgs e)
        {
            Location = new Point(Location.X - 50, Location.Y);
        }
    }
    class FormC : Form
    {
        FormB bb;
        Button b1 = new Button();
        Button b2 = new Button();
        public FormC(FormB b)
        {
            bb = b;
            Text = "Form C";
            Left += 60;
            FormClosing += FormC_FormClosing;
            b1.Parent = this;
            b1.Size = new Size(b1.Width + 60, b1.Height);
            b1.Top += 50;
            b1.Text = "Go To Form D";
            b1.Click += B1_Click;
            b2.Parent = this;
            b2.Size = new Size(b2.Width + 60, b2.Height);
            b2.Top += 100;
            b2.Text = "Go To Form E";
            b2.Click += B2_Click;
        }
        private void B2_Click(object sender, EventArgs e)
        {
            FormE e1 = new FormE(this);
            e1.Activate();
            e1.Visible = true;
            Visible = false;
        }
        private void B1_Click(object sender, EventArgs e)
        {
            FormD d = new FormD(this);
            d.Activate();
            d.Visible = true;
            Visible = false;
        }
        private void FormC_FormClosing(object sender, FormClosingEventArgs e)
        {
            bb.Visible = true;
        }
    }
    class FormD : Form
    {
        FormC cc;
        public FormD(FormC c)
        {
            cc = c;
            Text = "Form D";
            Left += 60;
            FormClosing += FormD_FormClosing;
        }
        private void FormD_FormClosing(object sender, FormClosingEventArgs e)
        {
            cc.Visible = true;
        }
    }
    class FormE : Form
    {
        FormC cc;
        public FormE(FormC c)
        {
            cc = c;
            Text = "Form E";
            Left += 60;
            FormClosing += FormE_FormClosing;
        }
        private void FormE_FormClosing(object sender, FormClosingEventArgs e)
        {
            cc.Visible = true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Application.Run(new FormA());
        }
    }
}
