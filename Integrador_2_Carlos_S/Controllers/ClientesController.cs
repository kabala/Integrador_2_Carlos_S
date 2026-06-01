using Microsoft.AspNetCore.Mvc;
using Integrador_2_Carlos_S.Data;
using Integrador_2_Carlos_S.Models;

namespace Integrador_2_Carlos_S.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ClienteData _clienteData;

        public ClientesController(ClienteData clienteData)
        {
            _clienteData = clienteData;
        }

        public IActionResult Index()
        {
            var clientes = _clienteData.ObtenerTodos();
            return View(clientes);
        }

        public IActionResult Details(int id)
        {
            var cliente = _clienteData.ObtenerPorId(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteData.Crear(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public IActionResult Edit(int id)
        {
            var cliente = _clienteData.ObtenerPorId(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Cliente cliente)
        {
            if (id != cliente.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _clienteData.Actualizar(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public IActionResult Delete(int id)
        {
            var cliente = _clienteData.ObtenerPorId(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _clienteData.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
