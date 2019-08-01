using System;
using System.Text;

namespace AlejandroGarciaMalo.Model
{
    public class Rebelde
    {
        public Rebelde(string nombre, string planeta, DateTime registro)
        {
            Nombre = nombre;
            Planeta = planeta;
            Registro = registro;
        }

        public string Nombre { get; set; }
        public string Planeta { get; set; }
        public DateTime Registro { get; set; }

        /// <summary>
        /// Convierte el rebelde en un string con todas sus propiedades
        /// separadas por comas.
        /// </summary>
        /// <returns></returns>
        public string ConvertToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder
                .Append(Nombre).Append(",")
                .Append(Planeta).Append(",")
                .Append(Registro);

            var strRebelde = stringBuilder.ToString();
            stringBuilder.Clear();

            return strRebelde;
        }
    }
}