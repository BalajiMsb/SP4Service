using System;
using MySql.Data.MySqlClient;
namespace Sp4service.context
{
    public class MySqlContext:IDisposable
    {
        public MySqlConnection Connection;

        public MySqlContext(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
            this.Connection.Open();
        }

        public void Dispose()
        {
            Connection.Close();
        } 
    }
}