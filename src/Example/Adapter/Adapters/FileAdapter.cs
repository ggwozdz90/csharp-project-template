using Example.Application.UseCases;

namespace Example.Adapter.Adapters;

public interface IFileAdapter
{
    long GetFileSize(string filePath);
}

public class FileAdapter(IGetFileSizeUseCase getFileSizeUseCase) : IFileAdapter
{
    public long GetFileSize(string filePath)
    {
        return getFileSizeUseCase.Execute(filePath);
    }
}
