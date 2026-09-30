using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using AccesoDatos.Data;

namespace AccesoDatos.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Agregar(T entidad)
        {
            _dbSet.Add(entidad);
            _context.SaveChanges();
        }

        public void Actualizar(T entidad)
        {
            _dbSet.Update(entidad);
            _context.SaveChanges();
        }

        public void Eliminar(T entidad)
        {
            _dbSet.Remove(entidad);
            _context.SaveChanges();
        }

        public List<T> Listar() => _dbSet.ToList();

        public T? ObtenerPorId(int id) => _dbSet.Find(id); //buscar por id, devuelve null si no lo encuentra t?
    }
}

