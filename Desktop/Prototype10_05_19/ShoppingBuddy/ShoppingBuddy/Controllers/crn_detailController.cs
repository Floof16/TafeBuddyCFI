using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingBuddy.Models;

namespace ShoppingBuddy.Controllers
{
    public class crn_detailController : Controller
    {
        private TafeBuddyEntities db = new TafeBuddyEntities();

        // GET: crn_detail
        public ActionResult Index()
        {
          
            var crn_detail = db.crn_detail.Include(c => c.campu).Include(c => c.competency).Include(c => c.subject).Include(c => c.term_datetime);
            dropdownMenu();
            return View(crn_detail.ToList());

        }
        [HttpPost]
   //public ActionResult Index(string CRN, string CampusCode, string LecturerID, string CRN2)
        public ActionResult Index(crn_detail crn)
        {

            //ViewBag.CampusList = new SelectList(db.campu, "CampusCode", "CampusName", db.campu);
            //ViewBag.LecturerList = new SelectList(db.lecturers, "LecturerID", "GivenName");
            //ViewBag.CRNList = new SelectList(db.crn_detail, "CRN", "CRN", db.crn_detail);
            //ViewBag.CompetencyList = new SelectList(db.qualifications, "QualCode", "QualName");
            //ViewBag.SubjectList = new SelectList(db.crn_detail, "CRN", "SubjectCode");

            
            dropdownMenu();
            //To do: finish the campus, lecturer and subject filters with if statements
            var CRN = Request.Form["CRNList"].ToString();
            var campus = Request.Form["CampusList"].ToString();
            var Lecturer = Request.Form["LecturerList"].ToString();
            var subject = Request.Form["SubjectList"].ToString();
            
            //CRN filter
            if(CRN !="" && campus == "" && Lecturer== "" && subject== "" ){
                var crn_detail = db.crn_detail.Include(c => c.campu).Include(c => c.competency).Include(c => c.subject).Include(c => c.term_datetime).Where(a => a.CRN.Equals(CRN));
                return View(crn_detail.ToList());
            }
            //CRN, campus filter
            if (CRN != "" && campus != "" && Lecturer=="" && subject=="")
            {
                var crn_detail = db.crn_detail.Include(c => c.campu).Include(c => c.competency).Include(c => c.subject).Include(c => c.term_datetime).Where(a => a.CRN.Equals(CRN) && a.CampusCode.Equals(campus));

                return View(crn_detail.ToList());
            }
            //CRN, subject filter
            if (CRN != "" && campus=="" && Lecturer == "" && subject != "")
            {
                var crn_detail = db.crn_detail.Include(c => c.campu).Include(c => c.competency).Include(c => c.subject).Include(c => c.term_datetime).Where(a => a.CRN.Equals(CRN) && a.SubjectCode.Equals(subject));

                return View(crn_detail.ToList());
            }
            //CRN, lecturer filter
            if (CRN != "" && campus == "" && Lecturer != "" && subject == "")
            {
                var crn_detail = db.crn_detail.Include(c => c.campu).Include(c => c.competency).Include(c => c.subject).Include(c => c.term_datetime).Where(a => a.CRN.Equals(CRN) && a.LecturerID.Equals(Lecturer));

                return View(crn_detail.ToList());
            }
            //CRN, campus, lecturer filter
            if (CRN != "" && campus != "" && Lecturer != "" && subject == "")
            {
                var crn_detail = db.crn_detail.Include(c => c.campu).Include(c => c.competency).Include(c => c.subject).Include(c => c.term_datetime).Where(a => a.CRN.Equals(CRN) && a.CampusCode.Equals(campus) && a.LecturerID.Equals(Lecturer));

                return View(crn_detail.ToList());
            }

            //CRN, campus, subject filter
            if (CRN != "" && campus != "" && Lecturer == "" && subject != "")
            {
                var crn_detail = db.crn_detail.Include(c => c.campu).Include(c => c.competency).Include(c => c.subject).Include(c => c.term_datetime).Where(a => a.CRN.Equals(CRN) && a.CampusCode.Equals(campus) && a.SubjectCode.Equals(subject));

                return View(crn_detail.ToList());
            }
            //CRN, subject, lecturer filter
            if (CRN != "" && campus == "" && Lecturer != "" && subject != "")
            {
                var crn_detail = db.crn_detail.Include(c => c.campu).Include(c => c.competency).Include(c => c.subject).Include(c => c.term_datetime).Where(a => a.CRN.Equals(CRN) && a.SubjectCode.Equals(subject) && a.LecturerID.Equals(Lecturer));

                return View(crn_detail.ToList());
            }

            //CRN, campus, lecturer, subject filter
            if (CRN != "" && campus != "" && Lecturer != "" && subject != "")
            {
                var crn_detail = db.crn_detail.Include(c => c.campu).Include(c => c.competency).Include(c => c.subject).Include(c => c.term_datetime).Where(a => a.CRN.Equals(CRN) && a.CampusCode.Equals(campus) && a.LecturerID.Equals(Lecturer) && a.SubjectCode.Equals(subject));

                return View(crn_detail.ToList());
            }
            // campus
            if (CRN == "" && campus != "" && Lecturer == "" && subject == "")
            {
                var crn_detail = db.crn_detail.Include(c => c.campu).Include(c => c.competency).Include(c => c.subject).Include(c => c.term_datetime).Where(a => a.CampusCode.Equals(campus));

                return View(crn_detail.ToList());
            }

            // campus, lecturer, subject filter
            if (CRN == "" && campus != "" && Lecturer != "" && subject != "")
            {
                var crn_detail = db.crn_detail.Include(c => c.campu).Include(c => c.competency).Include(c => c.subject).Include(c => c.term_datetime).Where(a => a.CampusCode.Equals(campus) && a.LecturerID.Equals(Lecturer) && a.SubjectCode.Equals(subject));

                return View(crn_detail.ToList());
            }

            //lecturer filter
            if (CRN == "" && campus == "" && Lecturer != "" && subject == "")
            {
                var crn_detail = db.crn_detail.Include(c => c.campu).Include(c => c.competency).Include(c => c.subject).Include(c => c.term_datetime).Where(a => a.LecturerID.Equals(Lecturer));

                return View(crn_detail.ToList());
            }
            // lecturer, subject filter
            if (CRN == "" && campus == "" && Lecturer != "" && subject != "")
            {
                var crn_detail = db.crn_detail.Include(c => c.campu).Include(c => c.competency).Include(c => c.subject).Include(c => c.term_datetime).Where(a => a.LecturerID.Equals(Lecturer) && a.SubjectCode.Equals(subject));

                return View(crn_detail.ToList());
            }
            // subject filter
            if (CRN == "" && campus == "" && Lecturer == "" && subject != "")
            {
                var crn_detail = db.crn_detail.Include(c => c.campu).Include(c => c.competency).Include(c => c.subject).Include(c => c.term_datetime).Where(a => a.SubjectCode.Equals(subject));

                return View(crn_detail.ToList());
            }
            //no item selected

            if (CRN == "" && campus == "" && Lecturer == "" && subject == "")
            {
                var crn_detail = db.crn_detail.Include(c => c.campu).Include(c => c.competency).Include(c => c.subject).Include(c => c.term_datetime);

                return View(crn_detail.ToList());
            }


            return View();
        }
        // GET: crn_detail/Details/5
        public ActionResult Details(string id, int termCodeStart,
            int termYearStart)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            crn_detail crn_detail = db.crn_detail.Find(
                id,     
                termCodeStart,
                termYearStart

            );
            
            if (db.crn_detail == null)
            {
                return HttpNotFound();
            }
            return View(crn_detail);
        }

        //populates the dropdown menu
        public void dropdownMenu()
        {
            ViewBag.CampusList = new SelectList(db.campu, "CampusCode", "CampusName");
            ViewBag.LecturerList = new SelectList(db.lecturers, "LecturerID", "GivenName");
            ViewBag.CRNList = new SelectList(db.crn_detail, "CRN", "CRN");
            ViewBag.CompetencyList = new SelectList(db.qualifications, "QualCode", "QualName");
            ViewBag.SubjectList = new SelectList(db.crn_detail, "SubjectCode", "SubjectCode");
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
