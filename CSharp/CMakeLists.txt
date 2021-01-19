cmake_minimum_required(VERSION 3.9)

project(CSharp)

set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin)
set(CMAKE_ARCHIVE_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin)
set(CMAKE_LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin)

add_subdirectory(main_example)
add_subdirectory(basic_syntax)
add_subdirectory(hello_world)
add_subdirectory(type_conversion)