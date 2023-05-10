namespace BusinessLogic.Shared;
public interface IFileManager
{
    Task<byte[]> GetByteArrayFromImageAsync(string imagePath);
}