namespace Proyecto_Final_ASPNET.Models
{
    public class ProductoModelView
    {
        private List<Producto> productos;
        public ProductoModelView()
        {
            productos = new List<Producto>() {
                new Producto {
                    id = 1,
                    nombre = "Queso",
                    precio = 15,
                    foto = "QuesoCatupiry.jpg"
                },
                new Producto {
                    id = 2,
                    nombre = "Atun",
                    precio = 7,
                    foto = "AtunSanLucas.jpg"
                },
                new Producto {
                    id = 3,
                    nombre = "Leche",
                    precio = 12,
                    foto = "LecheMiLeche.jpg"
                }
            };
        }

        public List<Producto> getTodos()
        {
            return productos;
        }

        public Producto getProducto(string codigo)
        {
            return productos.Single(p => p.id.Equals(codigo));
        }
    }
}
