using QRCoder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Teste.Application.Interfaces;
using Teste.Domain.Entidades;
using Teste.Infra.Interfaces;

namespace Teste.Application.Interfaces
{
    public class ItemService : IItemService
    {
        private readonly IGeralPersistence _geralPersist;
        private readonly IItemPersistence _itemPersist;

        public ItemService(
            IGeralPersistence context,
            IItemPersistence itemPersist)
        {
            _geralPersist = context;
            _itemPersist = itemPersist;
        }

        public async Task<Item> Add(Item item)
        {
            try
            {
                _geralPersist.Add(item);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return item;
                }
                return null;

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> Delete(int id)
        {
            try
            {
                var item = _itemPersist.GetItemById(id);
                if(item == null) throw new Exception("O item para o delete não foi encontrado");

                _geralPersist.Delete(item);
                return _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GenerateQrCode(string url)
        {
            var generator = new QRCodeGenerator();
            var qrData = generator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrData);
            var qrCodeImage = qrCode.GetGraphic(10);
        }

        public async Task<Item[]> GetAllItemsAsync()
        {
            try
            {
                var items = await _itemPersist.GetAllItems();
                if (items == null) return null;

                return items;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            try
            {
                var item = await _itemPersist.GetItemById(id);
                if (item == null) return null;

                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Item> Update(Item item)
        {
            try
            {
                var existItem = _itemPersist.GetItemById(item.Id) != null;
                if (existItem) return null;
                _geralPersist.Update(item);

                if(await _geralPersist.SaveChangesAsync())
                {
                    return item;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GenerateImageURL(string folder, string imageId, byte[] qrCodeData)
        {
            var imagePath = $"Assets/{folder}/{imageId}.jpg";
            File.WriteAllBytes(@imagePath, qrCodeData);
            var imagePathEncoded = HttpUtility.UrlEncode(imagePath);
            string baseURL = "https://localhost:44380/api/v1/Item/getImage";
            return $"{baseURL}/{imagePathEncoded}";
        }
    }
}
