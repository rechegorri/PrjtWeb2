using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrjtWeb2_cadastro_ocorrencia.Models;

namespace PrjtWeb2_cadastro_ocorrencia.Controllers
{
    public class OperacionalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Operacional
        public ActionResult Index()
        {
            return View(db.Operacionals.ToList());
        }

        // GET: Operacional/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operacional operacional = db.Operacionals.Find(id);
            if (operacional == null)
            {
                return HttpNotFound();
            }
            return View(operacional);
        }

        // GET: Operacional/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Operacional/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,funcao,nome,endereco,cidade,telefone")] Operacional operacional)
        {
            if (ModelState.IsValid)
            {
                db.Operacionals.Add(operacional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(operacional);
        }

        // GET: Operacional/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operacional operacional = db.Operacionals.Find(id);
            if (operacional == null)
            {
                return HttpNotFound();
            }
            return View(operacional);
        }

        // POST: Operacional/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,funcao,nome,endereco,cidade,telefone")] Operacional operacional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operacional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(operacional);
        }

        // GET: Operacional/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operacional operacional = db.Operacionals.Find(id);
            if (operacional == null)
            {
                return HttpNotFound();
            }
            return View(operacional);
        }

        // POST: Operacional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Operacional operacional = db.Operacionals.Find(id);
            db.Operacionals.Remove(operacional);
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
