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
    public partial class DeleteWindow : Form
    {
        public bool delete { get; set; }
        public DeleteWindow()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.delete = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.delete = false;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
