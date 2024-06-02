using DTOS.Statistic;
using Repository.Interface;
using Service.Interface;

namespace Service.Implement
{
    public class DashboardService : IDashboardService
    {
        private readonly IPaymentTransactionRepository _paymentTransactionRepository;
        private readonly IPlantCodeRepository _plantCodeRepository;

        public DashboardService(IPaymentTransactionRepository transactionService, IPlantCodeRepository plantCodeRepository)
        {
            _paymentTransactionRepository = transactionService;
            _plantCodeRepository = plantCodeRepository;
        }

        public async Task<TotalStatistic> GetStatisticAsync()
        {
            var total = new TotalStatistic()
            {
                TotalProfit = await _paymentTransactionRepository.GetTotalProfit(),
                TotalPlant = await _plantCodeRepository.GetTotalPlantWasPlanted()
            };
            return total;
        }

        public async Task<TotalStatistic> GetStatisticEachMonthAsync()
        {
            var total = new TotalStatistic()
            {
                TotalProfit = await _paymentTransactionRepository.GetTotalProfitEachMonth(),
                TotalPlant = await _plantCodeRepository.GetTotalPlantWasPlantedEachMonth()
            };
            return total;
        }
    }
}
