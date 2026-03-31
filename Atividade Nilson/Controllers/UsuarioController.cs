using Atividade_Nilson.Models;
using Atividade_Nilson.Repositorio.Contrato;
using Microsoft.AspNetCore.Mvc;

namespace Atividade_Nilson.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public IActionResult CadastrarUsuario()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepositorio.Cadastrar(usuario);
                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }

        public IActionResult Index()
        {
            return View(_usuarioRepositorio.ObterTodosUsuarios());
        }

        [HttpGet]
        public IActionResult AtualizarUsuario(int id)
        {
            return View(_usuarioRepositorio.ObterUsuario(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AtualizarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepositorio.Atualizar(usuario);
                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }

        [HttpGet]
        public IActionResult DetalhesUsuario(int id)
        {
            return View(_usuarioRepositorio.ObterUsuario(id));
        }

        [HttpGet]
        public IActionResult ExcluirUsuario(int id)
        {
            var usuario = _usuarioRepositorio.ObterUsuario(id);
            return View(usuario);
        }

        [HttpPost, ActionName("ExcluirUsuario")]
        [ValidateAntiForgeryToken]
        public IActionResult ExcluirUsuarioConfirmado(int id)
        {
            _usuarioRepositorio.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}