using System;
using System.Threading.Tasks;
using Teste.Domain.Entidades;
using Teste.Infra;
using Teste.Infra.Interfaces;

namespace Teste.Infra.Persistences
{
    public class GeralPersistence : IGeralPersistence
    {
        private readonly ApplicationContext _context;

        public GeralPersistence(ApplicationContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
