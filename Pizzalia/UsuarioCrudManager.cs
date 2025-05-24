using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Pizzalia
{
    public static class UsuarioCrudManager
    {
        private static string ruta = "usuarios_crud.json";

        public static List<Usuario> CargarUsuarios()
        {
            if (!File.Exists(ruta))
                return new List<Usuario>();

            var json = File.ReadAllText(ruta);
            return JsonConvert.DeserializeObject<List<Usuario>>(json) ?? new List<Usuario>();
        }

        public static void GuardarUsuarios(List<Usuario> usuarios)
        {
            var json = JsonConvert.SerializeObject(usuarios, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(ruta, json);
        }
    }
}
