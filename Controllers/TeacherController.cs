using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using n01458860CumulativePart1.Models;
using n01458860CumulativePart1.ViewModels;
namespace n01458860CumulativePart1.Controllers
{
    public class TeacherController : Controller
    {
        //Search interface 
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        //GET: /Teacher/List
        public ActionResult List()
        {
            TeacherDataController teacherDataController = new TeacherDataController();
            List<Teacher> teachers = teacherDataController.GetTeachers();

            return View(teachers);
        }
        //GET: /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController teacherDataController = new TeacherDataController();
            Teacher foundTeacher = teacherDataController.FindTeacherById(id);

            ClassDataController classDataController = new ClassDataController();
            List<Class> classes = classDataController.FindClassesByTeacherId(id);

            TeacherViewModel teacherViewModel = new TeacherViewModel
            {
                teacher = foundTeacher,
                classes = classes
            };
            return View(teacherViewModel);
        }

        [HttpPost]
        public ActionResult Search(string searchbox, string filter)
        {
            TeacherDataController teacherDataController = new TeacherDataController();
            Teacher foundTeacher = null;
            if (filter == "name")
            {
                foundTeacher = teacherDataController.FindTeacherByName(searchbox);
            }
            else if (filter == "hiredate")
            {
                foundTeacher = teacherDataController.FindTeacherByHireDate(searchbox);
            }
            else if (filter == "salary")
            {
                foundTeacher = teacherDataController.FindTeacherBySalary(searchbox);
            }
            return View(foundTeacher);
        }

        public ActionResult New()
        {
            return View();
        }

        //POST: /Teacher/Create
        [HttpPost]
        public ActionResult Create(string fname, string lname, string number, string salary)
        {
            Debug.WriteLine("I have accessed the Create Method!");
            Debug.WriteLine(fname);
            Debug.WriteLine(lname);
            Debug.WriteLine(number);
            Debug.WriteLine(salary);

            Teacher newTeacher = new Teacher(fname, lname, number, salary);
            TeacherDataController teacherDataController = new TeacherDataController();
            teacherDataController.AddTeacher(newTeacher);

            return RedirectToAction("List");
        }

    }
}