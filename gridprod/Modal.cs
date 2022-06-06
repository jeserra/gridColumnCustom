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
    public partial class Modal : Form
    {
        public Modal()
        {
            InitializeComponent();
        }

        public event EventHandler<StringEventArgs> OnAdded;
        public event EventHandler<StringEventArgs> OnCancel;


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (OnAdded != null)
                OnAdded(this, new StringEventArgs()
                {
                    StringAddedOrRemoved = dataGridView1.SelectedRows[0].Cells[0].Value.ToString()
                });
            this.Close();
        }

        private void Modal_Load(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            {
                dataGridView1.Rows.Insert(0, "Producto 1", "200");
                dataGridView1.Rows.Insert(0, "Producto 2", "300");
                dataGridView1.Rows.Insert(0, "Producto 3", "400");
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (OnCancel != null)
                OnCancel(this, new StringEventArgs()
                {
                    StringAddedOrRemoved = "Se salio sin elegir item"
                });
            this.Close();
        }
    }
}
