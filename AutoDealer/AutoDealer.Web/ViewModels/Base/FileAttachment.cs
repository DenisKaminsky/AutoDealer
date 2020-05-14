using System.IO;
using System.Threading.Tasks;
using AutoDealer.Miscellaneous.Interfaces;
using Microsoft.AspNetCore.Http;

namespace AutoDealer.Web.ViewModels.Base
{
    public class FileAttachment : IFileAttachment
    {
        private readonly IFormFile _file;
        public string FileName => _file.FileName;
        public long FileSize => _file.Length;

        public FileAttachment(IFormFile file)
        {
            _file = file;
        }

        public Task CopyToAsync(FileStream stream)
        {
            return _file.CopyToAsync(stream);
        }
    }
}
