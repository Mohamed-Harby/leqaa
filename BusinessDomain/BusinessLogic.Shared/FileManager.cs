namespace BusinessLogic.Shared;
public class FileManager : IFileManager
{
    public async Task<byte[]> GetByteArrayFromImageAsync(string imagePath)
    {
        FileInfo image = new FileInfo(imagePath);
        int length = (int)image.Length;
        byte[] imageConverted = new byte[length];
        using (FileStream fs = image.OpenRead())
        {
            await fs.ReadAsync(imageConverted, 0, length);
        }
        return imageConverted;
    }
    public static async Task<byte[]> GetByteArrayFromImageStaticAsync(string imagePath)
    {
        FileInfo image = new FileInfo(imagePath);
        int length = (int)image.Length;
        byte[] imageConverted = new byte[length];
        using (FileStream fs = image.OpenRead())
        {
            await fs.ReadAsync(imageConverted, 0, length);
        }
        return imageConverted;
    }
}