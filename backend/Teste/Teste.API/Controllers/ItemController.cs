using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Teste.Application.Interfaces;
using Teste.Domain.Entidades;

namespace Teste.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IQrCodeService _qrCodeService;
        private readonly IStorageService _storageService;

        public ItemController(IItemService itemService,
            IQrCodeService qrCodeService,
            IStorageService storageService)
        {
            _itemService = itemService;
            _qrCodeService = qrCodeService;
            _storageService = storageService;
        }

        public IStorageService StorageService { get; }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var items = await _itemService.GetAllItemsAsync();
                if (items == null) return NotFound();

                
                return Ok(items);

            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar recuperar os items. Erro {ex.Message}");
            }            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var item = await _itemService.GetItemByIdAsync(id);
                if (item == null) return NoContent();

                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar recuperar este item. Erro {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Item item)
        {
            try
            {
                var itemResponse = await _itemService.Add(item);
                if (itemResponse == null) return BadRequest();
                var json = JsonConvert.SerializeObject(itemResponse);
                var qrCodeData = _qrCodeService.GenerateQRCode(json);
                var qrCodeImageURL = _itemService.GenerateImageURL("QRCodes", itemResponse.Id.ToString(), qrCodeData);
                return Ok(new {
                    qrCodeUrl = qrCodeImageURL,
                    numItem = itemResponse.NumItem,
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao tentar adicionar este item. Erro {ex.Message}");
            }
        }

        [HttpGet("getImage/{caminho}")]
        public IActionResult GetImage(string caminho)
        {
            string caminhoReal = HttpUtility.UrlDecode(caminho);
            return File(System.IO.File.OpenRead(caminhoReal), "image/jpg");
        }

        [HttpPut]
        public async Task<IActionResult> Put(Item item)
        {
            try
            {
                var itemResponse = await _itemService.Update(item);
                if (itemResponse == null) return NotFound();

                return Ok(itemResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar este item. Erro {ex.Message}");
            }

        }
    }
}
