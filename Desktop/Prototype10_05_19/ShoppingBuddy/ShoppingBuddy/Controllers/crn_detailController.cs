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
          //populates the list for a view to scroll through
            var crn_detail = db.crn_detail.Include(c => c.campu).Include(c => c.competency).Include(c => c.subject).Include(c => c.term_datetime);
            //first drop down list with no args 
            dropdownMenu();
            //returns the list to the crn_detail index page
            return View(crn_detail.ToList());

        }

        //httpPost is what seperates this index from the first one
        //when the submit button is clicked it jumps to this controller then looks
        //for an index with this http post annotation
        [HttpPost]
 
        //this ActionResult is what filters out the list using if statements
        public ActionResult Index(crn_detail crn)
        {

            //created some variables that contain the primary and foreign keys of the
            //tables
            var CRN = Request.Form["CRNList"].ToString();
            var campus = Request.Form["CampusList"].ToString();
            var Lecturer = Request.Form["LecturerList"].ToString();
            var subject = Request.Form["SubjectList"].ToString();
            
            //uses a drop down menu with all args constructor
            //the reason we have 2 is so that we can save the state of the drop
            //down menu selection
            dropdownMenu(CRN, campus,Lecturer, subject);


            //------------------filters for the list------------------
            //CRN filter
            if (CRN !="" && campus == "" && Lecturer== "" && subject== "" ){
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
        // puts the 3 primary keys of the crn_detail table
        // into a variable and sends it to details view 
        // (logic for the sending to details view is in the partial view in the 
        // shared folder)
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
        public void dropdownMenu(string CRN, string campus, string Lecturer, string subject)
        {
            ViewBag.CampusList = new SelectList(db.campu, "CampusCode", "CampusName",campus);
            ViewBag.LecturerList = new SelectList(db.lecturers, "LecturerID", "GivenName", Lecturer);
            ViewBag.CRNList = new SelectList(db.crn_detail, "CRN", "CRN",CRN);
            //ViewBag.CompetencyList = new SelectList(db.qualifications, "QualCode", "QualName", Qual);
            ViewBag.SubjectList = new SelectList(db.crn_detail, "SubjectCode", "SubjectCode", subject);

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
