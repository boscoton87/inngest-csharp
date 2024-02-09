# inngest-csharp

## Setup:
 * Install the dotnet sdk:
    * https://learn.microsoft.com/en-us/dotnet/core/sdk
 * Navigate to the root of the repository (directory with the .sln file).
 * Execute `dotnet publish`
    * This will create build artifacts at Inngest.CSharp/bin/Release/net8.0/{os-arch}
    * Within this artifacts folder there will be a publish folder containing an executable that has all dependencies and the runtime bundled into a single file.
