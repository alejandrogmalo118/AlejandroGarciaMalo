using AlejandroGarciaMalo.Model;
using AlejandroGarciaMalo.Model.Repositorio;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AlejandroGarcíaMalo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly log4net.ILog Log
            = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static IContainer Container { get; set; }

        private static readonly List<string> Rebeldes = new List<string>()
        {
            "Luke Skywalker,Tatoine,12-01-16 12:32",
            "Han Solo,Alderaan,13-06-17 16:13",
            "R2-D2,Yavin,03-02-14 17:32"
        };

        private static readonly List<Rebelde> ListRebeldes = new List<Rebelde>();

        public UnitTest1()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Repositorio>().As<IRepositorio>();
            Container = builder.Build();
        }

        [TestMethod]
        public void ComprobarRebeldes()
        {
            foreach (var rebelde in Rebeldes)
            {
                var listRebelde = rebelde.Split(',');

                if (listRebelde.Length != 3)
                {
                    Log.Error($"El rebelde {rebelde} en la lista obtenida no tiene los 3 campos predeterminados.");
                    Assert.Fail();
                }

                if (!int.TryParse(listRebelde[0], out var n) || !int.TryParse(listRebelde[0], out var m)) continue;

                Log.Error($"El rebelde {rebelde} en la lista obtenida no tiene que ser númerico");
                Assert.Fail();


            }
        }

        [TestMethod]
        public void ObtenerRebeldes()
        {
            RellenarListaRebeldes();

            Assert.AreEqual(ListRebeldes.Count, 3);
        }

        [TestMethod]
        public void InsertarRebelde()
        {
            int numRebeldes;

            using (var scope = Container.BeginLifetimeScope())
            {
                var repositorio = scope.Resolve<IRepositorio>();

                foreach (var rebelde in ListRebeldes)
                {
                    if (!repositorio.Exists(rebelde))
                    {
                        repositorio.Insertar(rebelde);
                    }
                    else
                    {
                        Log.Info($"El rebelde {rebelde.Nombre} ya existe en el registro. Se procederá a modificarlo.");
                    }
                }

                numRebeldes = repositorio.ObtenerTodos().Count;
            }

            Assert.AreEqual(numRebeldes, 3);
        }

        [TestMethod]
        public void ModificarRebelde()
        {
            var rebelde = new Rebelde("Luke Skywalker", "Scarif", DateTime.Now);

            using (var scope = Container.BeginLifetimeScope())
            {
                var repositorio = scope.Resolve<IRepositorio>();

                repositorio.Modificar(rebelde);

            }
        }

        private static void RellenarListaRebeldes()
        {
            foreach (var rebelde in Rebeldes)
            {
                var listRebelde = rebelde.Split(',');

                if (int.TryParse(listRebelde[0], out var n) || int.TryParse(listRebelde[0], out var m)) continue;

                if (DateTime.TryParse(listRebelde[2], out var dtRegistro))
                {
                    ListRebeldes.Add(new Rebelde(listRebelde[0], listRebelde[1], dtRegistro));
                }
                else
                {
                    Log.Error($"Imposible convertir {listRebelde[2]} a DateTime");
                    Assert.Fail();
                }
            }
        }

    }
}
