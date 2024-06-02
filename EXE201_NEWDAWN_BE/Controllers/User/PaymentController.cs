using DTOS.Payment;
using DTOS.PaymentDetail;
using DTOS.PlantCode;
using HostelManagementWebAPI.MessageStatusResponse;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace EXE201_NEWDAWN_BE.Controllers.User
{
    [ApiController]
    public class PaymentController : BaseApiController
    {
        private readonly IPaymentTransactionDetailService _transactionDetailService;
        private readonly IPaymentTransactionService _transactionService;
        private readonly IPlantCodeService _plantCodeService;
        private readonly IPlantTrackingService _plantTrackingService;

        public PaymentController(IPaymentTransactionDetailService transactionDetailService, IPaymentTransactionService transactionService, IPlantCodeService plantCodeService, IPlantTrackingService plantTrackingService)
        {
            _transactionDetailService = transactionDetailService;
            _transactionService = transactionService;
            _plantCodeService = plantCodeService;
            _plantTrackingService = plantTrackingService;
        }

        [HttpPost("user/payment")]
        public async Task<ActionResult> PaymentTransactionProccess(ParamTransaction paramTransaction)
        {
            PaymentCreate paymentCreate = new PaymentCreate();
            paymentCreate.AccountBank = paramTransaction.AccountBank;
            paymentCreate.BankName = paramTransaction.BankName;
            paymentCreate.BankCode = paramTransaction.BankCode;
            paymentCreate.PaymentText = paramTransaction.PaymentText;
            paymentCreate.AccountID = paramTransaction.AccountID;
            paymentCreate.TotalAmout = paramTransaction.TotalAmout;

            try
            {
                int paymentID = await _transactionService.CreatePaymentTransaction(paymentCreate);
                if(paymentID != 0)
                {
                    PaymentDetailCreate detailCreate = new PaymentDetailCreate();
                    detailCreate.PaymentID = paymentID;
                    detailCreate.Quantity = paramTransaction.Quantity;
                    detailCreate.TotalQuantity = paramTransaction.TotalQuantity;

                    int detailID = await _transactionDetailService.CreatePaymentTransactionDetail(detailCreate);

                    if(detailID != 0)
                    {
                        for(int i = 0; i < paramTransaction.Quantity; i++)
                        {
                            PlantCodeCreate codeCreate = new PlantCodeCreate();
                            codeCreate.PaymentTransactionDetailID = detailID;
                            codeCreate.OwnerID = paramTransaction.AccountID;
                            string plantcode = await _plantCodeService.CreatePlantCodeFromOrder(codeCreate);
                            if (plantcode != null)
                            {
                                await _plantTrackingService.CreateFirstTrackingPlantCode(plantcode);

                            }
                            else
                            {
                                return BadRequest(new ApiResponseStatus(400, "Have some error when excute transaction."));
                            }
                        }

                        return Ok();
                    }
                    else
                    {
                        return BadRequest(new ApiResponseStatus(400, "Have some error when excute transaction."));
                    }
                }
                else
                {
                    return BadRequest(new ApiResponseStatus(400, "Have some error when excute transaction."));
                }
            }catch (Exception ex)
            {
                return BadRequest(new ApiResponseStatus(400, "Have some error when excute transaction."));
            }
        }
    }
}
