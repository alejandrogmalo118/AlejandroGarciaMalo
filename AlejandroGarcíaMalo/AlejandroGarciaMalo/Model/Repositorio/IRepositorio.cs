using System.Collections.Generic;

namespace AlejandroGarciaMalo.Model.Repositorio
{
    public interface IRepositorio
    {
        List<Rebelde> ObtenerTodos();
        void Insertar(Rebelde rebelde);
        void Modificar(Rebelde rebelde);
        bool Exists(Rebelde rebelde);
    }
}
