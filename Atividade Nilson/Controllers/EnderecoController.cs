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


        [HttpGet]
        public IActionResult Editar(int id)
        {
            var endereco = _enderecoRepositorio.ObterEndereco(id);

            if (endereco == null)
                return NotFound();

            return View(endereco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _enderecoRepositorio.Atualizar(endereco);
                return RedirectToAction(nameof(Index));
            }

            return View(endereco);
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var endereco = _enderecoRepositorio.ObterEndereco(id);

            if (endereco == null)
                return NotFound();

            return View(endereco);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public IActionResult ExcluirConfirmado(int id)
        {
            _enderecoRepositorio.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}