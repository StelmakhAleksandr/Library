using SterDbTest.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Common;
using SterDbTest.DA;

namespace SterDbTest
{
    public partial class FormBooks : Form
    {
        private FormBookEdit formEdit;
        public FormBooks()
        {
            InitializeComponent();
            formEdit = new FormBookEdit();
            formEdit.Owner = this;
        }

        private void badd_Click(object sender, EventArgs e)
        {
            formEdit.Initialize(null,lbBooks);
            formEdit.ShowDialog();
        }

        public void RefreshL()
        {
            this.lbBooks.DataSource = Book.AllItems;
            this.lbBooks.DisplayMember = "TITLE";
            this.lbBooks.ValueMember = "Id";
        }

        private void bedit_Click(object sender, EventArgs e)
        {
            formEdit.Initialize(lbBooks.SelectedItem,lbBooks);
            formEdit.ShowDialog();
        }

        private void bdel_Click(object sender, EventArgs e)
        {
            ((Book)lbBooks.SelectedItem).Delete();
        }

        private void FormBooks_Load(object sender, EventArgs e)
        {
            RefreshL();
        }
    }
}
