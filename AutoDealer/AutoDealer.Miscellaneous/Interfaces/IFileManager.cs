using AutoDealer.Miscellaneous.Enums;
using System.Threading.Tasks;

namespace AutoDealer.Miscellaneous.Interfaces
{
    public interface IFileManager
    {
        Task<string> SaveAsync(IFileAttachment file, FileDestinations type);

        Task<byte[]> LoadAsync(string fileName, FileDestinations type);

        Task DeleteAsync(string fileName, FileDestinations type);

        void RollBack();
    }
}
