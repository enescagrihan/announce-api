using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAnnounceV2.Data
{
    public class dbOps
    {
        private string _connString = "Data Source=DESKTOP-A0FG9A5;Initial Catalog=PublicAnnounce;Integrated Security=True";
        public SqlConnection _Conn;
        
        public dbOps()
        {
            _Conn = new SqlConnection(_connString);
        }

        public string OpenConnection()
        {
            string lastError = "";

            try
            {
                if (_Conn.State != System.Data.ConnectionState.Open) _Conn.Open();

            }
            catch (Exception Ex)
            {
                lastError = Ex.Message;
            }

            return lastError;
        }

        public string CloseConnection()
        {
            string lastError = "";

            try
            {
                if (_Conn.State != System.Data.ConnectionState.Closed) _Conn.Close();
            }
            catch (Exception Ex)
            {
                /*DoNothing*/
            }

            return lastError;
        }

    }
}
