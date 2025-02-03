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
- **dotnet CLI Commands**: A set of commands to help you to manage your project using the dotnet CLI.
  - Config file for the dotnet CLI [commands](../.config/dotnet-tools.json).
- **Paket**: A [package manager](https://fsprojects.github.io/Paket/index.html) for .NET that supports referencing NuGet packages, files from GitHub, Gists, and HTTP. Unlike NuGet, Paket separates transitive dependencies and provides control over conflicting package versions.
  - Config file for Paket [dependencies](../paket.dependencies).
- **Directory.Build.props**: A [file](../Directory.Build.props) that allows you to define common properties for all projects in a solution.
- **Directory.Packages.props**: A [file](../Directory.Packages.props) that allows you to define common package references for all projects in a solution. Used to reference analyzers and tools. Paket is not able to manage these types of dependencies.
- **Analyzers and Code Fixers**: A set of analyzers and code fixers to enforce code quality and style rules.
  - Config file for the analyzers and code fixers [rules](../.editorconfig).
  - References to the analyzers and code fixers in the [Directory.Packages.props](../Directory.Packages.props) file.
- **InternalsVisibleTo**: By default, all projects in the solution are configured to expose internal members to the test projects thanks to configuration in the [Directory.Build.props](../Directory.Build.props) file.
- **.gitignore**: A [file](../.gitignore) that ignores common files for .NET projects and IDEs.
- **.gitattributes**: A [file](../.gitattributes) that sets the default line ending for the repository.
- **.editorconfig**: A [file](../.editorconfig) that defines a coding style for consistent code formatting.
- **NsDepCop**: A [tool](https://github.com/realvizu/NsDepCop) that enforces namespace dependency rules following the Clean Architecture principles.
  - Global config file for NsDepCop [rules](../NsDepCop.json).
  - Config file for project-specific NsDepCop [rules](../src/Example/config.nsdepcop).
- **Husky.NET**: A [tool](https://alirezanet.github.io/Husky.Net/) that enforces code quality and style rules with git hooks.
  - git hooks are available in the [.husky](../.husky) directory.
  - task runner configuration is available in the [task-runner.json](../.husky/task-runner.json) file.
- **Prettier**: A tool to format JSON and YAML files.
  - Configured to run on pre-commit using [Husky.NET](../.husky/task-runner.json) with configuration [.editorconfig](../.editorconfig).
- **Markdownlint**: A tool to enforce style rules for Markdown files.
  - Configured to run on pre-commit using [Husky.NET](../.husky/task-runner.json).
- **Cspell**: A tool to check spelling in Markdown, text, C#, JSON, and YAML files.
  - Configured to run on pre-commit using [Husky.NET](../.husky/task-runner.json) with configuration [.cspell.json](../.config/cspell.json) file.

## Getting Started

1. Run the following command to install the dotnet CLI tools:

    ```bash
    dotnet tool restore
    ```
  
2. Run the following command to install the Paket dependencies:

    ```bash
    dotnet paket restore
    ```

3. Run the following command to install Node.js dependencies:

    ```bash
    npm install
    ```

## Paket Quick Reference

- **Install Paket CLI**:

    ```bash
    dotnet new tool-manifest
    dotnet tool install paket
    ```

- **Restore Paket dependencies**:

    ```bash
    dotnet paket restore
    ```

- **Add a NuGet package dependency**:

    ```bash
    dotnet paket add <package ID> --project <project-name>
    ```

- **Remove a NuGet package dependency**:

    ```bash
    dotnet paket remove <package ID> --project <project-name>
    ```

- **Update packages to the latest version**:

    ```bash
    dotnet paket update
    ```

- **Convert NuGet references to Paket references**:

    ```bash
    dotnet paket convert-from-nuget
    ```

## Husky.NET Quick Reference

- **Install Husky.NET CLI**:

    ```bash
    dotnet new tool-manifest
    dotnet tool install Husky
    ```

- **Set up Husky.NET in the project**:

    ```bash
    dotnet husky install
    ```

- **Run Husky.NET tasks**:

    ```bash
    dotnet husky run
    ```

- **Add new git hooks**:

    ```bash
    dotnet husky add <hook-name>
    ```

## Dotnet format Quick Reference

- **Run dotnet format and apply formatting**:

    ```bash
    dotnet format --verbosity detailed --severity info
    ```

- **Run dotnet format and check formatting**:

    ```bash
    dotnet format --verify-no-changes --verbosity detailed --severity info
    ```

## CSharpier Quick Reference

- **Install CSharpier CLI**:

    ```bash
    dotnet new tool-manifest
    dotnet tool install csharpier
    ```

- **Run CSharpier and apply formatting**:

    ```bash
    dotnet csharpier . --loglevel debug
    ```

- **Run CSharpier and check formatting**:

    ```bash
    dotnet csharpier . --check --loglevel debug
    ```

## Prettier Quick Reference

- **Install Prettier CLI**:

    ```bash
    npm install --save-dev prettier
    ```

- **Run Prettier and apply formatting**:

    ```bash
    npx prettier "**/*.{json,yaml}" --write --log-level log --no-config
    ```

- **Run Prettier and check formatting**:

    ```bash
    npx prettier "**/*.{json,yaml}" --check --log-level log --no-config
    ```

## Markdownlint Quick Reference

- **Install Markdownlint CLI**:

    ```bash
    npm install --save-dev markdownlint-cli
    ```

- **Run Markdownlint**:

    ```bash
    npx markdownlint . --dot --ignore node_modules --ignore packages --ignore CHANGELOG.md --disable MD013
    ```

## Cspell Quick Reference

- **Install Cspell CLI**:

    ```bash
    npm install --save-dev cspell
    ```

- **Run Cspell**:

    ```bash
    npx cspell "**/*.{md,txt,yaml,json,cs}" --config .config/cspell.json
    ```
