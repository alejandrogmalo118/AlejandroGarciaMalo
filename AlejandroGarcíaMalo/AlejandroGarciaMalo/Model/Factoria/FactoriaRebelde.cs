using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AlejandroGarciaMalo.Model.Factoria
{
    public class FactoriaRebelde : FactoriaBase
    {
        public string Nombre { get; set; }
        public string Planeta { get; set; }
        public DateTime Registro { get; set; }

        public FactoriaRebelde(string nombre, string planeta, DateTime registro)
        {
            Nombre = nombre;
            Planeta = planeta;
            Registro = registro;
            CrearObjeto();
        }

        public sealed override void CrearObjeto()
        {
            var rebelde = new Rebelde(Nombre, Planeta, Registro);

            if (Listas.RebeldesRegistrados != null && !Listas.RebeldesRegistrados.Exists(c => c.Nombre.Equals(rebelde.Nombre)))
            {
                Listas.RebeldesRegistrados.Add(rebelde);
            }
        }
    }

    public static class Listas
    {
        public static List<Rebelde> RebeldesRegistrados = new List<Rebelde>();
    }
}