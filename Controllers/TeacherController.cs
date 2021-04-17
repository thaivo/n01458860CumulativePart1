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
        public ActionResult Search(string nameBox, string hiredateFromBox, string hiredateToBox, string salaryFromBox, string salaryToBox)
        {
            Debug.WriteLine("name: " + nameBox);
            Debug.WriteLine("hiredateFromBox: " + hiredateFromBox);
            Debug.WriteLine("hiredateToBox: " + hiredateToBox);
            Debug.WriteLine("salaryFromBox: " + salaryFromBox);
            Debug.WriteLine("salaryToBox: " + salaryToBox);
            TeacherDataController teacherDataController = new TeacherDataController();
            List<Teacher> foundTeachers = teacherDataController.FindTeachers(nameBox, hiredateFromBox, hiredateToBox, salaryFromBox, salaryToBox);
            return View(foundTeachers);
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

            if(fname == "" || lname == "")
            {
                TempData["error"] = "Invalid teacher name";
                Debug.WriteLine("Invalid teacher name");
                return RedirectToAction("ErrorValidation");
            }
            if(number == "" || salary=="")
            {
                TempData["error"] = "Invalid teacher number or salary";
                Debug.WriteLine("Invalid teacher number or salary");
                return RedirectToAction("ErrorValidation");
            }
            

            Teacher newTeacher = new Teacher(fname, lname, number, salary);
            TeacherDataController teacherDataController = new TeacherDataController();
            teacherDataController.AddTeacher(newTeacher);

            return RedirectToAction("List");
        }

        public ActionResult ErrorValidation()
        {
            return View();
        }

        //GET: /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController teacherDataController = new TeacherDataController();
            Teacher foundTeacher = teacherDataController.FindTeacherById(id);
            return View(foundTeacher);
        }

        //POST: /Teacher/Delete/{id}
        public ActionResult Delete(int id)
        {
            TeacherDataController teacherDataController = new TeacherDataController();
            teacherDataController.DeleteTeacher(id);
            return RedirectToAction("List");
        }

    }
}