using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Globalization;

namespace n01458860CumulativePart1.Models
{
    [DataContract]
    public class Teacher
    {
        [DataMember]
        public string id;
        [DataMember]
        public string fname;
        [DataMember]
        public string lname;
        [DataMember]
        public string number;
        [DataMember]
        public string hiredate;
        [DataMember]
        public string salary;

        public Teacher(string id, string fname, string lname,string number, string hiredate, string salary)
        {
            this.id = id;
            this.fname = fname;
            this.lname = lname;
            this.number = number;
            this.hiredate = hiredate;
            this.salary = salary;
        }

        public Teacher(string fname, string lname, string number, string hiredate, string salary)
        {
            
            this.fname = fname;
            this.lname = lname;
            this.number = number;
            this.hiredate = hiredate.Split(' ')[0];//get date only
            this.salary = salary;
        }
        public Teacher(string fname, string lname, string number, string salary)
        {
            this.fname = fname;
            this.lname = lname;
            this.number = number;
            this.salary = salary;
        }

        //Parameter-less construction for the POST data can absorb into the parameter NewAuthor of AddTeacher at TeacherDataController
        public Teacher() { }
    }
}