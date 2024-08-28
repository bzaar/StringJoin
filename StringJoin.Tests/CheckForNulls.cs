namespace StringJoin.Tests;

public static class EnumerableNullableStringExtensions
{
    public static IEnumerable<string> CheckForNulls(this IEnumerable<string?> source) => 
        source.Select(s => s ?? throw new NullReferenceException("One of the strings is null."));
}