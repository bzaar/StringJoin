using System;
using System.Collections.Generic;

namespace StringJoin;

public static class EnumerableStringExtensions
{
    /// <summary>
    /// Joins strings into one string, inserting delimiters in between the strings.
    /// </summary>
    /// <param name="strings">
    /// Null strings are treated as empty strings.
    /// </param>
    /// <param name="delimiter">
    /// Cannot be null.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// If any arguments are null.
    /// </exception>
    public static string Join(this IEnumerable<string> strings, string delimiter) =>
        string.Join(delimiter ?? throw new ArgumentNullException(nameof(delimiter)), strings);

    /// <inheritdoc cref="Join(System.Collections.Generic.IEnumerable{string},string)"/>
    public static string Join(this IEnumerable<string> strings, char delimiter) =>
        string.Join(delimiter.ToString(), strings);
}
