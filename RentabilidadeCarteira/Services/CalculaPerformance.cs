namespace RentabilidadeCarteira.Services
{
    public class CalculaPerformance
    {
        public static decimal PercentualAcumulado(IEnumerable<decimal> monthlyPercents)
        {
            var factor = 1m;
            foreach (var monthly in monthlyPercents)
                factor *= 1m + (monthly / 100m);

            return (factor - 1m) * 100m;
        }

        public static decimal Alpha(decimal carteiraAccumulatedPercent, decimal benchmarkAccumulatedPercent)
        {
            return carteiraAccumulatedPercent - benchmarkAccumulatedPercent;
        }
    }
}
