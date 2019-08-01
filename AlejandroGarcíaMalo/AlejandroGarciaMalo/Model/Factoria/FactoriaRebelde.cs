using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AlejandroGarciaMalo.Model.Factoria
{
    /// <summary>
    /// Factoria para crear rebeldes y añadirlos a la lista de rebeldes registrados.
    /// </summary>
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

        /// <summary>
        /// Crea un rebelde y lo añade a la lista si no existe previamente.
        /// </summary>
        public sealed override void CrearObjeto()
        {
            var rebelde = new Rebelde(Nombre, Planeta, Registro);

            if (Listas.RebeldesRegistrados != null && !Listas.RebeldesRegistrados.Exists(c => c.Nombre.Equals(rebelde.Nombre)))
            {
                Listas.RebeldesRegistrados.Add(rebelde);
            }
        }
    }
    
    public static partial class Listas
    {
        /// <summary>
        /// Lista con todos los rebeldes registrados.
        /// </summary>
        public static List<Rebelde> RebeldesRegistrados = new List<Rebelde>();
    }
}