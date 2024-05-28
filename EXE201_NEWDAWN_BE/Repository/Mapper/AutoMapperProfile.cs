using AutoMapper;
using BussinessObjects.Models;
using DTOS.News;

namespace Repository.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<PostingNews, NewsMonthView>().ReverseMap();
        }
    }
}
