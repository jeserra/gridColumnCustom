using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridProd
{
    public class DataGridViewRolloverCell: DataGridViewTextBoxCell
    {

        private Modal modal { get;}

        const int HORIZONTALOFFSET = 1;
        const int SPACER = 4;

        public DataGridViewRolloverCell()
        {
            modal = new Modal();
            modal.OnAdded  +=Modal_OnAdded;
            modal.OnCancel +=Modal_OnCancel;
        }
        protected override void Paint(
                Graphics graphics,
                Rectangle clipBounds,
                Rectangle cellBounds,
                int rowIndex,
                DataGridViewElementStates cellState,
                object value,
                object formattedValue,
                string errorText,
                DataGridViewCellStyle cellStyle,
                DataGridViewAdvancedBorderStyle advancedBorderStyle,
                DataGridViewPaintParts paintParts)
        {
            // Call the base class method to paint the default cell appearance.
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState,
                value, "", errorText, cellStyle,
                advancedBorderStyle, paintParts);

            // Retrieve the client location of the mouse pointer.
            Point cursorPosition =
                this.DataGridView.PointToClient(Cursor.Position);


            DataGridViewRolloverCellColumn parent =
                  (DataGridViewRolloverCellColumn)this.OwningColumn;
            parent.CalcMaxValue();
        

            Font fnt = parent.InheritedStyle.Font;

            string cellText = formattedValue.ToString();
            SizeF textSize =
             graphics.MeasureString(cellText, fnt);

            //  Calculate where text would start:
            PointF textStart = new PointF(
              Convert.ToSingle(HORIZONTALOFFSET +  SPACER),
              (cellBounds.Height - textSize.Height) / 2);
         
            var textColor = Color.Black;

            // Draw the text:
            using (SolidBrush brush =
             new SolidBrush(textColor))
            {
                graphics.DrawString(cellText, fnt, brush,
                  cellBounds.X + textStart.X + 12,
                  cellBounds.Y + textStart.Y);
            }

            //if (cellState ==(DataGridViewElementStates.Selected | DataGridViewElementStates.Visible))
            //{
                Image image = Image.FromFile("downward-arrow.ico");
               
                 
                graphics.DrawImage(image, cellBounds.X+1, cellBounds.Y+1);
                
            //}

            // If the mouse pointer is over the current cell, draw a custom border.
            /*if (cellBounds.Contains(cursorPosition))
            {
                Rectangle newRect = new Rectangle(cellBounds.X + 1,
                    cellBounds.Y + 1, cellBounds.Width - 4,
                    cellBounds.Height - 4);
                graphics.DrawRectangle(Pens.Red, newRect);
            }*/


            Console.WriteLine($"{cellState}");
        }

      

        protected override void OnMouseEnter(int rowIndex)
        {
            this.DataGridView.InvalidateCell(this);
        }

        protected override void OnKeyPress(KeyPressEventArgs e, int rowIndex)
        {
            if(Control.ModifierKeys == Keys.F4)
            {
                modal.ShowDialog();
            }
            base.OnKeyPress(e, rowIndex);

        }
        protected override void OnClick(DataGridViewCellEventArgs e)
        {
            this.DataGridView.InvalidateCell(this);
           // var bounds = this.GetContentBounds(e.RowIndex);
            
          //  MessageBox.Show(bounds.X.ToString());
            modal.ShowDialog();
        }

        private void Modal_OnCancel(object sender, StringEventArgs e)
        {
            this.Value = String.Empty;
            //MessageBox.Show($"Se selecciono {e.StringAddedOrRemoved}");
        }

        private void Modal_OnAdded(object sender, StringEventArgs e)
        {
           
             this.Value = e.StringAddedOrRemoved;
            
        }

        protected override void OnMouseLeave(int rowIndex)
        {
            this.DataGridView.InvalidateCell(this);
        }

        public override Type EditType => typeof(MyDataGridViewTextBoxEditingControl);

        public class MyDataGridViewTextBoxEditingControl : DataGridViewTextBoxEditingControl
        {
            protected override void OnKeyDown(KeyEventArgs e)
            {
                if( e.Modifiers == Keys.F4)
                {
                    MessageBox.Show("Presionado f4");
                }
                base.OnKeyDown(e);
                //Put the logic here
            }
        }


    }


}
