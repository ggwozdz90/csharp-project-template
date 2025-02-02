# Template for C# projects

## Features

- **Visual Studio Code Settings**: A set of opinionated [settings](../.vscode/settings.json) for Visual Studio Code.
- **Github Copilot Instructions**: A set of instructions to help you to use Github Copilot in your project for:
  - **[Generating Tests](../.github/copilot-instructions/copilot-test-instructions.md)**:
    - Use NUnit for unit testing.
    - Use FluentAssertions for expressive assertions.
    - Use NSubstitute for mocking dependencies.
    - Use System.IO.Abstractions for file system mocking.
    - Follow the Given-When-Then pattern for structuring tests.
  - **[Commit Messages](../.github/copilot-instructions/copilot-commit-instructions.md)**:
    - Follow the Conventional Commits [specification](https://www.conventionalcommits.org).
    - Use the Reason of Change section to explain why the change was needed.
