using System.Threading.Tasks;
using Teste.Domain.Entidades;

namespace Teste.Infra.Interfaces
{
    public interface IItemPersistence
    {
        Task<Item[]> GetAllItems();
        Task<Item[]> GetItemsValidated();
        Task<Item> GetItemById(int id);
    }
}
