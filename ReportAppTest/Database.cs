using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportAppTest
{
    class Database
    {
        static List<SqlConnection> sqlConns = new List<SqlConnection>();
        static UserSettings uSettings = new UserSettings();
        static SqlConnection sqlTest = new SqlConnection();
        

        public Database()
        {
            sqlTest = null;
            Iniitialize();
        }

        private void Iniitialize()
        {
            uSettings.Reload();
        }

        public SqlConnection CreateSqlConnection(String userID, String pass, String server, String db)
        {
            SqlConnectionStringBuilder connString = new SqlConnectionStringBuilder();
            connString.UserID = userID;
            connString.Password = pass;
            connString.DataSource = server;
            connString.InitialCatalog = db;
            return new SqlConnection(connString.ConnectionString);
        }

        public void StoreConnectionStrings(String ID, String pass)
        {
            SqlConnection conn = new SqlConnection();
            for (int i=0; i<uSettings.ServerCount; i++)
            {
                conn = (CreateSqlConnection(ID, pass, uSettings.ServerName[i], uSettings.Database));
                sqlConns.Add(conn);
                TestConnection(i);
            }
        }

        public void TestConnection(int index)
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
    }
}
