using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace n01458860CumulativePart1.Models
{
    [DataContract]
    public class Class
    {
        [DataMember]
        public string classname;
        [DataMember]
        public string classcode;
        [DataMember]
        public string teacherid;
        [DataMember]
        public string startdate;
        [DataMember]
        public string finishdate;
        public Class(string name, string code, string teacherid, string startdate, string finishdate)
        {
            this.classname = name;
            this.classcode = code;
            this.teacherid = teacherid;
            this.startdate = startdate;
            this.finishdate = finishdate;
        }
    }
}