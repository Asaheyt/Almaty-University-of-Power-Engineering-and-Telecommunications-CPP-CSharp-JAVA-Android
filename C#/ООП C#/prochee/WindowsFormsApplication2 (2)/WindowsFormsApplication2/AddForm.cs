using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace WindowsFormsApplication2
{
    class AddForm:Form
    {
        private Prepod a = null;

        public Prepod Act { private set; get; }

        private IndexForm index1;

        private Label name;
        private Label age;
        private Label spec;
        private TextBox tName;
        private TextBox tAge;
        private TextBox tSpec;

        private Button ok;
        private Button cancel;

        public AddForm(IndexForm index1)
        {
            this.index1 = index1;

            this.Text = "Новый преподаватель";
            this.Size = new Size(300, 300);
            this.CenterToParent();

            name = new Label();
            name.Parent = this;
            name.Text = "Имя:";
            name.BorderStyle = BorderStyle.None;
            name.Location = new Point(10, 10);

            age = new Label();
            age.Parent = this;
            age.Text = "Год рождения:";
            age.BorderStyle = BorderStyle.None;
            age.Location = new Point(10, 60);

            spec = new Label();
            spec.Parent = this;
            spec.Text = "Специальность:";
            spec.BorderStyle = BorderStyle.None;
            spec.Location = new Point(10, 110);

            tName = new TextBox();
            tName.Parent = this;
            tName.Location = new Point(10, 35);

            tAge = new TextBox();
            tAge.Parent = this;
            tAge.Location = new Point(10, 85);

            tSpec = new TextBox();
            tSpec.Parent = this;
            tSpec.Location = new Point(10, 135);

            ok = new Button();
            ok.Parent = this;
            ok.Text = "OK";
            ok.Location = new Point(10, 180);
            ok.Click += new EventHandler(OK_Click);

            cancel = new Button();
            cancel.Parent = this;
            cancel.Text = "Cancel";
            cancel.Location = new Point(90, 180);
            cancel.Click += new EventHandler(Cancel_Click);


            this.FormClosing += new FormClosingEventHandler(E_Close);
        }

        private void E_Close(object sender, EventArgs arg)
        {
            for (int i = 0; i < index1.Controls.Count; i++)
            {
                index1.Controls[i].Enabled = true;
            }
        }

        private void OK_Click(object sender, EventArgs arg)
        {
            try
            {

                a = new Prepod();
                a.Name = tName.Text;
                a.Year = Int32.Parse(tAge.Text);
                a.Spec = tSpec.Text;

                index1.t.add(a);

                this.Close();
                for (int i = 0; i < index1.Controls.Count; i++)
                {
                    index1.Controls[i].Enabled = true;
                }
            }
            catch (NameException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (AgeException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (FormatException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Cancel_Click(object sender, EventArgs arg)
        {
            this.Close();
            for (int i = 0; i < index1.Controls.Count; i++)
            {
                index1.Controls[i].Enabled = true;
            }
        }

    }
}
