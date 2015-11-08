using SterDbTest.Data;
using System;
using System.Windows.Forms;

namespace SterDbTest
{
public partial class FormUserEdit : Form
   {
      private User _user = null;
      public ListBox l;      
      public FormUserEdit(){ InitializeComponent(); }
      
      public void Initialize(object user, ListBox l)
      {
          this.l = l;
         _user = user as User;
         if (_user == null)
         {
             this.Text = "Додати автора/користувача";
            _user = new User();
            tbName.Text = "";
            tbSName.Text = "";
            tbPName.Text = "";
            rbMan.Checked = true;
            rbWoman.Checked = false;
            tbLogin.Text = "";
            tbPassword.Text = "";
            rtbInfo.Text = "";
            chbAdmin.Checked = false;
         }
         else
         {
             this.Text = "редагувати автора/користувача";
            tbName.Text = _user.Name; 
            tbSName.Text = _user.SName;
            tbPName.Text = _user.PName;
            rbMan.Checked = (_user.Sex == SexType.Man);
            rbWoman.Checked = (_user.Sex == SexType.Woman);
            tbLogin.Text = _user.Login;
            tbPassword.Text  = _user.Password;
            rtbInfo.Text = _user.Info;
            chbAdmin.Checked = _user.isAdmin;
            cisautor.Checked = _user.isAuthor;
            cisuser.Checked = _user.isUser;
         }
      }

      private void btnOk_Click(object sender, EventArgs e)
      {
         _user.Name = tbName.Text;
         _user.SName = tbSName.Text;
         _user.PName = tbPName.Text;
         _user.Sex = (rbMan.Checked ? SexType.Man : SexType.Woman);
         _user.Login = tbLogin.Text;
         _user.Password = tbPassword.Text;
         _user.Info = rtbInfo.Text;
         _user.isAdmin = chbAdmin.Checked;
         _user.isAuthor = cisautor.Checked;
         _user.isUser = cisuser.Checked;
         _user.Save();
         l.DataSource = User.AllItems;
          Hide();
      }
      
      private void btnCancel_Click(object sender, EventArgs e) { Hide(); }

      private void FormUserEdit_Load(object sender, EventArgs e)
      {

      }


   }
}

