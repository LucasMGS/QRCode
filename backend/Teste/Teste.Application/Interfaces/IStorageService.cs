using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Application.Interfaces
{
    public interface IStorageService
    {
        Task<string> UploadImage(string folder, byte[] imageBytes, string storageId);
    }
}
