cmake_minimum_required(VERSION 3.21)
project(DatabaseAssignment C)

set(CMAKE_C_STANDARD 23)
add_subdirectory(SQLite)
add_executable(DatabaseAssignment main.c)
target_link_libraries(DatabaseAssignment PUBLIC SQLite)
target_include_directories(DatabaseAssignment PUBLIC
        "${PROJECT_BINARY_DIR}"
        "${PROJECT_SOURCE_DIR}/SQLite"
        )

