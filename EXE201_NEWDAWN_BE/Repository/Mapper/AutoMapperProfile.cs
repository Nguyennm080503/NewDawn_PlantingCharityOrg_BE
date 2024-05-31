using AutoMapper;
using BussinessObjects.Models;
using DTOS.ImageTracking;
using DTOS.Login;
using DTOS.News;
using DTOS.Payment;
using DTOS.PaymentDetail;
using DTOS.PlantCode;
using DTOS.PlantTracking;
using DTOS.PostingDetail;

namespace Repository.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<UserInformation, UserDto>().ReverseMap();
            CreateMap<PostingNews, NewsMonthView>().ReverseMap();
            CreateMap<PlantCode, PlantCodeView>().ReverseMap();
            CreateMap<PlantCodeCreate, PlantCode>().ReverseMap();
            CreateMap<ImageDetail, ImageDetailView>().ReverseMap();
            CreateMap<PaymentDetailCreate, PaymentTransactionDetail>().ReverseMap();
            CreateMap<PaymentCreate, PaymentTransaction>().ReverseMap();
            CreateMap<PlantCode, AdminPlantCodeView>()
           .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserInformation.Username));
            CreateMap<PlantTracking, PlantTrackingView>()
           .ForMember(dest => dest.ProviceAddress, opt => opt.MapFrom(src => src.PlantCode.ProviceAddress))
           .ForMember(dest => dest.Provice, opt => opt.MapFrom(src => src.PlantCode.ProviceAddress))
           .ForMember(dest => dest.TotalStatus, opt => opt.MapFrom(src => src.PlantCode.Status));
            CreateMap<PostingNews, CreateNewsModel>().ReverseMap();
            CreateMap<PostingNews, ResponseNewsDetail>().ReverseMap();
            CreateMap<ResponsePostingDetail, PostingDetail>().ReverseMap();
        }
    }
}
