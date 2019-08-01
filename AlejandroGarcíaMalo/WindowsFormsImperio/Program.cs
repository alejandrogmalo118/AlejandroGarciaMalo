using AlejandroGarciaMalo.Model.Repositorio;
using Autofac;
using System;
using System.Windows.Forms;

namespace WindowsFormsImperio
{
    public static class Program
    {
        public static IContainer Container { get; set; }

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Repositorio>().As<IRepositorio>();
            Container = builder.Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
