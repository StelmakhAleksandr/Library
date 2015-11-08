using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SterDbTest.Data
{
    public class User:Base<User>
    {
        public User() : base() { }
        public User(DataRow dr) : base(dr) { }

        public string Login
        {
            get { return _row["LOGIN"].ToString(); }
            set { _row["LOGIN"] = value; }
        }
        public string Password
        {
            get { return _row["PWORD"].ToString(); }
            set { _row["PWORD"] = value; }
        }
        public string Name
        {
            get { return _row["NAME"].ToString(); }
            set { _row["NAME"] = value; }
        }
        public string SName
        {
            get { return _row["SNAME"].ToString(); }
            set { _row["SNAME"] = value; }
        }
        public string PName
        {
            get { return _row["PNAME"].ToString(); }
            set { _row["PNAME"] = value; }
        }
        public string Info
        {
            get { return _row["INFO"].ToString(); }
            set { _row["INFO"] = value; }
        }
        public SexType Sex
        {
            get { return (Convert.ToInt32(_row["SEX"]) == 0) 
                ? SexType.Woman : SexType.Man; }
            set { _row["SEX"] = (value == 0) 
                ? SexType.Woman : SexType.Man; }
        }
        public bool isAdmin
        {
            get { return (Convert.ToInt32(_row["ADMIN"]) == 1); }
            set { _row["ADMIN"] = value ? 1 : 0; }
        }

        public bool isAuthor
        {
            get { return (Convert.ToInt32(_row["AUTOR"]) == 1); }
            set { _row["AUTOR"] = value ? 1 : 0; }
        }

        public bool isUser
        {
            get { return (Convert.ToInt32(_row["USER"]) == 1); }
            set { _row["USER"] = value ? 1 : 0; }
        }

        public string fullname
        {
            get { return _row["SNAME"].ToString() +" "
                + _row["NAME"].ToString()+" "+_row["PNAME"].ToString(); }
        }

        public override string ToString() { return Login; }

        public override bool Equals(object obj) { return 
            (obj is User && this == (User)obj); }

        public static bool operator ==(User u1, User u2)
        {
            if (System.Object.ReferenceEquals(u1, u2)) 
                { return true; }
            if (((object)u1 == null) || ((object)u2 == null)) 
                { return false; }
            return u1.Id == u2.Id;
        }

        public static bool operator !=(User u1, User u2) 
            { return !(u1 == u2); }

    }
}
