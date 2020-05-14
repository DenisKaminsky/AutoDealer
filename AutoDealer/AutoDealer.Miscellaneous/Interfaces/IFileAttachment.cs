using System.IO;
using System.Threading.Tasks;

namespace AutoDealer.Miscellaneous.Interfaces
{
    public interface IFileAttachment
    {
        string FileName { get; }
        long FileSize { get; }
        Task CopyToAsync(FileStream stream);
    }
}
