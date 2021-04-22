using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Teste.API
{
    public class IndexModel : PageModel
    {
        private readonly IQrCodeService qrCodeService;

        IndexModel(IQrCodeService qrCodeService)
        {
            this.qrCodeService = qrCodeService;
        }
        public IActionResult OnGet()
        {
            var image = qrCodeService.GenerateQRCode("asd");
            return File(image, "image/jpeg");
        }
    }
}
