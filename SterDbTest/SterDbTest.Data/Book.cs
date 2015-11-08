using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SterDbTest.Data
{
    public class Book:Base<Book>
    {
        public Book() : base() { }
        public Book(DataRow dr) : base(dr) { }

        public User Autor
        {
            get { return User.GetByID(new Guid(
                _row["AUTHOR"].ToString())); }
            set { _row["AUTHOR"] = value; }
        }

        public Guid AutorId
        {
            get { return new Guid(
                _row["AUTHOR"].ToString()); }
            set { _row["AUTHOR"] = value; }
        }
        public string Title
        {
            get { return _row["TITLE"].ToString(); }
            set { _row["TITLE"] = value; }
        }
    }
}
