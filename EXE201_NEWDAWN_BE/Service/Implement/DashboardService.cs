using DTOS.Statistic;
using Service.Interface;

namespace Service.Implement
{
    public class DashboardService : IDashboardService
    {
        private readonly IPaymentTransactionService _transactionService;
        private readonly IPlantTrackingService _plantTrackingService;

        public DashboardService(IPaymentTransactionService transactionService, IPlantTrackingService plantTrackingService)
        {
            _transactionService = transactionService;
            _plantTrackingService = plantTrackingService;
        }

        public async Task<TotalStatistic> GetStatisticAsync()
        {
            var total = new TotalStatistic()
            {
                TotalProfit = await _transactionService.GetTotalProfit(),
                TotalPlant = await _plantTrackingService.GetTotalPlantWasPlanted()
            };
            return total;
        }
    }
}
