# CMAKE generated file: DO NOT EDIT!
# Generated by "NMake Makefiles" Generator, CMake Version 3.15

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:


#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:


.SUFFIXES: .hpux_make_needs_suffix_list


# Suppress display of executed commands.
$(VERBOSE).SILENT:


# A target that is always out of date.
cmake_force:

.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

!IF "$(OS)" == "Windows_NT"
NULL=
!ELSE
NULL=nul
!ENDIF
SHELL = cmd.exe

# The CMake executable.
CMAKE_COMMAND = "C:\Program Files\JetBrains\CLion 2019.2.2\bin\cmake\win\bin\cmake.exe"

# The command to remove a file.
RM = "C:\Program Files\JetBrains\CLion 2019.2.2\bin\cmake\win\bin\cmake.exe" -E remove -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = "D:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese05_Es Copia Stringa"

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = "D:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese05_Es Copia Stringa\cmake-build-debug"

# Include any dependencies generated for this target.
include CMakeFiles\Ese05_Es_Copia_Stringa.dir\depend.make

# Include the progress variables for this target.
include CMakeFiles\Ese05_Es_Copia_Stringa.dir\progress.make

# Include the compile flags for this target's objects.
include CMakeFiles\Ese05_Es_Copia_Stringa.dir\flags.make

CMakeFiles\Ese05_Es_Copia_Stringa.dir\main.c.obj: CMakeFiles\Ese05_Es_Copia_Stringa.dir\flags.make
CMakeFiles\Ese05_Es_Copia_Stringa.dir\main.c.obj: ..\main.c
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir="D:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese05_Es Copia Stringa\cmake-build-debug\CMakeFiles" --progress-num=$(CMAKE_PROGRESS_1) "Building C object CMakeFiles/Ese05_Es_Copia_Stringa.dir/main.c.obj"
	C:\PROGRA~2\MICROS~1\2019\ENTERP~1\VC\Tools\MSVC\1423~1.281\bin\Hostx86\x86\cl.exe @<<
 /nologo $(C_DEFINES) $(C_INCLUDES) $(C_FLAGS) /FoCMakeFiles\Ese05_Es_Copia_Stringa.dir\main.c.obj /FdCMakeFiles\Ese05_Es_Copia_Stringa.dir\ /FS -c "D:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese05_Es Copia Stringa\main.c"
<<

CMakeFiles\Ese05_Es_Copia_Stringa.dir\main.c.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing C source to CMakeFiles/Ese05_Es_Copia_Stringa.dir/main.c.i"
	C:\PROGRA~2\MICROS~1\2019\ENTERP~1\VC\Tools\MSVC\1423~1.281\bin\Hostx86\x86\cl.exe > CMakeFiles\Ese05_Es_Copia_Stringa.dir\main.c.i @<<
 /nologo $(C_DEFINES) $(C_INCLUDES) $(C_FLAGS) -E "D:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese05_Es Copia Stringa\main.c"
<<

CMakeFiles\Ese05_Es_Copia_Stringa.dir\main.c.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling C source to assembly CMakeFiles/Ese05_Es_Copia_Stringa.dir/main.c.s"
	C:\PROGRA~2\MICROS~1\2019\ENTERP~1\VC\Tools\MSVC\1423~1.281\bin\Hostx86\x86\cl.exe @<<
 /nologo $(C_DEFINES) $(C_INCLUDES) $(C_FLAGS) /FoNUL /FAs /FaCMakeFiles\Ese05_Es_Copia_Stringa.dir\main.c.s /c "D:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese05_Es Copia Stringa\main.c"
<<

# Object files for target Ese05_Es_Copia_Stringa
Ese05_Es_Copia_Stringa_OBJECTS = \
"CMakeFiles\Ese05_Es_Copia_Stringa.dir\main.c.obj"

# External object files for target Ese05_Es_Copia_Stringa
Ese05_Es_Copia_Stringa_EXTERNAL_OBJECTS =

Ese05_Es_Copia_Stringa.exe: CMakeFiles\Ese05_Es_Copia_Stringa.dir\main.c.obj
Ese05_Es_Copia_Stringa.exe: CMakeFiles\Ese05_Es_Copia_Stringa.dir\build.make
Ese05_Es_Copia_Stringa.exe: CMakeFiles\Ese05_Es_Copia_Stringa.dir\objects1.rsp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir="D:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese05_Es Copia Stringa\cmake-build-debug\CMakeFiles" --progress-num=$(CMAKE_PROGRESS_2) "Linking C executable Ese05_Es_Copia_Stringa.exe"
	"C:\Program Files\JetBrains\CLion 2019.2.2\bin\cmake\win\bin\cmake.exe" -E vs_link_exe --intdir=CMakeFiles\Ese05_Es_Copia_Stringa.dir --rc=C:\PROGRA~2\WI3CF2~1\10\bin\100183~1.0\x86\rc.exe --mt=C:\PROGRA~2\WI3CF2~1\10\bin\100183~1.0\x86\mt.exe --manifests  -- C:\PROGRA~2\MICROS~1\2019\ENTERP~1\VC\Tools\MSVC\1423~1.281\bin\Hostx86\x86\link.exe /nologo @CMakeFiles\Ese05_Es_Copia_Stringa.dir\objects1.rsp @<<
 /out:Ese05_Es_Copia_Stringa.exe /implib:Ese05_Es_Copia_Stringa.lib /pdb:"D:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese05_Es Copia Stringa\cmake-build-debug\Ese05_Es_Copia_Stringa.pdb" /version:0.0  /machine:X86 /debug /INCREMENTAL /subsystem:console kernel32.lib user32.lib gdi32.lib winspool.lib shell32.lib ole32.lib oleaut32.lib uuid.lib comdlg32.lib advapi32.lib 
<<

# Rule to build all files generated by this target.
CMakeFiles\Ese05_Es_Copia_Stringa.dir\build: Ese05_Es_Copia_Stringa.exe

.PHONY : CMakeFiles\Ese05_Es_Copia_Stringa.dir\build

CMakeFiles\Ese05_Es_Copia_Stringa.dir\clean:
	$(CMAKE_COMMAND) -P CMakeFiles\Ese05_Es_Copia_Stringa.dir\cmake_clean.cmake
.PHONY : CMakeFiles\Ese05_Es_Copia_Stringa.dir\clean

CMakeFiles\Ese05_Es_Copia_Stringa.dir\depend:
	$(CMAKE_COMMAND) -E cmake_depends "NMake Makefiles" "D:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese05_Es Copia Stringa" "D:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese05_Es Copia Stringa" "D:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese05_Es Copia Stringa\cmake-build-debug" "D:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese05_Es Copia Stringa\cmake-build-debug" "D:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese05_Es Copia Stringa\cmake-build-debug\CMakeFiles\Ese05_Es_Copia_Stringa.dir\DependInfo.cmake" --color=$(COLOR)
.PHONY : CMakeFiles\Ese05_Es_Copia_Stringa.dir\depend
