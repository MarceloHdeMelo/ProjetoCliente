using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CadastroCliente.DAL;
using CadastroCliente.Models;
using CadastroCliente.Entidades;
using CadastroCliente.Mappers;

namespace CadastroCliente.Views
{
    public class EnderecoController : Controller
    {
        private ContextoCliente db = new ContextoCliente();

        // GET: Endereco
        public ActionResult Index()
        {
            var enderecos = db.Enderecos.Include(e => e.Cliente);
            return View(MapperHelper.Map<Endereco, EnderecoViewModel>(enderecos.ToList()));
        }

        // GET: Endereco/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var endereco = db.Enderecos.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            var model = Mapper.Map<Endereco, EnderecoViewModel>(endereco);
            return View(model);
        }

        // GET: Endereco/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nome");
            return View();
        }

        // POST: Endereco/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CEP,Logradouro,Numero,Complemento,Bairro,Estado,Cidade,ClienteID")] EnderecoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var endereco = Mapper.Map<EnderecoViewModel, Endereco>(model);
                db.Enderecos.Add(endereco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nome", model.ClienteId);
            return View(model);
        }

        // GET: Endereco/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var endereco = db.Enderecos.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nome", endereco.ClienteId);
            var model = Mapper.Map<Endereco, EnderecoViewModel>(endereco);
            return View(model);
        }

        // POST: Endereco/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CEP,Logradouro,Numero,Complemento,Bairro,Estado,Cidade,ClienteID")] EnderecoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var endereco = Mapper.Map<EnderecoViewModel, Endereco>(model);
                db.Entry(endereco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nome", model.ClienteId);
            return View(model);
        }

        // GET: Endereco/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var endereco = db.Enderecos.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }

            var model = Mapper.Map<Endereco, EnderecoViewModel>(endereco);
            return View(model);
        }

        // POST: Endereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var endereco = db.Enderecos.Find(id);
            db.Enderecos.Remove(endereco);
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
