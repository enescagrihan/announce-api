using PublicAnnounceV2.Data;
using PublicAnnounceV2.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAnnounceV2.Services
{
    public class DataService : dbOps, IDataService
    {
        public string AnnounceTableInsert(Announce announce)
        {
            string lastError = OpenConnection();

            SqlCommand command = new SqlCommand("INSERT INTO Announce VALUES (@FullName, @Content, @Date, @LastUpdate)", _Conn);
            command.Parameters.Add(new SqlParameter("@FullName", announce.FullName));
            command.Parameters.Add(new SqlParameter("@Content", announce.Content));
            command.Parameters.Add(new SqlParameter("@Date", DateTime.Now));
            command.Parameters.Add(new SqlParameter("@LastUpdate", DateTime.Now));

            using (SqlDataReader reader = command.ExecuteReader())
            {
                try
                {
                    reader.Read();
                }
                catch (Exception Ex)
                {
                    lastError = Ex.Message;
                }
                //reader.Read();
            }

            CloseConnection();
            return lastError;
        }

        public string AnnounceTableUpdate(Announce announce)
        {
            string lastError = OpenConnection();

            SqlCommand command = new SqlCommand("UPDATE Announce SET FullName = @FullName, Content = @Content, LastUpdate = @LastUpdate WHERE ID = " + announce.ID, _Conn);
            command.Parameters.Add(new SqlParameter("@FullName", announce.FullName));
            command.Parameters.Add(new SqlParameter("@Content", announce.Content));
            command.Parameters.Add(new SqlParameter("@LastUpdate", DateTime.Now));

            using (SqlDataReader reader = command.ExecuteReader())
            {
                try
                {
                    reader.Read();
                }
                catch (Exception ex)
                {
                    lastError = ex.Message;
                }
            }
            CloseConnection();
            return lastError;
        }

        public List<Announce> getAllAnnounces()
        {
            List<Announce> announceList = new List<Announce>();

            string lastError = OpenConnection();

            SqlCommand command = new SqlCommand("SELECT * FROM Announce", _Conn);

            using (var reader = command.ExecuteReader())
            {
                if (!reader.HasRows) return announceList;

                while (reader.Read())
                {
                    Announce announce = new Announce();

                    try
                    {
                        lastError = announce.AssignFromSqlDataReader(reader);
                    }
                    catch (Exception ex)
                    {
                        lastError = ex.Message;
                    }

                    announceList.Add(announce);
                }
            }
            CloseConnection();
            return announceList;
        }

        public Announce GetAnnounceById(int id)
        {
            Announce announce = new Announce();

            string lastError = OpenConnection();
            string queryString = "SELECT * FROM Announce WHERE ID = " + id;

            SqlCommand command = new SqlCommand(queryString, _Conn);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (!reader.HasRows) return announce;

                while (reader.Read())
                {
                    try
                    {
                        lastError = announce.AssignFromSqlDataReader(reader);
                    }
                    catch (Exception ex)
                    {
                        lastError = ex.Message;
                    }
                }
            }

            CloseConnection();
            return announce;
        }
    }
}
