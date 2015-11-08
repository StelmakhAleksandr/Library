using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SterDbTest
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormBooks fb = new FormBooks();
            fb.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormUsers fu = new FormUsers();
            fu.ShowDialog();
        }
    }
}
