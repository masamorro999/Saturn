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
    public class PolizasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Polizas
        public ActionResult Index()
        {
            var poliza = db.Poliza.Include(p => p.Contrato);
            return View(poliza.ToList());
        }

        // GET: Polizas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poliza poliza = db.Poliza.Find(id);
            if (poliza == null)
            {
                return HttpNotFound();
            }
            return View(poliza);
        }

        // GET: Polizas/Create
        public ActionResult Create()
        {
            ViewBag.ContratoID = new SelectList(db.Contratos, "ContratoID", "CodContrato");
            return View();
        }

        // POST: Polizas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PolizaID,Descripcion,FechaIni,ContratoID")] Poliza poliza)
        {
            if (ModelState.IsValid)
            {
                db.Poliza.Add(poliza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContratoID = new SelectList(db.Contratos, "ContratoID", "CodContrato", poliza.ContratoID);
            return View(poliza);
        }

        // GET: Polizas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poliza poliza = db.Poliza.Find(id);
            if (poliza == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContratoID = new SelectList(db.Contratos, "ContratoID", "CodContrato", poliza.ContratoID);
            return View(poliza);
        }

        // POST: Polizas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PolizaID,Descripcion,FechaIni,ContratoID")] Poliza poliza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poliza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContratoID = new SelectList(db.Contratos, "ContratoID", "CodContrato", poliza.ContratoID);
            return View(poliza);
        }

        // GET: Polizas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poliza poliza = db.Poliza.Find(id);
            if (poliza == null)
            {
                return HttpNotFound();
            }
            return View(poliza);
        }

        // POST: Polizas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Poliza poliza = db.Poliza.Find(id);
            db.Poliza.Remove(poliza);
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
