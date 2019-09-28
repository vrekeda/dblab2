using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dblab2
{
    public partial class EditWindow : Form
    {
        public DataGridViewRow editedRow { get; set; }
        public bool save { get; set; }

        public EditWindow(DataGridViewRow row, List<string> columns)
        {
            InitializeComponent();

            for (int i = 1; i < columns.Count - 2; i++)
            {
                DataGridViewColumn column = new DataGridViewColumn
                {
                    HeaderText = columns[i],
                    Name = columns[i],
                    CellTemplate = new DataGridViewTextBoxCell()
                };
                EditinigRowGrid.Columns.Add(column);
            }

            EditinigRowGrid.Rows.Add();
            for (int i = 1; i < row.Cells.Count - 2; i++)
            {
                EditinigRowGrid.Rows[0].Cells[i - 1].Value = row.Cells[i].Value;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            editedRow = EditinigRowGrid.Rows[0];
            save = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            save = false;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
