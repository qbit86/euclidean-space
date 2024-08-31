# EuclideanSpace

[![EuclideanSpace version](https://img.shields.io/nuget/v/EuclideanSpace.svg?label=EuclideanSpace&logo=nuget)](https://nuget.org/packages/EuclideanSpace/)

EuclideanSpace is a generic .NET library of primitive types for Euclidean vector and affine spaces[^WES].
It mostly follows the design of the types in the `System.Numerics` namespace[^SN], and utilizes the “generic math”[^GM] interfaces introduced in .NET 7.

Commonly used types:

- `Point2<TScalar>`
- `Point3<TScalar>`
- `Vector2<TScalar>`
- `Vector3<TScalar>`

## License

![License](https://img.shields.io/github/license/qbit86/euclidean-space)

The icon is designed by [OpenMoji](https://openmoji.org) — the open-source emoji and icon project.
License: [CC BY-SA 4.0](https://creativecommons.org/licenses/by-sa/4.0/).

[^GM]: Generic math  
https://learn.microsoft.com/en-us/dotnet/standard/generics/math

[^SN]: System.Numerics Namespace  
https://learn.microsoft.com/en-us/dotnet/api/system.numerics

[^WES]: Affine space  
https://en.wikipedia.org/wiki/Affine_space
