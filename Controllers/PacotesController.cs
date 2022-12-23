using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Atividade2.Models;

namespace Atividade2.Controllers
{
    public class PacotesController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Cadastro(PacotesTuristicos pt)
        {
            PacotesRepository pr = new PacotesRepository();
            pr.Inserir(pt);
            ViewBag.Mensagem = "Cadastro Realizado com sucesso!"; 
            return View();
        }

        public IActionResult Lista()
        {
            PacotesRepository pr = new PacotesRepository(); 
            List<PacotesTuristicos> listagem = pr.Listar();
            return View(listagem);
        }

        public IActionResult Excluir(int Id)
        {
            PacotesRepository pr = new PacotesRepository();
            PacotesTuristicos pacoteLocalizado = pr.BuscarPorId(Id);
            pr.Excluir(pacoteLocalizado);
            return RedirectToAction("Lista","Pacotes");
        }

        public IActionResult Editar(int Id)
        {
            PacotesRepository pr = new PacotesRepository();
            PacotesTuristicos pacoteLocalizado = pr.BuscarPorId(Id);
            return View(pacoteLocalizado);
        }

        [HttpPost]
        public IActionResult Editar(PacotesTuristicos pt)
        {
            PacotesRepository pr = new PacotesRepository();
            pr.Editar(pt);
            return RedirectToAction("Lista","Pacotes");
        }
    }
}