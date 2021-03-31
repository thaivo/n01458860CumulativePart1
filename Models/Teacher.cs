using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace n01458860CumulativePart1.Models
{
    [DataContract]
    public class Teacher
    {
        [DataMember]
        public string id;
        [DataMember]
        public string name;
        [DataMember]
        public string hiredate;
        [DataMember]
        public string salary;

        public Teacher(string id, string name, string hiredate, string salary)
        {
            this.id = id;
            this.name = name;
            this.hiredate = hiredate;
            this.salary = salary;
        }
    }
}