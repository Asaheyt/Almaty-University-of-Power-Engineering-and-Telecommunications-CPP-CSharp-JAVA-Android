using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class DataTbl : Form
    {
        DataGridView DataGrd = new DataGridView();
        DataTable dtable = new DataTable();
        public void setDtable()
        {
            dtable.Columns.Add(new DataColumn("#", Type.GetType("Int32")));

        }
        public void setDataGrd()
        {
            DataGrd.DataSource = dtable;
        }
        
        
    }
}
