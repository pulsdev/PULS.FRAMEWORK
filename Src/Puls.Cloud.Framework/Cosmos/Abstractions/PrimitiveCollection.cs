using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Puls.Cloud.Framework.Domain;

namespace Puls.Cloud.Framework.Cosmos.Abstractions;

[JsonConverter(typeof(PrimitiveCollectionConverter<>))]
public class PrimitiveCollection<T>
{
    public ArraySegment<T> Items { get; private init; }

    public PrimitiveCollection(IEnumerable<T> iItems)
    {
        Items = iItems.ToArray();
    }
}