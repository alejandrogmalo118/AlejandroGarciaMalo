using AlejandroGarciaMalo.Model.Factoria;
using AlejandroGarciaMalo.Model.Repositorio;
using Autofac;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace AlejandroGarciaMalo
{
    /// <summary>
    /// Descripción breve de WebServiceImperio
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceImperio : WebService
    {
        private static IContainer ContainerDependency { get; set; }

        public WebServiceImperio()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Repositorio>().As<IRepositorio>();
            ContainerDependency = builder.Build();
        }
        
        [WebMethod]
        public bool InsertarRebeldes(List<string> rebeldes)
        {
            foreach (var rebelde in rebeldes)
            {
                var listRebelde = rebelde.Split(',');

                if (DateTime.TryParse(listRebelde[2], out var dtRegistro))
                {
                    var factoriaRebelde = new FactoriaRebelde(listRebelde[0], listRebelde[1], dtRegistro);
                }
                else
                {
                    Utiles.Log.Error($"Imposible convertir {listRebelde[2]} a DateTime");
                    return false;
                }
            }

            using (var scope = ContainerDependency.BeginLifetimeScope())
            {
                var repositorio = scope.Resolve<IRepositorio>();

                foreach (var rebelde in Listas.RebeldesRegistrados)
                {
                    if (!repositorio.Exists(rebelde))
                    {
                        repositorio.Insertar(rebelde);
                    }
                    else
                    {
                        Utiles.Log.Info(
                            $"El rebelde {rebelde.Nombre} ya existe en el registro. Se procederá a modificarlo.");
                        repositorio.Modificar(rebelde);
                    }
                }
            }

            return true;
        }

        [WebMethod]
        public List<string> ObtenerRebeldes()
        {
            using (var scope = ContainerDependency.BeginLifetimeScope())
            {
                var repositorio = scope.Resolve<IRepositorio>();

                Listas.RebeldesRegistrados = repositorio.ObtenerTodos();

                var listStRebeldes = new List<string>();

                if (Listas.RebeldesRegistrados == null || Listas.RebeldesRegistrados.Count == 0)
                {
                    return listStRebeldes;
                }

                foreach (var rebelde in Listas.RebeldesRegistrados)
                {
                    var strRebelde = rebelde.ConvertToString();
                    listStRebeldes.Add(strRebelde);
                }

                return listStRebeldes;
            }
        }
    }
}
