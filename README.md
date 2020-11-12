# CodeFactory.Markup.Adapter
Adapter pattern used for conversion of markup base content in code factory conversions.  The final output is published as a Nuget Package which makes available the adapter pattern interfaces and base classes to implementing authors.

## New to CodeFactory?
In the simplest terms, CodeFactory is a real time software factory that is triggered from inside Visual Studio during the design and construction of software. CodeFactory allows for development staff to automate repetitive development tasks that take up developer’s time.

Please see the following link for further information and guidance about the [CodeFactory Runtime](https://github.com/CodeFactoryLLC/CodeFactory) or the [CodeFactory SDK](https://www.nuget.org/packages/CodeFactorySDK/).

## Core purpose of the project
This project holds a Interface definitions, base classes and return types defined.  Collectively they all make up an Adapter Pattern implementation meant specifically to address the need of anyone who might be needing to convert one markup language to another.
  - AdapterHost definition
  - BaseTagAdapter definition
  - Conversion Result Type definition
  - IAdapterHost interface definition
  - ITagAdapter interface definition


## Known Limitations of this project
- There is currently only one example/reference project that uses this pattern to implement a .NET Web Forms to Blazor migration.
