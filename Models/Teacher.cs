using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace n01458860CumulativePart1.Models
{
    public class Teacher
    {
        public string name;
        public string hiredate;
        public string salary;

        public Teacher(string name, string hiredate, string salary)
        {
            this.name = name;
            this.hiredate = hiredate;
            this.salary = salary;
        }
    }
}