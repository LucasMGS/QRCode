using Firebase.Storage;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Teste.Application.Interfaces;

namespace Teste.Application.Services
{
    public class StorageService : IStorageService
    {
        private readonly string BUCKET = "qr-code-79e6c.appspot.com";
        public async Task<string> UploadImage(string folder, byte[] imageBytes, string storageId)
        {
            try
            {
                var cancellation = new CancellationTokenSource();
                var firebaseStorage = new FirebaseStorage(BUCKET, new FirebaseStorageOptions
                {
                    ThrowOnCancel = true
                });
                using var stream = new MemoryStream(imageBytes);
                return await firebaseStorage.Child(folder).Child($"{storageId}.jpg").PutAsync(stream, cancellation.Token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
