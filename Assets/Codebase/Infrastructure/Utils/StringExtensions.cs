namespace Codebase.Infrastructure.Utils
{
    public static class StringExtensions
    {
        public static bool EnsureNotFreaked(this string value)
        {
            return string.IsNullOrEmpty(value)
                   || value.Contains("null")
                   || value.Contains("NaN");
        }
    }
}