using System.Globalization;
using System.Text.RegularExpressions;

namespace RentabilidadeCarteira.Services
{
    public static partial class Competencia
    {
        private static readonly Regex _formatRegex = new Regex(@"^\d{4}-(0[1-9]|1[0-2])$", RegexOptions.Compiled | RegexOptions.CultureInvariant);
        private static Regex FormatRegex() => _formatRegex;

        public static bool IsValid(string? competencia)
        {
            return !string.IsNullOrWhiteSpace(competencia) && FormatRegex().IsMatch(competencia);
        }

        public static int ToOrdinal(string competencia)
        {
            var year = int.Parse(competencia[..4], CultureInfo.InvariantCulture);
            var month = int.Parse(competencia[5..], CultureInfo.InvariantCulture);
            return (year * 12) + month;
        }

        public static IReadOnlyList<string> Range(string inicio, string fim)
        {
            var start = ToOrdinal(inicio);
            var end = ToOrdinal(fim);

            var result = new List<string>();
            for (var ordinal = start; ordinal <= end; ordinal++)
            {
                var year = (ordinal - 1) / 12;
                var month = ((ordinal - 1) % 12) + 1;
                result.Add($"{year:D4}-{month:D2}");
            }

            return result;
        }
    }
}
