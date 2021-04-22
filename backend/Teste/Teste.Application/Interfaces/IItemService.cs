using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Domain.Entidades;

namespace Teste.Application.Interfaces
{
    public interface IItemService
    {
        Task<Item> Add(Item item);
        Task<Item[]> GetAllItemsAsync();
        Task<Item> GetItemByIdAsync(int id);
        Task<bool> Delete(int id);
        Task<Item> Update(Item item);
        string GenerateImageURL(string folder, string imageId, byte[] qrCodeData);      
    }
}
