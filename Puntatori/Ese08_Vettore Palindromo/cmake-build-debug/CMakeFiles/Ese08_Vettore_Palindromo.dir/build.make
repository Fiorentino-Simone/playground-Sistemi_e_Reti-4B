# CMAKE generated file: DO NOT EDIT!
# Generated by "NMake Makefiles" Generator, CMake Version 3.20

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:

#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:

.SUFFIXES: .hpux_make_needs_suffix_list

# Command-line flag to silence nested $(MAKE).
$(VERBOSE)MAKESILENT = -s

#Suppress display of executed commands.
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
CMAKE_COMMAND = "C:\Program Files\JetBrains\CLion 2020.3.3\bin\cmake\win\bin\cmake.exe"

# The command to remove a file.
RM = "C:\Program Files\JetBrains\CLion 2020.3.3\bin\cmake\win\bin\cmake.exe" -E rm -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = "G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese08_Vettore Palindromo"

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = "G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese08_Vettore Palindromo\cmake-build-debug"

# Include any dependencies generated for this target.
include CMakeFiles\Ese08_Vettore_Palindromo.dir\depend.make
# Include the progress variables for this target.
include CMakeFiles\Ese08_Vettore_Palindromo.dir\progress.make

# Include the compile flags for this target's objects.
include CMakeFiles\Ese08_Vettore_Palindromo.dir\flags.make

CMakeFiles\Ese08_Vettore_Palindromo.dir\main.c.obj: CMakeFiles\Ese08_Vettore_Palindromo.dir\flags.make
CMakeFiles\Ese08_Vettore_Palindromo.dir\main.c.obj: ..\main.c
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir="G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese08_Vettore Palindromo\cmake-build-debug\CMakeFiles" --progress-num=$(CMAKE_PROGRESS_1) "Building C object CMakeFiles/Ese08_Vettore_Palindromo.dir/main.c.obj"
	C:\PROGRA~2\MIB055~1\2019\COMMUN~1\VC\Tools\MSVC\1429~1.301\bin\Hostx86\x86\cl.exe @<<
 /nologo $(C_DEFINES) $(C_INCLUDES) $(C_FLAGS) /FoCMakeFiles\Ese08_Vettore_Palindromo.dir\main.c.obj /FdCMakeFiles\Ese08_Vettore_Palindromo.dir\ /FS -c "G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese08_Vettore Palindromo\main.c"
<<

CMakeFiles\Ese08_Vettore_Palindromo.dir\main.c.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing C source to CMakeFiles/Ese08_Vettore_Palindromo.dir/main.c.i"
	C:\PROGRA~2\MIB055~1\2019\COMMUN~1\VC\Tools\MSVC\1429~1.301\bin\Hostx86\x86\cl.exe > CMakeFiles\Ese08_Vettore_Palindromo.dir\main.c.i @<<
 /nologo $(C_DEFINES) $(C_INCLUDES) $(C_FLAGS) -E "G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese08_Vettore Palindromo\main.c"
<<

CMakeFiles\Ese08_Vettore_Palindromo.dir\main.c.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling C source to assembly CMakeFiles/Ese08_Vettore_Palindromo.dir/main.c.s"
	C:\PROGRA~2\MIB055~1\2019\COMMUN~1\VC\Tools\MSVC\1429~1.301\bin\Hostx86\x86\cl.exe @<<
 /nologo $(C_DEFINES) $(C_INCLUDES) $(C_FLAGS) /FoNUL /FAs /FaCMakeFiles\Ese08_Vettore_Palindromo.dir\main.c.s /c "G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese08_Vettore Palindromo\main.c"
<<

# Object files for target Ese08_Vettore_Palindromo
Ese08_Vettore_Palindromo_OBJECTS = \
"CMakeFiles\Ese08_Vettore_Palindromo.dir\main.c.obj"

# External object files for target Ese08_Vettore_Palindromo
Ese08_Vettore_Palindromo_EXTERNAL_OBJECTS =

Ese08_Vettore_Palindromo.exe: CMakeFiles\Ese08_Vettore_Palindromo.dir\main.c.obj
Ese08_Vettore_Palindromo.exe: CMakeFiles\Ese08_Vettore_Palindromo.dir\build.make
Ese08_Vettore_Palindromo.exe: CMakeFiles\Ese08_Vettore_Palindromo.dir\objects1.rsp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir="G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese08_Vettore Palindromo\cmake-build-debug\CMakeFiles" --progress-num=$(CMAKE_PROGRESS_2) "Linking C executable Ese08_Vettore_Palindromo.exe"
	"C:\Program Files\JetBrains\CLion 2020.3.3\bin\cmake\win\bin\cmake.exe" -E vs_link_exe --intdir=CMakeFiles\Ese08_Vettore_Palindromo.dir --rc=C:\PROGRA~2\WI3CF2~1\10\bin\100190~1.0\x86\rc.exe --mt=C:\PROGRA~2\WI3CF2~1\10\bin\100190~1.0\x86\mt.exe --manifests -- C:\PROGRA~2\MIB055~1\2019\COMMUN~1\VC\Tools\MSVC\1429~1.301\bin\Hostx86\x86\link.exe /nologo @CMakeFiles\Ese08_Vettore_Palindromo.dir\objects1.rsp @<<
 /out:Ese08_Vettore_Palindromo.exe /implib:Ese08_Vettore_Palindromo.lib /pdb:"G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese08_Vettore Palindromo\cmake-build-debug\Ese08_Vettore_Palindromo.pdb" /version:0.0 /machine:X86 /debug /INCREMENTAL /subsystem:console  kernel32.lib user32.lib gdi32.lib winspool.lib shell32.lib ole32.lib oleaut32.lib uuid.lib comdlg32.lib advapi32.lib 
<<

# Rule to build all files generated by this target.
CMakeFiles\Ese08_Vettore_Palindromo.dir\build: Ese08_Vettore_Palindromo.exe
.PHONY : CMakeFiles\Ese08_Vettore_Palindromo.dir\build

CMakeFiles\Ese08_Vettore_Palindromo.dir\clean:
	$(CMAKE_COMMAND) -P CMakeFiles\Ese08_Vettore_Palindromo.dir\cmake_clean.cmake
.PHONY : CMakeFiles\Ese08_Vettore_Palindromo.dir\clean

CMakeFiles\Ese08_Vettore_Palindromo.dir\depend:
	$(CMAKE_COMMAND) -E cmake_depends "NMake Makefiles" "G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese08_Vettore Palindromo" "G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese08_Vettore Palindromo" "G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese08_Vettore Palindromo\cmake-build-debug" "G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese08_Vettore Palindromo\cmake-build-debug" "G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese08_Vettore Palindromo\cmake-build-debug\CMakeFiles\Ese08_Vettore_Palindromo.dir\DependInfo.cmake" --color=$(COLOR)
.PHONY : CMakeFiles\Ese08_Vettore_Palindromo.dir\depend
