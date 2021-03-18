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
            KeyPress += FormA_KeyPress;
            Shown += FormA_Shown; 

       
          
            b.Parent = this;
            b.Text = "Go To Form B";
            b.Location = new Point(40, 40);
            b.Size = new Size(b.Width + 60, b.Height);
            b.Click += B_Click;
        }

       private void FormA_Shown(object sender, EventArgs e)
        {

            MessageBox.Show("Your size is " + Size);

        }
    
        private void FormA_KeyPress(object sender, EventArgs e)
        {
            Location = new Point(Location.X-50, Location.Y);
        }

        private void FormA_KeyUp(object sender, KeyEventArgs e)
        {
                Location = new Point(Location.X, Location.Y - 50);
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
            MouseLeave += FormB_MouseLeave;
            Leave += FormB_Leave;
            LocationChanged += FormB_LocationChanged;
        }

        private void FormB_Leave(object sender, EventArgs e)
        {
            Width += 50;
        }

        private void FormB_MouseLeave(object sender, EventArgs e)
        {
            Width += 50;
        }



        private void FormB_LocationChanged(object sender, EventArgs e)
        {
             this.Cursor = Cursors.Hand;
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
