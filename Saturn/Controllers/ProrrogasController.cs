using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Saturn.Models;

namespace Saturn.Controllers
{
    public class ProrrogasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prorrogas
        public ActionResult Index()
        {
            var prorrogas = db.Prorrogas.Include(p => p.Contrato);
            return View(prorrogas.ToList());
        }

        // GET: Prorrogas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prorroga prorroga = db.Prorrogas.Find(id);
            if (prorroga == null)
            {
                return HttpNotFound();
            }
            return View(prorroga);
        }

        // GET: Prorrogas/Create
        public ActionResult Create()
        {
            ViewBag.ContratoID = new SelectList(db.Contratos, "ContratoID", "CodContrato");
            return View();
        }

        // POST: Prorrogas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProrrogaID,Descripcion,FechaIni,FechaFin,ContratoID")] Prorroga prorroga)
        {
            if (ModelState.IsValid)
            {
                db.Prorrogas.Add(prorroga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContratoID = new SelectList(db.Contratos, "ContratoID", "CodContrato", prorroga.ContratoID);
            return View(prorroga);
        }

        // GET: Prorrogas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prorroga prorroga = db.Prorrogas.Find(id);
            if (prorroga == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContratoID = new SelectList(db.Contratos, "ContratoID", "CodContrato", prorroga.ContratoID);
            return View(prorroga);
        }

        // POST: Prorrogas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProrrogaID,Descripcion,FechaIni,FechaFin,ContratoID")] Prorroga prorroga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prorroga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContratoID = new SelectList(db.Contratos, "ContratoID", "CodContrato", prorroga.ContratoID);
            return View(prorroga);
        }

        // GET: Prorrogas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prorroga prorroga = db.Prorrogas.Find(id);
            if (prorroga == null)
            {
                return HttpNotFound();
            }
            return View(prorroga);
        }

        // POST: Prorrogas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prorroga prorroga = db.Prorrogas.Find(id);
            db.Prorrogas.Remove(prorroga);
            db.SaveChanges();
            return RedirectToAction("Index");
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
