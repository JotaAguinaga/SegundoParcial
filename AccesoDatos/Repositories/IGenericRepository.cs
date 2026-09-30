using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;

namespace AccesoDatos.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Agregar(T entidad);
        void Actualizar(T entidad);
        void Eliminar(T entidad);
        List<T> Listar();
        T? ObtenerPorId(int id);
    }
}

