using System.Threading.Tasks;
using Teste.Domain.Entidades;

namespace Teste.Infra.Interfaces
    {
    public interface IGeralPersistence
    {
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}
