using AlejandroGarciaMalo.Model.Factoria;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace AlejandroGarciaMalo.Model.Repositorio
{
    public class Repositorio : IRepositorio
    {
        private const string Path = "RegistroRebeldes.txt";

        /// <summary>
        /// Obtener todos los rebeldes que haya en el fichero.
        /// </summary>
        /// <returns>Lista de rebeldes</returns>
        public List<Rebelde> ObtenerTodos()
        {
            var listRebelde = new List<Rebelde>();

            if (!File.Exists(Path))
            {
                return listRebelde;
            }
            
            try
            {
                using (var reader = File.OpenText(Path))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        var rebelde = line.Split(',');

                        if (rebelde.Length != 3) continue;

                        if (DateTime.TryParse(rebelde[2], out var dtRegistro))
                        {
                            var factoriaRebelde = new FactoriaRebelde(rebelde[0], rebelde[1], dtRegistro);
                            listRebelde.Add(new Rebelde(rebelde[0], rebelde[1], dtRegistro));
                        }
                        else
                        {
                            Utiles.Log.Error($"Imposible convertir {rebelde[2]} a DateTime");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Utiles.Log.Error($"Error ocurrido en el método {nameof(ObtenerTodos)}. Excepción {e}");
                throw;
            }
            

            return listRebelde;
        }

        /// <summary>
        /// Inserta en el fichero el rebelde que se pase por parametro.
        /// </summary>
        /// <param name="rebelde"></param>
        public void Insertar(Rebelde rebelde)
        {
            using (var writer = File.AppendText(Path))
            {
                writer.WriteLine(rebelde.ConvertToString());
            }
        }

        /// <summary>
        /// Modifica una linea del fichero si el nombre del rebelde dado concide con alguno del fichero,
        /// cambiando el planeta y el registro.
        /// </summary>
        /// <param name="rebelde"></param>
        public void Modificar(Rebelde rebelde)
        {
            string[] rows;

            try
            {
                using (var sr = new StreamReader(Path))
                {
                    rows = Regex.Split(sr.ReadToEnd(), "\r\n");
                }
            }
            catch (Exception e)
            {
                Utiles.Log.Error($"Error ocurrido en el método {nameof(Modificar)}. Excepción {e}");
                throw;
            }
            
            if (!Exists(rebelde)) return;

            using (var sw = new StreamWriter(Path))
            {
                for (var i = 0; i < rows.Length; i++)
                {
                    if (rows[i].Contains(rebelde.Nombre))
                    {
                        var listRebelde = rows[i].Split(',');

                        if (listRebelde.Length != 3) continue;

                        var rowReplace = rows[i].Replace
                        (
                            listRebelde[1],
                            rebelde.Planeta
                        );

                        rows[i] = rowReplace;
                        
                        string dateRegistro;
                        try
                        {
                            dateRegistro = rebelde.Registro.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        }
                        catch (Exception e)
                        {
                            Utiles.Log.Error($"Error ocurrido en el método {nameof(Modificar)}. Excepción {e}");
                            throw;
                        }

                        rowReplace = rows[i].Replace
                        (
                            listRebelde[2], dateRegistro
                        );

                        rows[i] = rowReplace;
                        
                    }

                    sw.WriteLine(rows[i]);
                }
            }
        }
        
        /// <summary>
        /// Comprobación de la existencia del rebelde dado en el fichero.
        /// Antes se comprueba si existe el fichero.
        /// </summary>
        /// <param name="rebelde"></param>
        /// <returns></returns>
        public bool Exists(Rebelde rebelde)
        {
            return File.Exists(Path) && ObtenerTodos().Exists(r => r.Nombre.Equals(rebelde.Nombre));
        }
        
    }
}
