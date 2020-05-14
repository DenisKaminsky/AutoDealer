namespace AutoDealer.Business.Models.Responses.File
{
    public class FileModel : BaseModel
    {
        public string FileName { get; }
        public byte[] Content { get; }

        public FileModel(int id, string fileName, byte[] content) : base(id)
        {
            FileName = fileName;
            Content = content;
        }
    }
}
