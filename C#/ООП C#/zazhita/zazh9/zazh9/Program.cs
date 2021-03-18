using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace zazh9 {
    class FormA : Form {
        Button b = new Button();
        TextBox t1 = new TextBox();
        TextBox t2 = new TextBox();
        public FormA() {
            Text = "Form A";
            t2.Visible = false;
            t1.Parent = this;
            t2.Parent = this;
            t1.MouseLeave += T1_MouseLeave;
            t1.MouseEnter += T1_MouseEnter;
            t1.KeyUp += T1_KeyUp;
            t1.Location = new Point(50, 50);
            t2.Location = new Point(50, 100);


        }
        private void T1_KeyUp(object sender, EventArgs e) {
            t2.Text = t1.Text;
        }
        private void T1_MouseEnter(object sender, EventArgs e) {
            t2.Visible = true;
        }

        private void T1_MouseLeave(object sender, EventArgs e) {
            t1.Clear();
            t2.Clear();
            t2.Visible = false;
        }
    }
    class Program {
        static void Main(string[] args) {
            Application.Run(new FormA());
        }
    }
}
