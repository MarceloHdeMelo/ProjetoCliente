using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CadastroCliente.DAL;
using CadastroCliente.Entidades;
using CadastroCliente.Mappers;
using CadastroCliente.Models;

namespace CadastroCliente.Controllers
{
    public class ClienteController : Controller
    {
        private ContextoCliente db = new ContextoCliente();

        // GET: Cliente
        public ActionResult Index()
        {
            var listaClientes = MapperHelper.Map<Cliente, ClienteViewModel>(db.Clientes.ToList());
            return View(listaClientes);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            ClienteViewModel model = new ClienteViewModel();
            try
            {
                model.Id = cliente.Id;
                model.Nome = cliente.Nome;
                model.Email = cliente.Email;
                model.DataNascimento = cliente.DataNascimento;
                model.Sexo = cliente.Sexo;

                foreach (var endereco in cliente.Enderecos)
                {
                    model.Enderecos.Add(new EnderecoViewModel
                    {
                        Id = endereco.Id,
                        CEP = endereco.CEP,
                        Logradouro = endereco.Logradouro,
                        Complemento = endereco.Complemento,
                        Numero = endereco.Numero,
                        Bairro = endereco.Bairro,
                        Cidade = endereco.Cidade,
                        Estado = endereco.Estado,
                        ClienteId = endereco.ClienteId
                    });
                }
                
            }
            catch (Exception erro)
            {
                ViewBag.Mensagem = erro.Message;
            }
           
            return View(model);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,DataNascimento,Sexo,Email")] ClienteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cliente = new Cliente();
                try
                {
                    cliente.Id = model.Id;
                    cliente.Nome = model.Nome;
                    cliente.Email = model.Email;
                    cliente.DataNascimento = model.DataNascimento;
                    cliente.Sexo = model.Sexo;

                    foreach (var endereco in model.Enderecos)
                    {
                        cliente.Enderecos.Add(new Endereco
                        {
                            Id = endereco.Id,
                            CEP = endereco.CEP,
                            Logradouro = endereco.Logradouro,
                            Complemento = endereco.Complemento,
                            Numero = endereco.Numero,
                            Bairro = endereco.Bairro,
                            Cidade = endereco.Cidade,
                            Estado = endereco.Estado,
                            ClienteId = endereco.ClienteId
                        });
                    }

                }
                catch (Exception erro)
                {
                    ViewBag.Mensagem = erro.Message;
                }

                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            ClienteViewModel model = new ClienteViewModel();
            try
            {
                model.Id = cliente.Id;
                model.Nome = cliente.Nome;
                model.Email = cliente.Email;
                model.DataNascimento = cliente.DataNascimento;
                model.Sexo = cliente.Sexo;

                foreach (var endereco in cliente.Enderecos)
                {
                    model.Enderecos.Add(new EnderecoViewModel
                    {
                        Id = endereco.Id,
                        CEP = endereco.CEP,
                        Logradouro = endereco.Logradouro,
                        Complemento = endereco.Complemento,
                        Numero = endereco.Numero,
                        Bairro = endereco.Bairro,
                        Cidade = endereco.Cidade,
                        Estado = endereco.Estado,
                        ClienteId = endereco.ClienteId
                    });
                }

            }
            catch (Exception erro)
            {
                ViewBag.Mensagem = erro.Message;
            }
            return View(model);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,DataNascimento,Sexo,Email")] ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ClienteViewModel model = new ClienteViewModel();
            try
            {
                model.Id = cliente.Id;
                model.Nome = cliente.Nome;
                model.Email = cliente.Email;
                model.DataNascimento = cliente.DataNascimento;
                model.Sexo = cliente.Sexo;

                foreach (var endereco in cliente.Enderecos)
                {
                    model.Enderecos.Add(new EnderecoViewModel
                    {
                        Id = endereco.Id,
                        CEP = endereco.CEP,
                        Logradouro = endereco.Logradouro,
                        Complemento = endereco.Complemento,
                        Numero = endereco.Numero,
                        Bairro = endereco.Bairro,
                        Cidade = endereco.Cidade,
                        Estado = endereco.Estado,
                        ClienteId = endereco.ClienteId
                    });
                }

            }
            catch (Exception erro)
            {
                ViewBag.Mensagem = erro.Message;
            }

            return View(model);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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
