using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wizard.Models;

namespace Wizard.Controllers
{
    public class CarreraxCursoesController : Controller
    {
        private ARE_SeminarioEntities db = new ARE_SeminarioEntities();

        // GET: CarreraxCursoes
        public ActionResult Index()
        {
            var carreraxCursoes = db.CarreraxCursoes.Include(c => c.Carrera).Include(c => c.Curso);
            return View(carreraxCursoes.ToList());
        }

        // GET: CarreraxCursoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarreraxCurso carreraxCurso = db.CarreraxCursoes.Find(id);
            if (carreraxCurso == null)
            {
                return HttpNotFound();
            }
            return View(carreraxCurso);
        }

        // GET: CarreraxCursoes/Create
        public ActionResult Create()
        {
            ViewBag.idCarrera = new SelectList(db.Carreras, "idCarrera", "nombre");
            ViewBag.idCurso = new SelectList(db.Cursoes, "idCurso", "nombre");
            return View();
        }

        // POST: CarreraxCursoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRelacion,idCarrera,idCurso")] CarreraxCurso carreraxCurso)
        {
            if (ModelState.IsValid)
            {
                db.CarreraxCursoes.Add(carreraxCurso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCarrera = new SelectList(db.Carreras, "idCarrera", "nombre", carreraxCurso.idCarrera);
            ViewBag.idCurso = new SelectList(db.Cursoes, "idCurso", "nombre", carreraxCurso.idCurso);
            return View(carreraxCurso);
        }

        // GET: CarreraxCursoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarreraxCurso carreraxCurso = db.CarreraxCursoes.Find(id);
            if (carreraxCurso == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCarrera = new SelectList(db.Carreras, "idCarrera", "nombre", carreraxCurso.idCarrera);
            ViewBag.idCurso = new SelectList(db.Cursoes, "idCurso", "nombre", carreraxCurso.idCurso);
            return View(carreraxCurso);
        }

        // POST: CarreraxCursoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRelacion,idCarrera,idCurso")] CarreraxCurso carreraxCurso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carreraxCurso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCarrera = new SelectList(db.Carreras, "idCarrera", "nombre", carreraxCurso.idCarrera);
            ViewBag.idCurso = new SelectList(db.Cursoes, "idCurso", "nombre", carreraxCurso.idCurso);
            return View(carreraxCurso);
        }

        // GET: CarreraxCursoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarreraxCurso carreraxCurso = db.CarreraxCursoes.Find(id);
            if (carreraxCurso == null)
            {
                return HttpNotFound();
            }
            return View(carreraxCurso);
        }

        // POST: CarreraxCursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarreraxCurso carreraxCurso = db.CarreraxCursoes.Find(id);
            db.CarreraxCursoes.Remove(carreraxCurso);
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
