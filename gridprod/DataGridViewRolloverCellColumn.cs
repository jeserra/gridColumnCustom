using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridProd
{
    public class DataGridViewRolloverCellColumn: DataGridViewColumn
    {
        public long MaxValue;
        private bool needsRecalc = true;

        public void CalcMaxValue()
        {
            if (needsRecalc)
            {
                int colIndex = this.DisplayIndex;
                for (int rowIndex = 0;
                  rowIndex < this.DataGridView.Rows.Count;
                rowIndex++)
                {
                    DataGridViewRow row =
                      this.DataGridView.Rows[rowIndex];
                    MaxValue = 5000;// Math.Max(MaxValue,Convert.ToInt64(row.Cells[colIndex].Value));
                }
                needsRecalc = false;
            }
        }

        public DataGridViewRolloverCellColumn()
        {

            this.CellTemplate = new DataGridViewRolloverCell();

        }
    }
}
