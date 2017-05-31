using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.DAL;
using System.IO;

namespace MvcApplication2.Controllers
{
    //[Authorize]
    public class PersonalContactController : Controller
    {
        private PersonalContactContext db = new PersonalContactContext();

        //
        // GET: /PersonalContact/

        public ActionResult Index()
        {
            return
                string.IsNullOrWhiteSpace(User.Identity.Name) ?
                     View() :
                        View(db.PersonalContacts
                            .Where(u => u.UserName == User.Identity.Name)
                            .ToList());
        }

        //
        // GET: /PersonalContact/Details/5

        public ActionResult Details(int id = 0)
        {
            PersonalContactModel personalcontactmodel = db.PersonalContacts.Find(id);
            if (personalcontactmodel == null)
            {
                return HttpNotFound();
            }
            return View(personalcontactmodel);
        }

        //
        // GET: /PersonalContact/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PersonalContact/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonalContactModel personalcontactmodel)
        {
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(User.Identity.Name))
            {
                personalcontactmodel.UserName = User.Identity.Name;

                db.PersonalContacts.Add(personalcontactmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personalcontactmodel);
        }

        //
        // GET: /PersonalContact/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PersonalContactModel personalcontactmodel = db.PersonalContacts.Find(id);
            if (personalcontactmodel == null)
            {
                return HttpNotFound();
            }
            return View(personalcontactmodel);
        }

        //
        // POST: /PersonalContact/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonalContactModel personalcontactmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalcontactmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personalcontactmodel);
        }

        //
        // GET: /PersonalContact/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PersonalContactModel personalcontactmodel = db.PersonalContacts.Find(id);
            if (personalcontactmodel == null)
            {
                return HttpNotFound();
            }
            return View(personalcontactmodel);
        }

        //
        // POST: /PersonalContact/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalContactModel personalcontactmodel = db.PersonalContacts.Find(id);
            db.PersonalContacts.Remove(personalcontactmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }



        public PartialViewResult Notes(int personalContactId = 0)
        {
            if ( personalContactId > 0 )
            {
                PersonalContactContext db = new PersonalContactContext();

                PersonalContactModel record = db.PersonalContacts.Find(personalContactId);

                return PartialView("~/Views/PersonalContact/Notes.cshtml", record);
            }

            return PartialView("~/Views/PersonalContact/Notes.cshtml", personalContactId);
        }

        [HttpPost]
        public bool SaveNotes( int PersonalContactId ) //, object context)
        {
            var request = this.HttpContext.Request.InputStream;

            if ( request != null )
            {
                try
                {
                    string note = new StreamReader(request).ReadToEnd();

                    if (!string.IsNullOrWhiteSpace(note))
                    {
                        PersonalContactContext db = new PersonalContactContext();

                        PersonalContactModel record = db.PersonalContacts.Find(PersonalContactId);

                        record.Notes = note;

                        if ( ModelState.IsValid )
                        {
                            db.Entry(record).State = EntityState.Modified;

                            db.SaveChanges();

                            db.SaveChanges();

                            return true;
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }

            return false;
        }
    }
}