using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportAppTest
{
    class Database
    {
        public static Boolean _CONNECTION_SUCCESS = true;
        static List<SqlConnection> sqlConns = new List<SqlConnection>();
        static UserSettings uSettings = new UserSettings();
        static SqlConnection sqlTest = new SqlConnection();
        SqlConnection conn = new SqlConnection();
        String[] facilities = new String[10];

        public Database()
        {
            Iniitialize();
        }

        private void Iniitialize()
        {
            //load user application settings
            uSettings.Reload();
            sqlTest = null;
        }

        public SqlConnection CreateSqlConnection(String userID, String pass, String server, String db)
        {
            //build SQL connection string
            SqlConnectionStringBuilder connString = new SqlConnectionStringBuilder();
            connString.UserID = userID;
            connString.Password = pass;
            connString.DataSource = server;
            connString.InitialCatalog = db;
            return new SqlConnection(connString.ConnectionString);
        }

        public void StoreConnectionStrings(String ID, String pass)
        {
            uSettings.Reload();
            if (ID.Equals("") || pass.Equals(""))
            {
                MessageBox.Show("Enter Username and Password");
                this.CONNECTION_SUCCESS = false;
                return;
            }
            //store SQL connections in list
            Properties.Settings.Default.Facilities.Clear();
            for (int i=0; i<Properties.Settings.Default.ServerCount; i++)
            {
                conn = (CreateSqlConnection(ID, pass, Properties.Settings.Default.Servers[i], Properties.Settings.Default.Database));
                if (TestConnection(i))
                    sqlConns.Add(conn);
            }
            if (sqlConns.Count == Properties.Settings.Default.ServerCount)
                this.CONNECTION_SUCCESS = true;
        }

        public bool TestConnection(int index)
        {
            try
            {
                using (sqlTest = conn)
                {
                    sqlTest.Open();
                    using(SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.DimFacility WHERE Facility_ID=1", sqlTest))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                    Properties.Settings.Default.Facilities.Insert(index, reader["Facility_Name"].ToString());
                            }
                        }
                    }
                }
                Properties.Settings.Default.Save();
                return true;
            }
            catch (SqlException)
            {
                MessageBox.Show("INVALID CONNECTION: Server " + (index+1) + "\nIf all servers cannot connect, check User ID and Password",
                    "CONNECTION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.CONNECTION_SUCCESS = false;
                this.RemoveConnections();
                return false;
            }
        }

        public void RemoveConnections()
        {
            sqlConns.RemoveRange(0, sqlConns.Count);
            for (int i = 0; i < sqlConns.Count; i++)
            { }
        }

        public void ExecuteQueries(int index)
        {
            try
            {
                using (sqlTest = sqlConns[index])
                {
                    sqlTest.Open();
                }
            }
            catch (SqlException)
            {

            }
        }

        public Boolean CONNECTION_SUCCESS
        {
            get
            {
                return _CONNECTION_SUCCESS;
            }
            set
            {
                _CONNECTION_SUCCESS = value;
            }
        }
    }
}
