using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlatPlanet.Models;

namespace FlatPlanet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var exam = new Exam();
            using (var context = new ExamContext())
            {
                var exams = context.Exams;

                if (!exams.Any())
                {
                    context.Exams.Add(new Exam() { Counter = 0});
                    context.SaveChanges();
                }

                exam = exams.FirstOrDefault(c => c.Id == 1);
            }
            return View(exam);
        }

        [HttpPost]
        public ActionResult AddCounter()
        {
            using (var context = new ExamContext())
            {
                var exams = context.Exams;

                if (exams.Any())
                {
                    var exam = exams.FirstOrDefault(c => c.Id == 1);
                    if (exam?.Counter < 10)
                    {
                        exam.Counter++;
                        context.SaveChanges();
                    }
                }

                if(Request.IsAjax())
                {
                    return JsonResult(Exam.Counter);
                }
            }

            return RedirectToAction("Index");
        }
    }
}