using System;
using System.Collections.Generic;

namespace StringJoin;

public static partial class StringExtensions
{
    /// <summary>
    /// Joins strings into one string, adding delimiters in between the strings.
    /// </summary>
    /// <exception cref="ArgumentNullException">If either parameter is null.</exception>
    public static string Join(this IEnumerable<string> strings, string delimiter) =>
        string.Join(delimiter ?? throw new ArgumentNullException(nameof(delimiter)), strings);
}