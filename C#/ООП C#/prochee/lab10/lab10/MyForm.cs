using System;
using System.Data;
using System.Windows.Forms;

namespace lab10
{
    public partial class MyForm : Form
    {
        PList t = new PList();
        DataTable dtb;
        BindingSource bs;
        public MyForm()
        {
            InitializeComponent();
            dtb = new DataTable();
            bs = new BindingSource();
            t.Fill();
            dtb = t.ConvertToDataTable();
            bs.DataSource = dtb;
            dataGridView1.DataSource = bs;
            t.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            t.ReadFromFile();
            dtb = t.ConvertToDataTable();
            bs.DataSource = dtb;
            dataGridView1.DataSource = bs;
            t.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            t.SaveFromGridViewToFile(dataGridView1);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            t.AppendFromFile();
            dtb = t.ConvertToDataTable();
            bs.DataSource = dtb;
            dataGridView1.DataSource = bs;
            t.Clear();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            t.ReadFromXMLFile();
            dtb = t.ConvertToDataTable();
            bs.DataSource = dtb;
            dataGridView1.DataSource = bs;
            t.Clear();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            t.SaveFromGridViewToXMLFile(dataGridView1);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            t.AppendFromXMLFile();
            dtb = t.ConvertToDataTable();
            bs.DataSource = dtb;
            dataGridView1.DataSource = bs;
            t.Clear();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
            // bs.RemoveCurrent();
        }
    }
}
