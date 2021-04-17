using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using n01458860CumulativePart1.Models;
using MySql.Data.MySqlClient;


namespace n01458860CumulativePart1.Controllers
{
    public class TeacherDataController : ApiController
    {
        private SchoolDbContext dbContext = new SchoolDbContext();

        /// <summary>
        /// Finding a teacher by id
        /// </summary>
        /// <param name="id">id of a teacher</param>
        /// <example>
        /// GET api/teacherdata/findteacherbyid/1
        /// </example>
        /// <returns>a teacher</returns>
        [HttpGet]
        [Route("api/teacherdata/findteacherbyid/{id}")]
        public Teacher FindTeacherById(int id)
        {
            //Establish a database connection
            MySqlConnection dbConnection = dbContext.AccessDatabase();

            //Open database connection
            dbConnection.Open();

            //Establish a query into a variable
            MySqlCommand command = dbConnection.CreateCommand();

            //Create a SELECT query
            command.CommandText = "SELECT * FROM teachers WHERE teacherid = @id";
            command.Parameters.AddWithValue("@id", id);
            command.Prepare();

            //Gather result set of a query into a variable
            MySqlDataReader dbreader = command.ExecuteReader();

            Teacher foundTeacher = null;
            while (dbreader.Read())
            {
                foundTeacher = new Teacher(id.ToString(), dbreader["teacherfname"].ToString(), dbreader["teacherlname"].ToString(),
                                           dbreader["employeenumber"].ToString(), dbreader["hiredate"].ToString(), dbreader["salary"].ToString());
            }

            //Close database connection
            dbConnection.Close();
            return foundTeacher;
        }



        /// <summary>
        /// find a teacher with a specific name
        /// </summary>
        /// <param name="name">full name of a teacher</param>
        /// <example>
        /// GET api/teacherdata/FindTeacher/"Alexander Bennett"
        /// </example>
        /// <returns>information of a teacher</returns>
        [HttpGet]
        /*[Route("api/teacherdata/findteacherbyname/{name}")]*/
        public List<Teacher> FindTeachers(string teacherName, string fromHireDate, string toHireDate, string fromSalary, string toSalary)
        {
            ;
            List<Teacher> foundTeachers = new List<Teacher>() ;
            //create an instance of a connection;
            MySqlConnection dbConnection = dbContext.AccessDatabase();

            //Open a connection between web server and database
            dbConnection.Open();

            //Establish a new command (query) for database
            MySqlCommand command = dbConnection.CreateCommand();

            //create a SELECT query 
            command.CommandText = "SELECT * " +
                                  "FROM teachers " +
                                  "WHERE (CONCAT(teacherfname, ' ', teacherlname) = @name " +
                                  "OR teacherfname like @name " +
                                  "OR teacherlname like @name) ";
            
            command.Parameters.AddWithValue("@name", teacherName);
            if(!String.IsNullOrEmpty(fromHireDate))
            {
                command.CommandText += " AND hiredate >= @fromDate ";
                command.Parameters.AddWithValue("@fromDate", fromHireDate);
            }

            if (!String.IsNullOrEmpty(toHireDate))
            {
                command.CommandText += " AND hiredate <= @toDate ";
                command.Parameters.AddWithValue("@toDate", toHireDate);
            }

            if(!String.IsNullOrEmpty(fromSalary))
            {
                command.CommandText += " AND salary >= @fromSalary ";
                command.Parameters.AddWithValue("@fromSalary", fromSalary);
            }

            if (!String.IsNullOrEmpty(toSalary))
            {
                command.CommandText += " AND salary <= @toSalary ";
                command.Parameters.AddWithValue("@toSalary", toSalary);
            }
           
            command.Prepare();

            //Gather result set of query into a variable
            MySqlDataReader dbReader = command.ExecuteReader();

            Teacher foundTeacher = null;
            //Loop through each row result set
            while (dbReader.Read())
            {
                foundTeacher = new Teacher( dbReader["teacherid"].ToString(), dbReader["teacherfname"].ToString(), dbReader["teacherlname"].ToString(),
                     dbReader["employeenumber"].ToString(), dbReader["hiredate"].ToString(), dbReader["salary"].ToString());
                foundTeachers.Add(foundTeacher);
            }

            //Close connection between database and webserver after loading data
            dbConnection.Close();
            return foundTeachers;
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
                                  "WHERE hiredate = @date ";
            command.Parameters.AddWithValue("@date", hiredate);
            command.Prepare();

            //Gather result set of a query into a variable
            MySqlDataReader DataReader = command.ExecuteReader();

            Teacher foundTeacher = null;
            //Loop through each row result set
            while (DataReader.Read())
            {
                ;
                foundTeacher = new Teacher(DataReader["teacherid"].ToString(), DataReader["teacherfname"].ToString(), DataReader["teacherlname"].ToString(),
                     DataReader["employeenumber"].ToString(), DataReader["hiredate"].ToString(), DataReader["salary"].ToString());
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
                                  "WHERE salary = @salary";
            command.Parameters.AddWithValue("@salary", salary);
            command.Prepare();

            //Gather result set of a query into a variable
            MySqlDataReader dataReader = command.ExecuteReader();

            Teacher foundTeacher = null;
            //Loop through each row result set
            while (dataReader.Read())
            {
                foundTeacher = new Teacher(dataReader["teacherid"].ToString(), dataReader["teacherfname"].ToString(), dataReader["teacherlname"].ToString(),

                    dataReader["employeenumber"].ToString(),dataReader["hiredate"].ToString(), salary);
            }

            //Close a connection between MySQL database and webserver
            dbConnection.Close();

            return foundTeacher;
        }


        /// <summary>
        /// get all teachers from database
        /// </summary>
        /// <example>
        /// GET api/teacherdata/getteachers
        /// </example>
        /// <returns>a list of teachers with their information</returns>
        [Route("api/teacherdata/getteachers")]
        public List<Teacher> GetTeachers()
        {
            //create an instance of a database connection
            MySqlConnection dbConn = dbContext.AccessDatabase();

            //Open a connection between database and web server
            dbConn.Open();

            //Establish a command for database
            MySqlCommand command = dbConn.CreateCommand();

            //Create a SELECT query
            command.CommandText = "SELECT * FROM teachers";

            //Gather  result set of a query into a variable
            MySqlDataReader dbreader = command.ExecuteReader();

            List<Teacher> teachers = new List<Teacher>();

            //Check whether there is any next record or not
            while(dbreader.Read())
            {
                Teacher teacher = new Teacher(dbreader["teacherid"].ToString(), dbreader["teacherfname"].ToString(), dbreader["teacherlname"].ToString(),
                                             dbreader["employeenumber"].ToString(), dbreader["hiredate"].ToString(), dbreader["salary"].ToString());
                teachers.Add(teacher);
            }

            //Close a connection between database and web server.
            dbConn.Close();
            return teachers;
        }


        /// <summary>
        /// Add a teacher to the MySQL database
        /// </summary>
        /// <param name="NewTeacher">An object with fields that map to the columns of the teacher's table. Non-Deterministic</param>
        /// <example>
        /// POST api/TeacherData/AddTeacher
        /// FORM DATA / POST DATA / REQUEST BODY 
        /// {
        ///	"fname":"Christine",
        ///	"lname":"Bittle",
        ///	"number":"T234",
        ///	"salary":"70"
        /// }
        /// </example>
        /// 
        [HttpPost]
        [EnableCors(origins:"*", methods: "*", headers: "*")]
        public void AddTeacher([FromBody]Teacher NewTeacher)
        {
            //Create an instance of a connection
            MySqlConnection dbConnection = dbContext.AccessDatabase();

            //Open the connection between database and web server
            dbConnection.Open();

            //Establish a new command for our database 
            MySqlCommand command = dbConnection.CreateCommand();

            //SQL QUERY
            command.CommandText = "insert into teachers (teacherfname, teacherlname, employeenumber, hiredate,salary) " +
                "values (@TeacherFname, @TeacherLname, @TeacherNumber, CURRENT_DATE(), @TeacherSalary)";
            command.Parameters.AddWithValue("@TeacherFname",NewTeacher.fname);
            command.Parameters.AddWithValue("@TeacherLname",NewTeacher.lname);
            command.Parameters.AddWithValue("@TeacherNumber",NewTeacher.number);
            command.Parameters.AddWithValue("@TeacherSalary",NewTeacher.salary);
            command.Prepare();

            //Execute the insert statement
            command.ExecuteNonQuery();

            //Close the connection between database and web server
            dbConnection.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <example>
        /// POST: api/TeacherData/DeleteTeacher/1
        /// </example>
        [HttpPost]
        public void DeleteTeacher(int id)
        {
            //Create an instance of a database connection
            MySqlConnection dbConnection = dbContext.AccessDatabase();

            //Open database connection
            dbConnection.Open();

            //establish a new command for our database
            MySqlCommand command = dbConnection.CreateCommand();

            //Create Delete query
            command.CommandText = "Delete from teachers where teacherid = @id";
            command.Parameters.AddWithValue("@id",id);
            command.Prepare();

            //Execute not select statement
            command.ExecuteNonQuery();
            

            //Close database connection
            dbConnection.Close();

        }
    }
}
