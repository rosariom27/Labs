using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
       /*punto 12 lab 5 */ private SqlConnection _sqlConn = new SqlConnection("ConnectionString;");
        
        string connString;

        protected void OpenConnection()
        {
            connString = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;

          
       }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }

        const string consKeyDefaultCnnString = "ConnStringLocal";

        //private SqlConnection _sqlConn;

        public SqlConnection sqlConn
        {
            get { return _sqlConn; }
            set { _sqlConn = value; }
        }    

        
    }
}
