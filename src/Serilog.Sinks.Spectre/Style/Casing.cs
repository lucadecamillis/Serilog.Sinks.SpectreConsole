namespace Serilog.Sinks.Spectre.Style;

internal static class Casing
{
    /// <summary>
    /// Apply upper or lower casing to <paramref name="value" />
    /// when <paramref name="format" /> is provided.
    /// Returns <paramref name="value" /> when no or invalid format provided
    /// </summary>
    /// <returns>The provided <paramref name="value" /> with formatting applied</returns>
    public static string Format(string value, string format = null)
    {
        return format switch
        {
            "u" => value.ToUpperInvariant(),
            "w" => value.ToLowerInvariant(),
            _   => value
        };
    }
}