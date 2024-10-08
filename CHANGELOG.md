# Changelog

## [0.1.3] - 2024-09-18

### Added

- Implemented `IAdditiveIdentity<Vector…<TScalar>, Vector…<TScalar>>` by `Vector…<TScalar>`.
- XML-doc comments for public types

### Removed

- Removed multiply, divide and negate operators on `Point…<TScalar>` — there are no such operations in an affine space.

## [0.1.2-preview] - 2024-08-12

### Changed

- Fixed a bug in the subtraction of `Vector3<TScalar>`.

## [0.1.1-preview] - 2024-08-11

### Added

- `Vector3<TScalar>`, `Vector3`
- `Vector3Conversions<TTarget>`, `Vector3Conversions`
- `Point3<TScalar>`, `Point3`
- `Point3Conversions<TTarget>`, `Point3Conversions`

## [0.1.0-preview] - 2024-08-07

### Added

- `Vector2<TScalar>`, `Vector2`
- `Vector2Conversions<TTarget>`, `Vector2Conversions`
- `Point2<TScalar>`, `Point2`
- `Point2Conversions<TTarget>`, `Point2Conversions`

[Unreleased]: https://github.com/qbit86/euclidean-space/compare/euclidean-space-0.1.3...HEAD

[0.1.3]: https://github.com/qbit86/euclidean-space/compare/euclidean-space-0.1.2-preview...euclidean-space-0.1.3

[0.1.2-preview]: https://github.com/qbit86/euclidean-space/compare/euclidean-space-0.1.1-preview...euclidean-space-0.1.2-preview

[0.1.1-preview]: https://github.com/qbit86/euclidean-space/compare/euclidean-space-0.1.0-preview...euclidean-space-0.1.1-preview

[0.1.0-preview]: https://github.com/qbit86/euclidean-space/releases/tag/euclidean-space-0.1.0-preview
