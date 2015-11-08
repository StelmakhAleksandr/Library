using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SterDbTest.DA
{
    public class TableManager
    {
        static public int GlobalErrorCode = 0;
        static private Dictionary<string, TableManager> _tableManagers =
            new Dictionary<string, TableManager>();
        static private DbProviderFactory _DbProviderFactory =
            DbProviderFactories.GetFactory("System.Data.OleDb");
        static private DbConnection _connection = 
            _DbProviderFactory.CreateConnection();

        static private DbConnection Connection
        {
            get
            {
                while (true)
                {
                    try
                    {
                        if (_connection.State == ConnectionState.Broken)
                            _connection.Close();
                        if (_connection.State == ConnectionState.Closed)
                            _connection.Open();
                        return _connection;
                    }
                    catch
                    {
                        _connection.Close(); 
                    }
                }
            }
        }

        static TableManager() { _connection.ConnectionString =
            @"provider=Microsoft.JET.OLEDB.4.0;data source = C:\db.mdb"; }

        static public TableManager GetTableManager(string tableName)
        {
            TableManager tm = null;
            try { tm = _tableManagers[tableName]; }
            catch
            {
                try
                {
                    tm = new TableManager(tableName);
                    _tableManagers.Add(tableName, tm);
                }
                catch { }
            }
            return tm;
        }

        static public void RemoveTableManager(string tableName)
        { try { _tableManagers.Remove(tableName); } catch { } }

        private DbDataAdapter _da;
        private DataTable _dt;
        private DataTable _temp;
        private DbCommand _cmd;

        public DataTable Table { get { return _dt; } }

        internal TableManager(string tableName)
        {
            try
            {
                _da = TableManager._DbProviderFactory.CreateDataAdapter();
                _cmd = TableManager._DbProviderFactory.CreateCommand();
                DbCommandBuilder cb =
                   TableManager._DbProviderFactory.CreateCommandBuilder();
                cb.QuotePrefix = "[";
                cb.QuoteSuffix = "]";
                _cmd.Connection = TableManager.Connection;
                cb.ConflictOption = ConflictOption.OverwriteChanges;
                cb.DataAdapter = _da;
                _dt = new DataTable();
                _temp = new DataTable();
                _dt.TableName = _temp.TableName = tableName;
                _cmd.CommandText = "Select * from " + Table.TableName;
                _da.SelectCommand = _cmd;
                _da.InsertCommand = cb.GetInsertCommand();
                _da.DeleteCommand = cb.GetDeleteCommand();
                _da.UpdateCommand = cb.GetUpdateCommand();
                Recharge("1 = 2");
            }
            catch { GlobalErrorCode = 13; }
            if (GlobalErrorCode == 13)
                MessageBox.Show("ОШИБКА");
            
        }

        public int Recharge(string query)
        {
            _cmd.CommandText = "Select * from "+ Table.TableName
                +((query == "") ? "" : " where " + query);
            try { return _da.Fill(_dt); }
            catch { MessageBox.Show("Відбувся запит до таблиці " 
                + Table.TableName + ((query == null) ? "" : " where ") 
                + query + Environment.NewLine + "Таблицю не знайдено!!!", 
                "Помилка БД...", MessageBoxButtons.OK, 
                MessageBoxIcon.Error); }
            return 0;
        }

        public DataRowCollection GetIds(string query)
        {
            _cmd.CommandText = "Select ID from " + Table.TableName 
                + ((query == null) ? "" : " where " + query);
            try
            {
                _da.Fill(_temp);
                return _temp.Rows;
            }
            catch { MessageBox.Show("Відбувся запит до таблиці SB_" 
                + Table.TableName + ((query == null) ? "" : " where ")
                + query + Environment.NewLine + "Таблицю не знайдено!!!",
                "Помилка БД...", MessageBoxButtons.OK,
                MessageBoxIcon.Error); }
            return null;
        }
        public int Update(DataRow dr)
        {
            return _da.Update(new DataRow[] { dr });
        }
        public int Update(DataRow[] drs) { return _da.Update(drs); }
    }

}
