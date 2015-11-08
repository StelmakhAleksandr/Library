using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SterDbTest.Data;

namespace SterDbTest
{
    public partial class FormBookEdit : Form
    {
        private Book _book = null;
        private ListBox l;
        public FormBookEdit()
        {
            InitializeComponent();
        }
        public void Initialize(object book, ListBox l)
        {
            _book = book as Book;
            this.l = l;
            cautor.DataSource = User.GetByQuery("AUTOR=true");
            cautor.DisplayMember = "fullname";
            cautor.ValueMember = "Id";
            if (_book == null)
            {
                _book = new Book();
                ttitle.Text = "";
            }
            else
            {
               cautor.SelectedItem = (object)_book.Autor;
                ttitle.Text = _book.Title;
            }
            lid.Text = _book.Id.ToString();
        }

        private void FormBookEdit_Load(object sender, EventArgs e)
        {

        }

        private void bok_Click(object sender, EventArgs e)
        {
            _book.Title = ttitle.Text;
            _book.AutorId = ((User)cautor.SelectedItem).Id;
            _book.Save();
            l.DataSource = Book.AllItems;
            Hide();
        }

        private void bcanel_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
