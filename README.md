# Godot.NET

C# bindings for GDExtension development.

## Overview

Godot.NET is a code library that provides C# bindings for [GDExtension]("https://docs.godotengine.org/en/stable/tutorials/scripting/gdextension/what_is_gdextension.html"), a [Godot Engine]("https://godotengine.org/") technology that allows it to interact with native shared libraries at runtime. This library ports every GDExtension type as C# structs and enums, minimizing friction between managed and unmanaged code. In addition, the library contains the GDExtensionInterface static class, which can load and store pointers to all of the functions provided by the GDExtension interface upon initialization. The names of every struct and enum member were modified to fit the C# naming conventions.

## Executing Tests

C# projects that test the library's functionality can be found in the Tests folder. These projects must be built as a native shared library using [Native AOT]("https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/"), which allows Godot to load them as GDExtensions. GDExtension tests are conducted through a Godot project residing in the GDExtension.Tests/Project folder, which contains configurations for loading the native shared library. Once built, the native shared library must be placed in the Project/bin folder so that the Godot project can locate and load it. Once everything is set up, open the project file in the Godot Engine and run it to confirm that it has properly loaded the GDExample class.

## Generating Bindings

The bindings included in the library were generated using the Python scripts in the Scripts folder. To regenerate the bindings, execute the codegen.py file using a Python interpreter, preferably version 3.13 or above. Note that the gdextension_interface.json file must be in the same directory as codegen.py in order for bindings generation to work.

## Prerequisites

* .NET 10 SDK with Native AOT build tools
* Godot 4.6 or above

## License

Godot.NET is released under the MIT License. See LICENSE for details.
