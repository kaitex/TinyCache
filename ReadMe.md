# TinyCache

A simple in-memory caching library built from scratch with C# and .NET 10 as a learning project.

## Features

- `Set` — Add or update a key-value pair.
- `TryAdd` — Add a key-value pair only if the key doesn't already exist.
- `TryGet` — Retrieve a value by key and indicate whether it exists.
- `GetOrAdd` — Retrieve an existing value or add a new one.
- `GetOrDefault` — Retrieve a value or return `null` if the key doesn't exist.
- `Remove` — Remove an entry by key.
- `ContainsKey` — Check whether a key exists.
- `GetAll` — Retrieve all cache entries as an array snapshot.
- `TryUpdate` — Update a value only if the existing value matches the expected old value.
- `Clear` — Remove all entries.
- Thread-safe storage using `ConcurrentDictionary`.

## Usage

```csharp
using TinyCache;

var cache = new CacheMem();

// Add or update a value
cache.Set(1, "RAM");

// Retrieve a value
if (cache.TryGet(1, out var value))
{
    Console.WriteLine(value); // RAM
}

// Add only if the key doesn't exist
bool added = cache.TryAdd(2, "CPU");

// Get an existing value or add a new one
string result = cache.GetOrAdd(3, "GPU");

// Check whether a key exists
bool exists = cache.ContainsKey(1);

// Get all entries
foreach (var entry in cache.GetAll())
{
    Console.WriteLine($"{entry.Key}: {entry.Value}");
}

// Remove an entry
cache.Remove(1);

// Clear the cache
cache.Clear();
```

## Testing

TinyCache uses **xUnit** for unit testing.

Run the tests from the solution directory:

```bash
dotnet test
```

The tests cover basic cache operations, including adding, retrieving, updating, removing, and clearing entries, as well as behavior for missing and duplicate keys.

## Technologies

- C#
- .NET 10
- `ConcurrentDictionary<TKey, TValue>`
- xUnit

## Purpose

This project is built to improve my C# skills and explore:

- .NET library design
- Generics and interfaces
- Thread-safe collections
- Unit testing with xUnit
- Backend development and software architecture

## Status

Early development. The core cache operations and initial unit tests are being implemented. More features and tests will be added over time.

## License

No license has been selected yet.
