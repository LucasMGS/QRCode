using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using Teste.Application.Interfaces;

namespace Teste.API.Controllers
{
    public class ImageController : Controller
    {
        private readonly IItemService _itemService;

        public ImageController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpPost]
        [Route("/api/v1/uploadImage")]
        public IActionResult UploadFile()
        {
            try
            {
                var file = HttpContext.Request.Form.Files.Count > 0 ?
                    HttpContext.Request.Form.Files[0] : null;
                if (file != null && file.Length > 0)
                {
                    var fileName = file.FileName.Split('.')[0];
                    using var stream = new MemoryStream();
                    file.CopyTo(stream);
                    var fileBytes = stream.ToArray();
                    stream.Close();
                    var imagePathEncoded = _itemService.GenerateImageURL("Images",fileName,fileBytes);
                    return Ok(imagePathEncoded);
                }
                return BadRequest();
            } catch (Exception ex)
            {
                throw new Exception(string.Format("Erro ao fazer upload da imagem: {0}", ex.Message));
            }
        }
    }
}
