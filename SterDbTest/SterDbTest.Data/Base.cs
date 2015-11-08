using SterDbTest.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace SterDbTest.Data
{
    public class Base<T> where T : class
    {
        static TableManager tm;

        static Base() 
        {
            tm = TableManager.GetTableManager("["+typeof(T).Name+"]");
        }

        static public T[] AllItems
        { get { return GetByQuery(""); } }

        static public T GetByID(Guid id)
        {
            while (true)
            {
                try
                {
                    return (T)Activator.CreateInstance(typeof(T), 
                        new object[] { 
                            tm.Table.Select("Id = '" + id.ToString() + "'")[0]
                        });
                }
                catch { }
                if (tm.Recharge("Id = '" + id.ToString() + "'") == 0)
                    return null;
            }
        }


        static public T[] GetByQuery(string query) 
        { return GetByQuery(query, true); }
        static public T[] GetByQuery(string query, bool seekInDB)
        {
            List<T> res = new List<T>();
            List<DataRow> ldrs = new List<DataRow>();
            ldrs.AddRange(tm.Table.Select(query));
            if (seekInDB)
            {
                string strSel = "";
                if (ldrs.Count < 200)
                {
                    foreach (DataRow dr in ldrs)
                        strSel += "'" + dr["Id"].ToString() + "',";
                    if (strSel.Length > 0)
                        strSel = strSel.Remove(strSel.Length - 1);
                    if (tm.Recharge(query + ((strSel == "") ? 
                        "" : ((query == "") ? "" : " and") + 
                        " Id not in (" + strSel + ")")) > 0)
                    {
                        ldrs.Clear();
                        ldrs.AddRange(tm.Table.Select(query));
                    }
                }
                else
                {
                    int count = 0;
                    foreach (DataRow dr in tm.GetIds(query))
                    {
                        if (tm.Table.Select("Id = '" + dr["Id"].ToString()
                            + "'").Length == 0)
                        {
                            strSel += "'" + dr["Id"].ToString() + "',";
                            count++;
                        }
                        if (count == 200)
                        {
                            tm.Recharge(" Id in (" + strSel.Remove(strSel.Length - 1) + ")");
                            strSel = "";
                            count = 0;
                        }
                    }
                    if (strSel.Length > 0)
                        tm.Recharge(" Id in (" + strSel.Remove(strSel.Length - 1) + ")");
                    ldrs.Clear();
                    ldrs.AddRange(tm.Table.Select(query));
                }
            }
            foreach (DataRow dr in ldrs)
                res.Add((T)Activator.CreateInstance(typeof(T),
                    new object[] { dr }));
            return res.ToArray();
        }


        internal DataRow _row;
        private bool _isNew = false;

        internal Base()
        {
            _row = tm.Table.NewRow();
            _row["Id"] = Guid.NewGuid();
            _isNew = true;
        }
        internal Base(DataRow dr)
        {
            _row = dr;
            _isNew = false;
        }

        public Guid Id
        {
            get
            {
                return new Guid(_row["Id"].ToString());
            }
        }

        public bool IsNew
        { get { return _isNew; } }

        public void Save()
        {
            if (IsNew)
            {
                _isNew = false;
                tm.Table.Rows.Add(_row);
            }
            tm.Update(_row);
        }

        public void Delete()
        {
             tm.Update(_row);
             _row.Delete();
        }
    }
}
