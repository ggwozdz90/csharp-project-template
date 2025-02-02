using Example.Domain.Repositories;

namespace Example.Domain.Services;

internal interface IFileService
{
    long GetFileSize(string filePath);
}

internal class FileService(IFileRepository fileRepository) : IFileService
{
    public long GetFileSize(string filePath)
    {
        return fileRepository.GetFileSize(filePath);
    }
}
