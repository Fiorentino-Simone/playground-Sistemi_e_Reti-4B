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
CMAKE_SOURCE_DIR = "G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese07_Media 3 Numeri"

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = "G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese07_Media 3 Numeri\cmake-build-debug"

# Include any dependencies generated for this target.
include CMakeFiles\Ese07_Media_3_Numeri.dir\depend.make
# Include the progress variables for this target.
include CMakeFiles\Ese07_Media_3_Numeri.dir\progress.make

# Include the compile flags for this target's objects.
include CMakeFiles\Ese07_Media_3_Numeri.dir\flags.make

CMakeFiles\Ese07_Media_3_Numeri.dir\main.c.obj: CMakeFiles\Ese07_Media_3_Numeri.dir\flags.make
CMakeFiles\Ese07_Media_3_Numeri.dir\main.c.obj: ..\main.c
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir="G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese07_Media 3 Numeri\cmake-build-debug\CMakeFiles" --progress-num=$(CMAKE_PROGRESS_1) "Building C object CMakeFiles/Ese07_Media_3_Numeri.dir/main.c.obj"
	C:\PROGRA~2\MIB055~1\2019\COMMUN~1\VC\Tools\MSVC\1429~1.301\bin\Hostx86\x86\cl.exe @<<
 /nologo $(C_DEFINES) $(C_INCLUDES) $(C_FLAGS) /FoCMakeFiles\Ese07_Media_3_Numeri.dir\main.c.obj /FdCMakeFiles\Ese07_Media_3_Numeri.dir\ /FS -c "G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese07_Media 3 Numeri\main.c"
<<

CMakeFiles\Ese07_Media_3_Numeri.dir\main.c.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing C source to CMakeFiles/Ese07_Media_3_Numeri.dir/main.c.i"
	C:\PROGRA~2\MIB055~1\2019\COMMUN~1\VC\Tools\MSVC\1429~1.301\bin\Hostx86\x86\cl.exe > CMakeFiles\Ese07_Media_3_Numeri.dir\main.c.i @<<
 /nologo $(C_DEFINES) $(C_INCLUDES) $(C_FLAGS) -E "G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese07_Media 3 Numeri\main.c"
<<

CMakeFiles\Ese07_Media_3_Numeri.dir\main.c.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling C source to assembly CMakeFiles/Ese07_Media_3_Numeri.dir/main.c.s"
	C:\PROGRA~2\MIB055~1\2019\COMMUN~1\VC\Tools\MSVC\1429~1.301\bin\Hostx86\x86\cl.exe @<<
 /nologo $(C_DEFINES) $(C_INCLUDES) $(C_FLAGS) /FoNUL /FAs /FaCMakeFiles\Ese07_Media_3_Numeri.dir\main.c.s /c "G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese07_Media 3 Numeri\main.c"
<<

# Object files for target Ese07_Media_3_Numeri
Ese07_Media_3_Numeri_OBJECTS = \
"CMakeFiles\Ese07_Media_3_Numeri.dir\main.c.obj"

# External object files for target Ese07_Media_3_Numeri
Ese07_Media_3_Numeri_EXTERNAL_OBJECTS =

Ese07_Media_3_Numeri.exe: CMakeFiles\Ese07_Media_3_Numeri.dir\main.c.obj
Ese07_Media_3_Numeri.exe: CMakeFiles\Ese07_Media_3_Numeri.dir\build.make
Ese07_Media_3_Numeri.exe: CMakeFiles\Ese07_Media_3_Numeri.dir\objects1.rsp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir="G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese07_Media 3 Numeri\cmake-build-debug\CMakeFiles" --progress-num=$(CMAKE_PROGRESS_2) "Linking C executable Ese07_Media_3_Numeri.exe"
	"C:\Program Files\JetBrains\CLion 2020.3.3\bin\cmake\win\bin\cmake.exe" -E vs_link_exe --intdir=CMakeFiles\Ese07_Media_3_Numeri.dir --rc=C:\PROGRA~2\WI3CF2~1\10\bin\100190~1.0\x86\rc.exe --mt=C:\PROGRA~2\WI3CF2~1\10\bin\100190~1.0\x86\mt.exe --manifests -- C:\PROGRA~2\MIB055~1\2019\COMMUN~1\VC\Tools\MSVC\1429~1.301\bin\Hostx86\x86\link.exe /nologo @CMakeFiles\Ese07_Media_3_Numeri.dir\objects1.rsp @<<
 /out:Ese07_Media_3_Numeri.exe /implib:Ese07_Media_3_Numeri.lib /pdb:"G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese07_Media 3 Numeri\cmake-build-debug\Ese07_Media_3_Numeri.pdb" /version:0.0 /machine:X86 /debug /INCREMENTAL /subsystem:console  kernel32.lib user32.lib gdi32.lib winspool.lib shell32.lib ole32.lib oleaut32.lib uuid.lib comdlg32.lib advapi32.lib 
<<

# Rule to build all files generated by this target.
CMakeFiles\Ese07_Media_3_Numeri.dir\build: Ese07_Media_3_Numeri.exe
.PHONY : CMakeFiles\Ese07_Media_3_Numeri.dir\build

CMakeFiles\Ese07_Media_3_Numeri.dir\clean:
	$(CMAKE_COMMAND) -P CMakeFiles\Ese07_Media_3_Numeri.dir\cmake_clean.cmake
.PHONY : CMakeFiles\Ese07_Media_3_Numeri.dir\clean

CMakeFiles\Ese07_Media_3_Numeri.dir\depend:
	$(CMAKE_COMMAND) -E cmake_depends "NMake Makefiles" "G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese07_Media 3 Numeri" "G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese07_Media 3 Numeri" "G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese07_Media 3 Numeri\cmake-build-debug" "G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese07_Media 3 Numeri\cmake-build-debug" "G:\SUPERIORI\4_SUPERIORE\SISTEMI E RETI\Ese07_Media 3 Numeri\cmake-build-debug\CMakeFiles\Ese07_Media_3_Numeri.dir\DependInfo.cmake" --color=$(COLOR)
.PHONY : CMakeFiles\Ese07_Media_3_Numeri.dir\depend

