using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LaureadoOrganizacaosController : Controller
    {
        private NobelEntities db = new NobelEntities();

        // GET: LaureadoOrganizacaos
        public ActionResult Index()
        {
            var laureadoOrganizacao = db.LaureadoOrganizacao.Include(l => l.Laureado);
            return View(laureadoOrganizacao.ToList());
        }

        // GET: LaureadoOrganizacaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaureadoOrganizacao laureadoOrganizacao = db.LaureadoOrganizacao.Find(id);
            if (laureadoOrganizacao == null)
            {
                return HttpNotFound();
            }
            return View(laureadoOrganizacao);
        }

        // GET: LaureadoOrganizacaos/Create
        public ActionResult Create()
        {
            ViewBag.LaureadoId = new SelectList(db.Laureado, "LaureadoId", "LaureadoTipo");
            return View();
        }

        // POST: LaureadoOrganizacaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LaureadoId,Nome")] LaureadoOrganizacao laureadoOrganizacao)
        {
            if (ModelState.IsValid)
            {
                db.LaureadoOrganizacao.Add(laureadoOrganizacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LaureadoId = new SelectList(db.Laureado, "LaureadoId", "LaureadoTipo", laureadoOrganizacao.LaureadoId);
            return View(laureadoOrganizacao);
        }

        // GET: LaureadoOrganizacaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaureadoOrganizacao laureadoOrganizacao = db.LaureadoOrganizacao.Find(id);
            if (laureadoOrganizacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.LaureadoId = new SelectList(db.Laureado, "LaureadoId", "LaureadoTipo", laureadoOrganizacao.LaureadoId);
            return View(laureadoOrganizacao);
        }

        // POST: LaureadoOrganizacaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LaureadoId,Nome")] LaureadoOrganizacao laureadoOrganizacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(laureadoOrganizacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LaureadoId = new SelectList(db.Laureado, "LaureadoId", "LaureadoTipo", laureadoOrganizacao.LaureadoId);
            return View(laureadoOrganizacao);
        }

        // GET: LaureadoOrganizacaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaureadoOrganizacao laureadoOrganizacao = db.LaureadoOrganizacao.Find(id);
            if (laureadoOrganizacao == null)
            {
                return HttpNotFound();
            }
            return View(laureadoOrganizacao);
        }

        // POST: LaureadoOrganizacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LaureadoOrganizacao laureadoOrganizacao = db.LaureadoOrganizacao.Find(id);
            db.LaureadoOrganizacao.Remove(laureadoOrganizacao);
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
