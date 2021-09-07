using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAnnounceV2.Data.Models
{
    public class Announce
    {
        public Int64 ID { get; set; }
        public string FullName { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public DateTime LastUpdate { get; set; }

        public string AssignFromSqlDataReader(SqlDataReader r)
        {
            string Err = "";
            object[] fieldValues = new object[r.FieldCount];
            DateTime z = new DateTime(1970 - 01 - 01);

            try
            {
                r.GetValues(fieldValues);
                int idx = 0;

                this.ID = DBNull.Value.Equals(fieldValues[idx]) ? 0 : r.GetInt64(idx); idx++;
                this.FullName = DBNull.Value.Equals(fieldValues[idx]) ? "" : r.GetString(idx); idx++;
                this.Content = DBNull.Value.Equals(fieldValues[idx]) ? "" : r.GetString(idx); idx++;
                this.Date = DBNull.Value.Equals(fieldValues[idx]) ? z : r.GetDateTime(idx); idx++;
                this.LastUpdate = DBNull.Value.Equals(fieldValues[idx]) ? z : r.GetDateTime(idx); idx++;
            }
            catch (Exception Ex)
            {
                Err = Ex.Message;
            }

            return Err;
        }
    }
}
