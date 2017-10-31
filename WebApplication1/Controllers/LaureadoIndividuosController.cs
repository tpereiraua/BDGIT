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
    public class LaureadoIndividuosController : Controller
    {
        private NobelEntities db = new NobelEntities();

        // GET: LaureadoIndividuos
        public ActionResult Index()
        {
            var laureadoIndividuo = db.LaureadoIndividuo.Include(l => l.CidadeNascimento).Include(l => l.CidadaMorte).Include(l => l.Laureado);
            return View(laureadoIndividuo.ToList());
        }

        // GET: LaureadoIndividuos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaureadoIndividuo laureadoIndividuo = db.LaureadoIndividuo.Find(id);
            if (laureadoIndividuo == null)
            {
                return HttpNotFound();
            }
            return View(laureadoIndividuo);
        }

        // GET: LaureadoIndividuos/Create
        public ActionResult Create()
        {
            ViewBag.CidadeNascimentoId = new SelectList(db.Cidade, "CidadeId", "Nome");
            ViewBag.CidadeMorteId = new SelectList(db.Cidade, "CidadeId", "Nome");
            ViewBag.LaureadoId = new SelectList(db.Laureado, "LaureadoId", "LaureadoTipo");
            return View();
        }

        // POST: LaureadoIndividuos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LaureadoId,Nome,DataNascimento,DataMorte,CidadeNascimentoId,CidadeMorteId,Sexo")] LaureadoIndividuo laureadoIndividuo)
        {
            if (ModelState.IsValid)
            {
                db.LaureadoIndividuo.Add(laureadoIndividuo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CidadeNascimentoId = new SelectList(db.Cidade, "CidadeId", "Nome", laureadoIndividuo.CidadeNascimentoId);
            ViewBag.CidadeMorteId = new SelectList(db.Cidade, "CidadeId", "Nome", laureadoIndividuo.CidadeMorteId);
            ViewBag.LaureadoId = new SelectList(db.Laureado, "LaureadoId", "LaureadoTipo", laureadoIndividuo.LaureadoId);
            return View(laureadoIndividuo);
        }

        // GET: LaureadoIndividuos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaureadoIndividuo laureadoIndividuo = db.LaureadoIndividuo.Find(id);
            if (laureadoIndividuo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CidadeNascimentoId = new SelectList(db.Cidade, "CidadeId", "Nome", laureadoIndividuo.CidadeNascimentoId);
            ViewBag.CidadeMorteId = new SelectList(db.Cidade, "CidadeId", "Nome", laureadoIndividuo.CidadeMorteId);
            ViewBag.LaureadoId = new SelectList(db.Laureado, "LaureadoId", "LaureadoTipo", laureadoIndividuo.LaureadoId);
            return View(laureadoIndividuo);
        }

        // POST: LaureadoIndividuos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LaureadoId,Nome,DataNascimento,DataMorte,CidadeNascimentoId,CidadeMorteId,Sexo")] LaureadoIndividuo laureadoIndividuo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(laureadoIndividuo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CidadeNascimentoId = new SelectList(db.Cidade, "CidadeId", "Nome", laureadoIndividuo.CidadeNascimentoId);
            ViewBag.CidadeMorteId = new SelectList(db.Cidade, "CidadeId", "Nome", laureadoIndividuo.CidadeMorteId);
            ViewBag.LaureadoId = new SelectList(db.Laureado, "LaureadoId", "LaureadoTipo", laureadoIndividuo.LaureadoId);
            return View(laureadoIndividuo);
        }

        // GET: LaureadoIndividuos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaureadoIndividuo laureadoIndividuo = db.LaureadoIndividuo.Find(id);
            if (laureadoIndividuo == null)
            {
                return HttpNotFound();
            }
            return View(laureadoIndividuo);
        }

        // POST: LaureadoIndividuos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LaureadoIndividuo laureadoIndividuo = db.LaureadoIndividuo.Find(id);
            db.LaureadoIndividuo.Remove(laureadoIndividuo);
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
