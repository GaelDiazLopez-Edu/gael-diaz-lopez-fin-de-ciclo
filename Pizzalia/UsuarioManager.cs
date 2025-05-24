using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Pizzalia
{
    public class UsuariosData
    {
        public string Administrador { get; set; }
        public Dictionary<string, string> Repartidores { get; set; }
    }

    public static class UsuarioManager
    {
        private static string ruta = "usuarios.json";
        private static UsuariosData usuarios;

        static UsuarioManager()
        {
            Cargar();
        }

        public static void Cargar()
        {
            if (!File.Exists(ruta))
            {
                // Si el archivo no existe, se crea con valores por defecto
                usuarios = new UsuariosData
                {
                    Administrador = "pizzalia123",
                    Repartidores = new Dictionary<string, string>
                    {
                        { "Juan", "repartidor123" },
                        { "Ana", "ana456" }
                    }
                };
                Guardar(); // Se crea el archivo con los datos iniciales
            }
            else
            {
                string json = File.ReadAllText(ruta);
                usuarios = JsonConvert.DeserializeObject<UsuariosData>(json);
            }
        }

        public static void Guardar()
        {
            string json = JsonConvert.SerializeObject(usuarios, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(ruta, json);
        }

        public static bool ValidarAdministrador(string password)
        {
            return usuarios.Administrador == password;
        }

        public static void CambiarContraseñaAdministrador(string nuevaContra)
        {
            usuarios.Administrador = nuevaContra;
            Guardar();
        }

        public static Dictionary<string, string> ObtenerRepartidores()
        {
            return usuarios.Repartidores;
        }

        public static bool ValidarRepartidor(string nombre, string password)
        {
            return usuarios.Repartidores.ContainsKey(nombre) && usuarios.Repartidores[nombre] == password;
        }

        public static void CambiarContraseñaRepartidor(string nombre, string nuevaContra)
        {
            if (usuarios.Repartidores.ContainsKey(nombre))
            {
                usuarios.Repartidores[nombre] = nuevaContra;
                Guardar();
            }
        }
    }
}
