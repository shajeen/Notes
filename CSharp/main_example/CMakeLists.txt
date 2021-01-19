cmake_minimum_required(VERSION 3.9)
project(main_example VERSION 1.0 LANGUAGES CSharp) 

include(CSharpUtilities)

add_executable(main_example main_example.cs)

# Set the .NET Framework version for the executable.
set_property(TARGET main_example PROPERTY VS_DOTNET_TARGET_FRAMEWORK_VERSION "v4.6")
# Set the executable to be 32-bit.
set_property(TARGET main_example PROPERTY WIN32_EXECUTABLE TRUE)
# Set the C# language version (defaults to 3.0).
set(CMAKE_CSharp_FLAGS "/langversion:latest")
set_property(TARGET main_example PROPERTY VS_DOTNET_REFERENCES
    "Microsoft.CSharp"
    "System"
    "System.Core"
)