using AutoDealer.Miscellaneous.Enums;
using AutoDealer.Miscellaneous.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDealer.Miscellaneous.FileSystem
{
    public class FileManager : IFileManager
    {
        private readonly List<string> _sessionPaths = new List<string>();
        private readonly Dictionary<FileDestinations, string> _folders = new Dictionary<FileDestinations, string>();

        public FileManager(string rootDirectory, string carPhotoRootDirectory, string supplierPhotoRootDirectory)
        {
            _folders[FileDestinations.CarPhoto] = Path.Combine(rootDirectory, carPhotoRootDirectory);
            _folders[FileDestinations.SupplierPhoto] = Path.Combine(rootDirectory, supplierPhotoRootDirectory);
        }

        public async Task<string> SaveAsync(IFileAttachment file, FileDestinations type)
        {
            var directoryPath = _folders[type];
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var fileName = $"{Guid.NewGuid()}.{file.FileName.Split('.').Last()}";
            var fullName = Path.Combine(directoryPath, fileName);

            await using (var stream = File.Create(fullName))
            {
                await file.CopyToAsync(stream);
            }

            _sessionPaths.Add(fullName);
            return fileName;
        }

        public Task<byte[]> LoadAsync(string fileName, FileDestinations type)
        {        
            var filePath = Path.Combine(_folders[type], fileName);

            if (!File.Exists(filePath))
                throw new FileNotFoundException("File was not found!");

            return File.ReadAllBytesAsync(Path.Combine(_folders[type], fileName));
        }

        public void RollBack()
        {
            foreach (var path in _sessionPaths)
            {
                File.Delete(path);
            }
        }
    }
}
