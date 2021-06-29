using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using service;

//using Domain;
using Laboratorio12.Models;
using System.Threading.Tasks;

namespace Laboratorio12.Controllers
{
    public class StudentController : Controller
    {
        //private StudentService service = new StudentService();
        Proxy.StudentProxy proxy = new Proxy.StudentProxy();
        public ActionResult IndexRazor()
        {
            //var model = (from c in service.Get()
            //             select new StudentModel
            //             {
            //                 ID = c.studentID,
            //                 Address = c.studentAddress,
            //                 Name = c.studentName
            //             }).ToList();
            //return View(model);

            var response = Task.Run(() => proxy.GetStudentAsync());
            return View(response.Result.listado);



        }

        public ActionResult Index()
        {
            return View();

        }

        public JsonResult getStudent(string id)
        {
            //return Json(service.Get(), JsonRequestBehavior.AllowGet);
            var response = Task.Run(() => proxy.GetStudentAsync());
            return Json(response.Result.listado, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]

        //public ActionResult createStudent(Student std)
        public ActionResult createStudent(StudentModel std)
        {
            //service.Insert(std);
            //string message = "SUCCESS";
            //return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            var response = Task.Run(() => proxy.InsertAsync(std));
            string message = response.Result.Mensaje;
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });

        }
    }
}