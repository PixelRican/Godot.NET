# Godot.NET

An experimental repository containing C# bindings for GDExtension development.

## Overview

This experimental repository contains C# bindings for [GDExtension](https://docs.godotengine.org/en/stable/tutorials/scripting/gdextension/what_is_gdextension.html), a [Godot Engine](https://godotengine.org/) technology that allows it to interact with native shared libraries at runtime. The main purpose of this repository is to experiment with GDExtension features using C#. This repository should not be confused for [Godot .NET](https://github.com/godotengine/godot-dotnet), the official repository containing .NET bindings for Godot using the GDExtension APIs. The official repository provides a much more comprehensive C# API than what is provided by this repository, so it is highly recommended that C# developers use it instead.

## Executing Tests

C# projects that test the library's functionality can be found in the Tests folder. These projects must be built as a native shared library using [Native AOT](https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/), which allows Godot to load them as GDExtensions. GDExtension tests are conducted through a Godot project residing in the Tests/Godot.Tests/Project folder, which contains configurations for loading the native shared library. Once built, the native shared library must be placed in the Tests/Godot.Tests/Project/bin folder so that the Godot project can locate and load it. Once everything is set up, open the project file in the Godot Engine and run it to confirm that it has properly loaded the GDExample class.

## Generating Bindings

The bindings included in the library were generated using the Python scripts in the Scripts folder. To regenerate the bindings, execute the Scripts/bindings_generator.py file using a Python interpreter, preferably version 3.13 or above. Note that the gdextension_interface.json file must be in the Scripts folder as well in order for bindings generation to work.

## Prerequisites

* .NET 10 SDK with Native AOT build tools
* Godot 4.2 or above

## License

Godot.NET is released under the MIT License. See LICENSE for details.
