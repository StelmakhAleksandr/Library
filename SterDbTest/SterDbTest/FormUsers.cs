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
    public partial class FormUsers : Form
    {

        private FormUserEdit formEdit;

        public FormUsers()
        {
            InitializeComponent();
            formEdit = new FormUserEdit();
            formEdit.Owner = this;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            formEdit.Initialize(null,this.lbUsers);
            formEdit.ShowDialog();
        }

        public void RefreshL()
        {
            this.lbUsers.DataSource = User.AllItems;
            this.lbUsers.DisplayMember = "fullname";
            this.lbUsers.ValueMember = "Id";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            formEdit.Initialize(lbUsers.SelectedItem,lbUsers);
            formEdit.ShowDialog();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ((User)lbUsers.SelectedItem).Delete();
        }

        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormDicUsers_Load(object sender, EventArgs e)
        {
            RefreshL();
        }


    }
}
