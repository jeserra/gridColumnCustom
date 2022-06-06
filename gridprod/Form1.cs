using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridProd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          //  dataGridView1.EditingControlShowing+=DataGridView1_EditingControlShowing;
            //dataGridView1.RefreshEdit ();
            DataGridViewRolloverCellColumn col = new DataGridViewRolloverCellColumn();
            dataGridView1.Columns.Add(col);
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            dataGridView1.Columns.Add(col2);
            //dataGridView1.SelectionMode  = DataGridViewSelectionMode.FullRowSelect;
        }

         

    }
}
