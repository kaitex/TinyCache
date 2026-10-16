## TinyCache

A simple in-memory caching library built from scratch with C# and .NET 10 as a learning project.

## Features

- `Set` — Add or update a key-value pair.
- `TryGet` — Retrieve a value by key.
- `Remove` — Remove an entry by key.
- Thread-safe storage using `ConcurrentDictionary`.

## Usage

```csharp
var cache = new CacheMem();

cache.Set(1, "RAM");

if (cache.TryGet(1, out var value))
{
    Console.WriteLine(value); // RAM
}

cache.Remove(1);
```

## Technologies

- C#
- .NET 10
- ConcurrentDictionary

## Purpose

This project is built to improve my C# skills and explore .NET library design, generics, thread safety, and software architecture.

## Status

Early development. More features and tests will be added over time.

## License

Not specified yet.