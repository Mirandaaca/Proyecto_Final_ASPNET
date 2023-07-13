using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_ASPNET.Conversor;
using Proyecto_Final_ASPNET.Models;

namespace Proyecto_Final_ASPNET.Controllers
{
    public class CarritoController : Controller
    {
        public IActionResult Index()
        {
            List<Elemento> carrito = ConversorSesion.ConvertirACsharp<List<Elemento>>(HttpContext.Session, "carrito");
            ViewBag.carrito = carrito;
            ViewBag.total = carrito.Sum(it => it.producto.precio * it.cantidad);
            return View();
        }
        public IActionResult Agregar(int id)
        {
            ProductoModelView productoModelView = new ProductoModelView();
            if (ConversorSesion.ConvertirACsharp<List<Elemento>>(HttpContext.Session, "carrito") == null)
            {
                List<Elemento> carrito = new List<Elemento>();
                carrito.Add(new Elemento { producto = productoModelView.getProducto(id.ToString()), cantidad = 1 });
                ConversorSesion.ConvertirAjson(HttpContext.Session, "carrito", carrito);
            }
            else
            {
                List<Elemento> carrito = ConversorSesion.ConvertirACsharp<List<Elemento>>(HttpContext.Session, "carrito");

                int indice = existe(id.ToString());
                if (indice != -1)
                {
                    carrito[indice].cantidad++;
                }
                else
                {
                    carrito.Add(new Elemento { producto = productoModelView.getProducto(id.ToString()), cantidad = 1 });
                }
                ConversorSesion.ConvertirAjson(HttpContext.Session, "carrito", carrito);
            }
            return RedirectToAction("Index");
        }
        [NonAction]
        private int existe(string id)
        {
            List<Elemento> carrito = ConversorSesion.ConvertirACsharp<List<Elemento>>(HttpContext.Session, "carrito");
            for (int i = 0; i < carrito.Count; i++)
                if (carrito[i].producto.id.Equals(id.ToString()))
                    return i;
            return -1;
        }
        [Route("EliminarElemento/{id}")]
        public IActionResult EliminarItem(string id)
        {
            List<Elemento> carrito = ConversorSesion.ConvertirACsharp<List<Elemento>>(HttpContext.Session, "carrito");
            int indice = existe(id.ToString());
            if (indice >= 0)
            {
                if (carrito[indice].cantidad > 1)
                {
                    carrito[indice].cantidad--;
                }
                else
                {
                    carrito.RemoveAt(indice);
                }
            }
            ConversorSesion.ConvertirAjson(HttpContext.Session, "carrito", carrito);
            return RedirectToAction("Index");
        }
    }
}
