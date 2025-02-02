using Example.Domain.Repositories;

namespace Example.Application.UseCases;

public interface IGetFileSizeUseCase
{
    long Execute(string filePath);
}

public class GetFileSizeUseCase(IFileRepository fileRepository) : IGetFileSizeUseCase
{
    public long Execute(string filePath)
    {
        return fileRepository.GetFileSize(filePath);
    }
}
