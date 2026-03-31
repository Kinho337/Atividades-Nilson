using Atividade_Nilson.Models;
using Atividade_Nilson.Repositorio.Contrato;
using Microsoft.AspNetCore.Mvc;

namespace Atividade_Nilson.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;

        public EnderecoController(IEnderecoRepositorio enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
        }

        public IActionResult Index()
        {
            var enderecos = _enderecoRepositorio.ObterTodosEnderecos();
            return View(enderecos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _enderecoRepositorio.Cadastrar(endereco);
                return RedirectToAction(nameof(Index));
            }

            return View(endereco);
        }
    }
}