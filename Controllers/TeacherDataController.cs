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
    public class TeacherDataController : ApiController
    {
        private SchoolDbContext dbContext = new SchoolDbContext();

        /// <summary>
        /// find a teacher with a specific name
        /// </summary>
        /// <param name="name">full name of a teacher</param>
        /// <example>
        /// GET api/teacherdata/FindTeacherByName/"Alexander Bennett"
        /// </example>
        /// <returns>information of a teacher</returns>
        [HttpGet]
        [Route("api/teacherdata/findteacherbyname/{name}")]
        public Teacher FindTeacherByName(string name)
        {
            //create an instance of a connection;
            MySqlConnection dbConnection = dbContext.AccessDatabase();

            //Open a connection between web server and database
            dbConnection.Open();

            //Establish a new command (query) for database
            MySqlCommand command = dbConnection.CreateCommand();

            //create a SELECT query 
            command.CommandText = "SELECT * " +
                                  "FROM teachers " +
                                  //"WHERE CONCAT(teacherfname,' ',teacherlname) = " + name;
                                  "WHERE CONCAT(teacherfname, ' ', teacherlname) = '" + name+ "'";
            //Gather result set of query into a variable
            MySqlDataReader dbReader = command.ExecuteReader();

            Teacher foundTeacher = null;
            //Loop through each row result set
            while (dbReader.Read())
            {
                foundTeacher = new Teacher(name, dbReader["hiredate"].ToString(), dbReader["salary"].ToString());
            }

            //Close connection between database and webserver after loading data
            dbConnection.Close();
            return foundTeacher;
        }

        /// <summary>
        /// finding a teacher bases on the hiredate
        /// </summary>
        /// <param name="hiredate">hire date of a teacher</param>
        /// <example>
        /// GET api/teacherdata/findteacherbyhiredate/2016-08-05
        /// </example>
        /// <returns>information of a found teacher</returns>
        [HttpGet]
        [Route("api/teacherdata/findteacherbyhiredate/{hiredate}")]
        public Teacher FindTeacherByHireDate(string hiredate)
        {
            //Create an instance of a connection
            MySqlConnection dbConnection = dbContext.AccessDatabase();

            //Open a connection between database and web server
            dbConnection.Open();

            //Establish a command (query) for database
            MySqlCommand command = dbConnection.CreateCommand();

            //Create a SELECT query
            command.CommandText = "SELECT * " +
                "FROM teachers " +
                "WHERE hiredate = '" + hiredate + "'";

            //Gather result set of a query into a variable
            MySqlDataReader DataReader = command.ExecuteReader();

            Teacher foundTeacher = null;
            //Loop through each row result set
            while (DataReader.Read())
            {
                string name = DataReader["teacherfname"].ToString() + " " + DataReader["teacherlname"].ToString();
                foundTeacher = new Teacher(name, DataReader["hiredate"].ToString(), DataReader["salary"].ToString());
            }
            //Close connection between MySQL database and web server
            dbConnection.Close();
            return foundTeacher;
        }

        /// <summary>
        /// finding a teacher bases on salary
        /// </summary>
        /// <param name="salary">teachers' salary-based filter</param>
        /// <example>
        /// Get api/teacherdata/findteacherbysalary/55.30/
        /// </example>
        /// <returns>information of a teacher</returns>
        [HttpGet]
        [Route("api/teacherdata/findteacherbysalary/{salary}")]
        public Teacher FindTeacherBySalary(string salary)
        {
            //Create an instance of a database connection
            MySqlConnection dbConnection = dbContext.AccessDatabase();

            //Open a connection between database and web server
            dbConnection.Open();

            //Establish a command (query) for database
            MySqlCommand command = dbConnection.CreateCommand();

            //Create a SELECT query
            command.CommandText = "SELECT * " +
                "FROM teachers " +
                "WHERE salary = '" + salary + "'";

            //Gather result set of a query into a variable
            MySqlDataReader dataReader = command.ExecuteReader();

            Teacher foundTeacher = null;
            //Loop through each row result set
            while (dataReader.Read())
            {
                string name = dataReader["teacherfname"].ToString() + " " + dataReader["teacherlname"].ToString();
                foundTeacher = new Teacher(name, dataReader["hiredate"].ToString(), salary);
            }

            //Close a connection between MySQL database and webserver
            dbConnection.Close();

            return foundTeacher;
        }
    }
}
