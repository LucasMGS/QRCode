using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Threading.Tasks;
using Teste.Domain.Entidades;
using Teste.Infra.Interfaces;

namespace Teste.Infra.Persistences
{
    public class ItemPersistence : IItemPersistence
    {
        private readonly ApplicationContext _context;

        public ItemPersistence(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Item[]> GetAllItems()
        {
            return await _context.Items
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .ToArrayAsync();
        }

        public async Task<Item> GetItemById(int id)
        {
            return await _context.Items.AsNoTracking()
                .OrderBy(x=> x.Id)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Item[]> GetItemsValidated()
        {
            return await _context.Items
                .AsNoTracking()
                .Where(x => x.IsValidated)
                .OrderBy(x => x.Id)
                .ToArrayAsync();
        }
    }
}
