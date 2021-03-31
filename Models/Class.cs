using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace n01458860CumulativePart1.Models
{
    public class Class
    {
        public string classname;
        public string classcode;
        public string teacherid;
        public string startdate;
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