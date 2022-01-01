using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace note
{
    class NoteRepository : INoteRepository
    {
        private string connectionstring = "Data Source=.;Initial Catalog=notes_db;Integrated Security=true";

        public bool Delete(int _ID)
        {
            SqlConnection Connection = new SqlConnection(connectionstring);

            try
            {
                string query = "delete notes_tb where _ID= @_ID";
                SqlCommand Command = new SqlCommand(query, Connection);
                Command.Parameters.AddWithValue("@_ID", _ID);
                Connection.Open();
                Command.ExecuteNonQuery();
                return true;
            }

            catch
            {
                return false;
            }

            finally
            {
                Connection.Close();
            }

        }

        public bool Insert(string Titel, string Note)
        {
            SqlConnection Connection = new SqlConnection(connectionstring);
            string query = "insert into notes_tb (Titel,note) values (@titel,@note)";
            try
            {
                SqlCommand command = new SqlCommand(query, Connection);
                command.Parameters.AddWithValue("@Titel", Titel);
                command.Parameters.AddWithValue("@note", Note);
                Connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }

        public DataTable SelectAll()
        {
            SqlConnection Connection = new SqlConnection(connectionstring);
            string query = "Select * from notes_tb";
            SqlDataAdapter Adapter = new SqlDataAdapter(query, Connection);
            DataTable data = new DataTable();
            Adapter.Fill(data);
            return data;
        }
        public DataTable SelectRow(int _ID)
        {
            string query = "select * from notes_tb where _ID=" + _ID;
            SqlConnection Connection = new SqlConnection(connectionstring);
            SqlDataAdapter Adapter = new SqlDataAdapter(query, Connection);
            DataTable Data = new DataTable();
            Adapter.Fill(Data);
            return Data;
        }

        public bool Update(int _ID, string Titel, string Note)
        {
            SqlConnection Connection = new SqlConnection(connectionstring);
            try
            {
                string query = "update notes_tb set Titel=@Titel,note=@note where _ID=@_ID";
                SqlCommand command = new SqlCommand(query, Connection);
                command.Parameters.AddWithValue("@Titel", Titel);
                command.Parameters.AddWithValue("@note", Note);
                command.Parameters.AddWithValue("@_ID", _ID);
                Connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}
