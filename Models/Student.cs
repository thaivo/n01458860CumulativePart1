using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace n01458860CumulativePart1.Models
{
    public class Student
    {
        public string studentfname;
        public string studentlname;
        public string studentnumber;
        public string enrolldate;
        public Student(string fname, string lname, string studentnumber, string enrolldate)
        {
            this.studentfname = fname;
            this.studentlname = lname;
            this.studentnumber = studentnumber;
            this.enrolldate = enrolldate;
        }
    }
}