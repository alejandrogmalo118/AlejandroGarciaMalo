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