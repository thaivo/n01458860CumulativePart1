using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using n01458860CumulativePart1.Models;
using n01458860CumulativePart1.ViewModels;
namespace n01458860CumulativePart1.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            TeacherDataController teacherDataController = new TeacherDataController();
            List<Teacher> teachers = teacherDataController.GetTeachers();

            return View(teachers);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="factor"></param>
        /// <returns></returns>
        public ActionResult Show(int id)
        {
            TeacherDataController teacherDataController = new TeacherDataController();
            Teacher foundTeacher = teacherDataController.FindTeacherById(id);

            CourseDataController courseDataController = new CourseDataController();
            List<Class> classes = courseDataController.FindCoursesByTeacherId(id);

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

    }
}