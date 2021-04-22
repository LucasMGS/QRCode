using Application.Interfaces;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace Teste.Application.Services
{
    public class QrCodeService : IQrCodeService
    { 

        private Bitmap GenerateImage(string json)
        {
            var generator = new QRCodeGenerator();
            var data = generator.CreateQrCode(json, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(data);
            var qrCodeImage = qrCode.GetGraphic(15);
            return qrCodeImage;
        }

        public byte[] GenerateQRCode(string json)
        {
            var image = GenerateImage(json);
            return ImageToByte(image);
        }

        private byte[] ImageToByte(Image img)
        {
            using var stream = new MemoryStream();
            img.Save(stream, ImageFormat.Jpeg);
            return stream.ToArray();
        }
    }
}
