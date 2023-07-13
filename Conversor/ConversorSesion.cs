using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Proyecto_Final_ASPNET.Conversor
{
    public static class ConversorSesion
    {
        public static void ConvertirAjson(this ISession sesion, string llave, object valor)
        {
            sesion.SetString(llave, JsonConvert.SerializeObject(valor));
        }
        public static T ConvertirACsharp<T>(this ISession sesion, string llave)
        {
            var valor = sesion.GetString(llave);
            return valor == null ? default : JsonConvert.DeserializeObject<T>(valor);
        }
    }
}
