cmake_minimum_required(VERSION 3.16.3)
project(example LANGUAGES CSharp) 

include(CSharpUtilities)
set(CMAKE_CSharp_FLAGS "/langversion:latest")

add_executable(main_example main_example.cs)
add_executable(basic_syntax basic_syntax.cs)
add_executable(hello_world hello_world.cs)

set_target_properties(example PROPERTIES
    LINKER_LANGUAGE CSharp
    VS_DOTNET_TARGET_FRAMEWORK_VERSION "v5.0"
    VS_DOTNET_REFERENCES
        "Microsoft.CSharp;
        System;
        System.Core;
        System.Data;
        System.Data.DataSetExtensions"
)