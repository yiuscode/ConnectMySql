using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    class DBConnect
    {
        private MySqlConnection _connection;
        private string dbHost;
        private string dbUser;
        private string dbPass;
        private string dbName;

        public DBConnect()
        {
            Initialize();
        }

        public void Initialize()
        {
            dbHost = "127.0.0.1";
            dbUser = "root";
            dbPass = "123456";
            dbName = "MYDB";

            string connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;

            _connection = new MySqlConnection(connStr);
        }

        public bool OpenConnection()
        {
            try
            {
                _connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                _connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void Insert(string id, string name, string age)
        {
            string query = $"INSERT INTO student (id, name, age) VALUES({id},'{name}', {age})";

            if(this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, _connection);

                cmd.ExecuteNonQuery();

                this.CloseConnection();
            }

        }

        public void Delete (string id)
        {
            
            string query = $"Delete from student where id = {id};";

            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, _connection);

                cmd.ExecuteNonQuery();

                this.CloseConnection();
            }

        }

        public List<string>[] Select()
        {
            string query = "select * from student;";

            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();



            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, _connection);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())

                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["name"] + "");
                    list[2].Add(dataReader["age"] + "");
                }

                dataReader.Close();

                this.CloseConnection();

                return (list);


            }
            else
            {
                return (list);
            }

        }






    }


}
