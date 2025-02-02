# C# Testing Guidelines for GitHub Copilot

## Naming Convention

```csharp
MethodName_Scenario_ExpectedResult

Examples:
- GetUser_WithValidId_ReturnsUser
- SaveData_WhenDatabaseError_ThrowsException
```

## Tools Usage

- **NUnit**: Test framework
- **NSubstitute**: For mocking (`Substitute.For<T>()`)
- **FluentAssertions**: For assertions (`result.Should().Be()`)
- **System.IO.Abstractions**: For file system mocking

## Common Scenarios Reference

Check these aspects when writing tests:

- Validation logic
- Error handling
- External dependencies
- Async operations
- Resource cleanup
- Test coverage

## Required Test Cases

1. Success path
2. Error handling
3. Edge cases (null, empty, invalid data)
4. Async operations
5. Dependencies behavior

## Test Structure

```csharp
using Microsoft.Extensions.Logging;
using System.IO.Abstractions;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

[TestFixture]
internal sealed class ServiceNameTests
{
    private ILogger<ServiceName> logger = null!;
    private IExternalService externalService = null!;
    private ServiceName service = null!;

    [SetUp]
    public void Setup()
    {
        logger = Substitute.For<ILogger<ServiceName>>();
        externalService = Substitute.For<IExternalService>();
        service = new ServiceName(logger, externalService);
    }

    [Test]
    public async Task ProcessFile_WhenExternalServiceFails_ReturnsError()
    {
        // Given
        IFileInfo file = Substitute.For<IFileInfo>();
        file.FullName.Returns("test.txt");
        externalService
            .ProcessAsync(file.FullName)
            .ThrowsAsync(new ServiceException());

        // When
        var result = await service.ProcessFileAsync(file);

        // Then
        result.Should().Be(ErrorCode.ProcessingError);
        await externalService
            .Received(1)
            .ProcessAsync(file.FullName);
        logger.Received(1).Log(
            LogLevel.Error,
            Arg.Any<EventId>(),
            Arg.Is<object>(o => o.ToString().Contains("Processing failed")),
            Arg.Any<Exception>(),
            Arg.Any<Func<object?, Exception?, string>>()
        );
    }
}
```
