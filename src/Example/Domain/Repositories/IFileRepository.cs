namespace Example.Domain.Repositories;

public interface IFileRepository
{
    long GetFileSize(string filePath);
}
