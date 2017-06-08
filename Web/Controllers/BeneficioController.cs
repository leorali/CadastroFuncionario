using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AcessoDados;
using Negocio;

namespace Web.Controllers
{
    public class BeneficioController : BaseController
    {
        private CadastroFuncionarioContext db = new CadastroFuncionarioContext();

        // GET: Beneficio
        public ActionResult Index()
        {
            return View(db.Beneficios.ToList());
        }

        // GET: Beneficio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beneficio beneficio = db.Beneficios.Find(id);
            if (beneficio == null)
            {
                return HttpNotFound();
            }
            return View(beneficio);
        }

        // GET: Beneficio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Beneficio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipo")] Beneficio beneficio)
        {
            if (ModelState.IsValid)
            {
                db.Beneficios.Add(beneficio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(beneficio);
        }

        // GET: Beneficio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beneficio beneficio = db.Beneficios.Find(id);
            if (beneficio == null)
            {
                return HttpNotFound();
            }
            return View(beneficio);
        }

        // POST: Beneficio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo")] Beneficio beneficio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beneficio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beneficio);
        }

        // GET: Beneficio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beneficio beneficio = db.Beneficios.Find(id);
            if (beneficio == null)
            {
                return HttpNotFound();
            }
            return View(beneficio);
        }

        // POST: Beneficio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Beneficio beneficio = db.Beneficios.Find(id);
            db.Beneficios.Remove(beneficio);
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
