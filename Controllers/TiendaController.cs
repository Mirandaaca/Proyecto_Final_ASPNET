using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_ASPNET.Models;
namespace Proyecto_Final_ASPNET.Controllers
{
    public class TiendaController : Controller
    {
        public IActionResult Index()
        {
            ProductoModelView productoModelView = new ProductoModelView();
            ViewBag.prods = productoModelView.getTodos();
            return View();
        }
    }
}
