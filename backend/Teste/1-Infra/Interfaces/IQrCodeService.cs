using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    interface IQrCodeService
    {
        void GenerateQrCode();
        void BitmapToBytes(Bitmap img);
    }
}
