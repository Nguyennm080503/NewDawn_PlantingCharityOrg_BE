using DTOS;
using Net.payOS.Types;


namespace Service.Interface
{
    public interface IPayOSService
    {
        Task<string> CreatePaymentLink(int quantity);
    }
}
