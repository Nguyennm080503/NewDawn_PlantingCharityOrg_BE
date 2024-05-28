using Repository.Implement;
using Repository.Interface;
using Service.Implement;
using Service.Interface;
using Service.Mail;

namespace EXE201_NEWDAWN_BE.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services
        , IConfiguration config)
        {
            services.Configure<MailSetting>(config.GetSection("MailSetting"));
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserInformationRepository, UserInformationRepository>();
            services.AddScoped<IPostingNewsRepository, PostingNewsRepository>();
            services.AddScoped<IPlantTrackingRepository, PlantTrackingRepository>();
            services.AddScoped<IPlantCodeRepository, PlantCodeRepository>();
            services.AddScoped<IPaymentTransactionRepository, PaymentTransactionRepository>();
            services.AddScoped<IPaymentTransactionDetailRepository, PaymentTransactionDetailRepository>();
            services.AddScoped<IImageDetailRepository, ImageDetailRepository>();

            services.AddScoped<IUserInformationService, UserInformationService>();
            services.AddScoped<IPostingNewsService, PostingNewsService>();
            services.AddScoped<IPlantTrackingService, PlantTrackingService>();
            services.AddScoped<IPlantCodeService, PlantCodeService>();
            services.AddScoped<IPaymentTransactionService, PaymentTransactionService>();
            services.AddScoped<IPaymentTransactionDetailService, PaymentTransactionDetailService>();
            services.AddScoped<IImageDetailService, ImageDetailService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //the current position of the mapping profile

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy => { policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
            });

            return services;
        }
    }
}
