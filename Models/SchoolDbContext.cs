using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace n01458860CumulativePart1.Models
{
    public class SchoolDbContext
    {
        /// <summary>
        /// a list of information of database
        /// </summary>
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "schooldb"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        /// <summary>
        /// a string contains information of the connection
        /// </summary>
        protected static string ConnectionString
        {
            get
            {
                return "Server = " + Server + ";"
                    + "User = " + User + ";"
                    + "Password = " + Password + ";"
                    + "Database =" + Database + ";"
                    + "Port = " + Port + ";"
                    + "convert zero datetime = True";
            }
        }
        /// <summary>
        /// this method will return database connection.
        /// </summary>
        /// <returns>database connection</returns>
        public MySqlConnection AccessDatabase()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}