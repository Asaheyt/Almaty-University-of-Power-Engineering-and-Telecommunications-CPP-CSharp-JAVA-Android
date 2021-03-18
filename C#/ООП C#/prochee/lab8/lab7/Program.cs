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
        public FormA()
        {
            Text = "Form A";
            KeyUp += FormA_KeyUp;
            Leave += FormA_Leave;
           LocationChanged += FormA_LocationChanged; 

       
          
            b.Parent = this;
            b.Text = "Go To Form B";
            b.Location = new Point(40, 40);
            b.Size = new Size(b.Width + 60, b.Height);
            b.Click += B_Click;
        }

       private void FormA_LocationChanged(object sender, EventArgs e)
        {
            
             this.WindowState = FormWindowState.Minimized;
           
     }
    
        private void FormA_Leave(object sender, EventArgs e)
        {
            Location = new Point(Location.X, Location.Y-50);
        }

        private void FormA_KeyUp(object sender, KeyEventArgs e)
        {
            Location = new Point(Location.X + 50, Location.Y);
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
        public FormB(FormA a)
        {
            aa = a;
            Text = "Form B";
            MouseEnter += FormB_MouseEnter;
            MouseLeave += FormB_MouseLeave;
            Resize += FormA_Resize;
        }

        private void FormB_MouseLeave(object sender, EventArgs e)
        {
            Height += 50;
        }

        private void FormB_MouseEnter(object sender, EventArgs e)
        {
            MessageBox.Show("Your size is " + Size);
        }



        private void FormA_Resize(object sender, EventArgs e)
        {
             bool colour = true;
                if (colour)
                    this.BackColor = System.Drawing.Color.Red;
                else
                    this.BackColor = System.Drawing.Color.Chocolate;
                colour = !colour;
           
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
