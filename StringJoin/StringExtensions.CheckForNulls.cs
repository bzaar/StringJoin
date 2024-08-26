using System;
using System.Collections.Generic;
using System.Linq;

namespace StringJoin;

public static partial class StringExtensions
{
    public static IEnumerable<string> CheckForNulls(this IEnumerable<string?> source) => 
        source.Select(s => s ?? throw new NullReferenceException("One of the strings is null."));
}