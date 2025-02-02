using Example.Application.UseCases;
using Example.Domain.Repositories;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

namespace Example.Tests.Application.UseCases;

[TestFixture]
internal sealed class GetFileSizeUseCaseTests
{
    private IFileRepository fileRepository = null!;
    private GetFileSizeUseCase getFileSizeUseCase = null!;

    [SetUp]
    public void Setup()
    {
        fileRepository = Substitute.For<IFileRepository>();
        getFileSizeUseCase = new GetFileSizeUseCase(fileRepository);
    }

    [Test]
    public void Execute_WithValidFilePath_ReturnsFileSize()
    {
        // Given
        var filePath = "validFilePath.txt";
        var expectedSize = 1024L;
        fileRepository.GetFileSize(filePath).Returns(expectedSize);

        // When
        var result = getFileSizeUseCase.Execute(filePath);

        // Then
        result.Should().Be(expectedSize);
        fileRepository.Received(1).GetFileSize(filePath);
    }

    [Test]
    public void Execute_WhenRepositoryThrowsException_ThrowsException()
    {
        // Given
        var filePath = "invalidFilePath.txt";
        fileRepository.GetFileSize(filePath).Throws(new Exception("File not found"));

        // When
        Action act = () => getFileSizeUseCase.Execute(filePath);

        // Then
        act.Should().Throw<Exception>().WithMessage("File not found");
        fileRepository.Received(1).GetFileSize(filePath);
    }
}
