namespace AutoDealer.Business.Models.Responses.File
{
    public class FileModel : BaseModel
    {
        public string FileName { get; }
        public int FileSize { get; }
        public byte[] Content { get; }

        public FileModel(int id, string fileName, int fileSize, byte[] content) : base(id)
        {
            FileName = fileName;
            FileSize = fileSize;
            Content = content;
        }
    }
}
