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

        TeacherDataController teacherDataController = new TeacherDataController();
        //Search interface 
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        //GET: /Teacher/List
        public ActionResult List()
        {

            try
            {
                List<Teacher> teachers = teacherDataController.GetTeachers();

                return View(teachers);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }
        //GET: /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
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
            
            
            try
            {
                List<Teacher> foundTeachers = teacherDataController.FindTeachers(nameBox, hiredateFromBox, hiredateToBox, salaryFromBox, salaryToBox);
                return View(foundTeachers);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult Add()
        {
            return View();
        }

        //POST: /Teacher/Create
        [HttpPost]
        public ActionResult Create(string fname, string lname, string number, string hiredate, string salary)
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
            

            Teacher newTeacher = new Teacher(fname, lname, number, hiredate, salary);
         
            teacherDataController.AddTeacher(newTeacher);

            return RedirectToAction("List");
        }

        public ActionResult ErrorValidation()
        {
            return View();
        }

        //GET: /Teacher/Error
        /// <summary>
        /// This window is for showing Teacher specific Errors!
        /// </summary>
        public ActionResult Error()
        {
            return View();
        }

        //GET: /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            
            try
            {
                Teacher foundTeacher = teacherDataController.FindTeacherById(id);
                return View(foundTeacher);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        //POST: /Teacher/Delete/{id}
        public ActionResult Delete(int id)
        {
           
            try
            {
                teacherDataController.DeleteTeacher(id);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        //GET: /Teacher/Update/{id}
        //Represent the teacher with current data
        [HttpGet]
        public ActionResult Update(int id)
        {
            try
            {
                Teacher selectedTeacher = teacherDataController.FindTeacherById(id);
                return View(selectedTeacher);
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Error", "Home");
            }
            
        }

        //POST: /Teacher/Update/{id}

        /// <summary>
        /// Receives a POST request containing information about an existing teacher in the system, with new values. Conveys this information to the API, and redirects to the "teacher show" page of our updated teacher.
        /// </summary>
        /// <param name="id">Id of the teacher to update</param>
        /// <param name="fname">the updated first name of the teacher</param>
        /// <param name="lname">the updated last name of the teacher</param>
        /// <param name="number">the updated number of the teacher</param>
        /// <param name="salary">the updated salary of the teacher</param>
        /// <param name="hiredate">the updated hiredate of the teacher</param>
        /// <returns>
        /// A dynamice webpage which provides the current information of the teacher.
        /// </returns>
        /// <example>
        /// POST:/Teacher/Update/22
        /// FORM DATA/ POST DATA/ REQUEST BODY
        /// {
        /// ///	"fname":"Nguyen",
        ///	"lname":"Vo",
        ///	"number":"T234",
        ///	"salary":"70",
        ///	"hiredate": "2020-05-20"
        /// }
        /// </example>
        /// 
        [HttpPost]
        public ActionResult Update(int id, string fname, string lname, string number, string salary, string hiredate)
        {
            Debug.WriteLine("Teacher is " + fname + " " + lname);
            try
            {
                Teacher updateTeacherInfo = new Teacher(fname, lname, number, hiredate, salary);
                updateTeacherInfo.id = id.ToString();
                //Call the data access logic to update this teacher
                TeacherDataController teacherDataController = new TeacherDataController();
                teacherDataController.updateTeacher(id, updateTeacherInfo);
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction("Show/" + id);
        }

        /// <summary>
        /// Routes to a dynamically rendered "Ajax Update" Page. The "Ajax Update" page will utilize Js to send an HTTP request to the data access layer
        /// </summary>
        /// <param name="id">id of a teacher</param>
        /// <returns></returns>
        public ActionResult Ajax_update(int id)
        {
            try
            {
                Teacher SelectedTeacher = teacherDataController.FindTeacherById(id);
                return View(SelectedTeacher);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }
    }


}