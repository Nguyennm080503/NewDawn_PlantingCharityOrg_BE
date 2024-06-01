using AutoMapper;
using BussinessObjects.Models;
using DAO;
using DTOS.Enum;
using DTOS.PlantCode;
using Repository.Interface;
using System.Text.RegularExpressions;

namespace Repository.Implement
{
    public class PlantCodeRepository : IPlantCodeRepository
    {
        private readonly IMapper mapper;
        private static readonly object _lock = new object();

        public PlantCodeRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<string> CreatePlantCodeFromOrder(PlantCodeCreate plantCode)
        {
            var plantcode =  mapper.Map<PlantCode>(plantCode);
            plantcode.DateCreate = DateTime.Now;
            plantcode.Status = (int)TrackingEnum.Seed;
            plantcode.Provice = "TP.Hồ Chí Minh";
            plantcode.ProviceAddress = "Số 12, đường Hoàng Diệu, phường 13, Quận 9";
            plantcode.PlantCodeID = await GenerateNextCode();
            await PlantCodeDAO.Instance.CreateAsync(plantcode);

            return plantcode.PlantCodeID;
        }

        public async Task<IEnumerable<PlantCodeView>> GetAllPlantCodeOfUser(int accountid)
        {
            var plants = await PlantCodeDAO.Instance.GetAllPlantCodeOfUser(accountid);
            return mapper.Map<IEnumerable<PlantCodeView>>(plants);
        }

        public async Task<IEnumerable<AdminPlantCodeView>> GetAllPlantCodes()
        {
            var plants = await PlantCodeDAO.Instance.GetAllPlantCodes();
            return mapper.Map<IEnumerable<AdminPlantCodeView>>(plants);
        }

        public async Task<IEnumerable<Top6PlantCode>> Get6TheNewestPlantCode()
        {
            var plants = await PlantCodeDAO.Instance.Get6PlantCodes();
            return mapper.Map<IEnumerable<Top6PlantCode>>(plants);
        }

        public async Task<int> GetTotalPlantWasPlanted()
        {
            return await PlantCodeDAO.Instance.GetTotalPlantWasPlanted();
        }

        private async Task<string> GenerateNextCode()
        {
            lock (_lock)
            {
            var latestCodeTask = PlantCodeDAO.Instance.GetLatestPlantCode();
            latestCodeTask.Wait(); 
            string latestCode = latestCodeTask.Result;

                int currentValue = 0;

                if (!string.IsNullOrEmpty(latestCode))
                {
                    var match = Regex.Match(latestCode, @"NC-(\d+)");
                    if (match.Success)
                    {
                        currentValue = int.Parse(match.Groups[1].Value);
                    }
                }

                currentValue++;
                return $"NC-{currentValue:D4}";             
            }
        }

        public async Task<int> GetTotalPlantWasPlantedEachMonth()
        {
            DateTime datenow = DateTime.Now;
            int month = datenow.Month;
            int year = datenow.Year;
            return await PlantCodeDAO.Instance.GetTotalPlantWasPlantedEachMonth(month, year);
        }
    }
}
