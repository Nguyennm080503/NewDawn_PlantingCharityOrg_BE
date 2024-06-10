using BussinessObjects.Models;
using DTOS.Payment;
using DTOS.PaymentDetail;
using DTOS.PlantCode;
using HostelManagementWebAPI.MessageStatusResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Implement;
using Service.Interface;
using Service.Mail;

namespace EXE201_NEWDAWN_BE.Controllers.User
{
    [ApiController]
    public class PaymentController : BaseApiController
    {
        private readonly IPaymentTransactionDetailService _transactionDetailService;
        private readonly IPaymentTransactionService _transactionService;
        private readonly IPlantCodeService _plantCodeService;
        private readonly IPlantTrackingService _plantTrackingService;
        private readonly IMailService _mailService;
        private readonly IUserInformationService _userInformationService;
        private readonly IPayOSService _portalService;
        public PaymentController(IPaymentTransactionDetailService transactionDetailService, IPaymentTransactionService transactionService, IPlantCodeService plantCodeService, IPlantTrackingService plantTrackingService, IMailService mailService, IUserInformationService userInformationService, IPayOSService portalService)
        {
            _transactionDetailService = transactionDetailService;
            _transactionService = transactionService;
            _plantCodeService = plantCodeService;
            _plantTrackingService = plantTrackingService;
            _mailService = mailService;
            _userInformationService = userInformationService;
            _portalService = portalService;
        }

        [Authorize(policy: "Member")]
        [HttpPost("user/payment")]
        public async Task<ActionResult> PaymentTransactionProccess(PaymentCreate paymentCreate)
        {
            try
            {
                var transaction = await _portalService.HandleCodeAfterPaymentQR(paymentCreate.OrderID);
                PaymentTransaction payment = new PaymentTransaction();
                var listCode = new List<string>();
                payment.AccountBank = transaction.AccountNumber;
                payment.BankName = transaction.BankName;
                payment.BankCode = transaction.BankCode;
                payment.PaymentText = transaction.Description;
                payment.AccountID = paymentCreate.AccountID;
                payment.TotalAmout = transaction.Amount;
                payment.AccountName = transaction.AccountName;
                payment.DateCreate = transaction.TransactionDate;
                payment.TransactionCode = transaction.Reference;
                payment.Status = 0;
                var user = await _userInformationService.GetUserByAccount(paymentCreate.AccountID);
                try
                {
                    int paymentID = await _transactionService.CreatePaymentTransaction(payment);
                    if (paymentID != 0)
                    {
                        PaymentDetailCreate detailCreate = new PaymentDetailCreate();
                        detailCreate.PaymentID = paymentID;
                        detailCreate.Quantity = paymentCreate.Quantity;
                        detailCreate.TotalQuantity = transaction.Amount;

                        int detailID = await _transactionDetailService.CreatePaymentTransactionDetail(detailCreate);

                        if (detailID != 0)
                        {
                            for (int i = 0; i < paymentCreate.Quantity; i++)
                            {
                                PlantCodeCreate codeCreate = new PlantCodeCreate();
                                codeCreate.PaymentTransactionDetailID = detailID;
                                codeCreate.OwnerID = paymentCreate.AccountID;
                                string plantcode = await _plantCodeService.CreatePlantCodeFromOrder(codeCreate);
                                if (plantcode != null)
                                {
                                    listCode.Add(plantcode);
                                    await _plantTrackingService.CreateFirstTrackingPlantCode(plantcode);

                                }
                                else
                                {
                                    return BadRequest(new ApiResponseStatus(400, "Have some error when excute transaction."));
                                }
                            }
                            _mailService.SendMail(SendMailGeneration.SendMailGenerationPlantCode(user.Email, listCode));
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
                }
                catch (Exception ex)
                {
                    return BadRequest(new ApiResponseStatus(400, "Have some error when excute transaction."));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(policy: "Member")]
        [HttpGet("user/payment/all/{accountID}")]
        public async Task<IActionResult> GetAllTransactionOfMember(int accountID)
        {
            var transactions = await _transactionService.GetAllTransactionOfMember(accountID);
            if (transactions != null)
            {
                return Ok(transactions);
            }
            else
            {
                return BadRequest(new ApiResponseStatus(404, "No data"));
            }
        }

        [HttpGet("user/payment/test/{orderID}")]
        public async Task<IActionResult> Test(int orderID)
        {
            var transactions = await _portalService.getPaymentLinkInformation(orderID);
            if (transactions != null)
            {
                return Ok(transactions);
            }
            else
            {
                return BadRequest(new ApiResponseStatus(404, "No data"));
            }
        }

        [HttpGet("user/payment/test2/{orderID}")]
        public async Task<IActionResult> Test2(int orderID)
        {
            var transactions = await _portalService.paymentLinkResSignature(orderID);
            if (transactions != null)
            {
                return Ok(transactions);
            }
            else
            {
                return BadRequest(new ApiResponseStatus(404, "No data"));
            }
        }
    }
}
