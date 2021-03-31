using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using n01458860CumulativePart1.Models;

namespace n01458860CumulativePart1.ViewModels
{
    public class TeacherViewModel
    {
        public List<Class> classes { get; set; }
        public Teacher teacher { get; set; }
    }
}