using Firebase.Storage;
using System.Drawing;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IQrCodeService
    {
        byte[] GenerateQRCode(string json);
    }
}
