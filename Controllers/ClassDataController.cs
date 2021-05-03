using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using n01458860CumulativePart1.Models;
using MySql.Data.MySqlClient;


namespace n01458860CumulativePart1.Controllers
{
    public class ClassDataController : ApiController
    {
        MySqlConnection dbConnection = SchoolDbContext.AccessDatabase();

        /// <summary>
        /// Return classes of a teacher
        /// </summary>
        /// <param name="teacherId">id of a teacher</param>
        /// <example>
        /// GET api/classdata/findclassesbyteacherid/1
        /// </example>
        /// <returns>classes of a teacher</returns>
        [HttpGet]
        [Route("api/classdata/FindClassesByTeacherId/{teacherId}")]
        public List<Class> FindClassesByTeacherId(int teacherId)
        {
            //Open a connection between database and web server
            dbConnection.Open();

            //Create a command into a variable
            MySqlCommand command = dbConnection.CreateCommand();

            //Create a select query between database and web server
            command.CommandText = "SELECT * " +
                                  "FROM classes " +
                                  "WHERE teacherid = " + teacherId.ToString();

            MySqlDataReader dataReader = command.ExecuteReader();
            List<Class> foundClasses = new List<Class>();
            while (dataReader.Read())
            {
                Class newClass = new Class(dataReader["classname"].ToString(),
                                                            dataReader["classcode"].ToString(),
                                                            dataReader["teacherid"].ToString(),
                                                            dataReader["startdate"].ToString(),
                                                            dataReader["finishdate"].ToString());
                foundClasses.Add(newClass);
            }
            //Close connection
            dbConnection.Close();

            return foundClasses;
        }
    }
}
