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

        public void Insertar(Rebelde rebelde)
        {
            using (var writer = File.AppendText(Path))
            {
                writer.WriteLine(rebelde.ConvertToString());
            }
        }

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
        
        public bool Exists(Rebelde rebelde)
        {
            return File.Exists(Path) && ObtenerTodos().Exists(r => r.Nombre.Equals(rebelde.Nombre));
        }
        
    }
}
