namespace BusinessLogic.Application.Interfaces;
public interface IFileManager
{
    Task<byte[]> GetByteArrayFromImageAsync(string imagePath);
}