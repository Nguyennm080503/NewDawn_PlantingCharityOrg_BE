using DTOS.Statistic;

namespace Service.Interface
{
    public interface IDashboardService
    {
        Task<TotalStatistic> GetStatisticAsync();
    }
}
