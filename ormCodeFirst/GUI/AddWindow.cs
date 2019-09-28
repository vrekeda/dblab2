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
    public partial class AddWindow : Form
    {
        public DataGridViewRow newRow { get; set; }
        public bool save { get; set; }
        //public List<string> references { get; set; }
        
        string tableName;

        public AddWindow(List<string> columns)
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
                AddRowGrid.Columns.Add(column);
            }
            AddRowGrid.Rows.Add();
        }

        //private void AddRowGrid_Click(object sender, DataGridViewCellEventArgs e)
        //{
        //    string refTableName;
        //    if (tableName == "tour")
        //    {
        //        refTableName = "travel_agency";
        //    }
        //    else if (tableName == "travel_agency")
        //    {
        //        refTableName = "client";
        //    }
        //    else if (tableName == "client")
        //    {
        //        refTableName = "tour";
        //    }
        //    else return;

        //    if (e.ColumnIndex == AddRowGrid.ColumnCount - 1)
        //    {
        //        AddReferenceWindow referenceWindow = new AddReferenceWindow(refTableName, db);
        //        referenceWindow.ShowDialog();
        //        if (referenceWindow.DialogResult == DialogResult.OK && referenceWindow.save)
        //        {
        //            if (tableName == "tour")
        //            {
        //                references.Clear();
        //                references.Add(referenceWindow.id);
        //            }
        //            else
        //            {
        //                references.Add(referenceWindow.id);
        //            }
        //            btnSave.Enabled = true;
        //        }
        //    }
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {

            newRow = AddRowGrid.Rows[0];
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
