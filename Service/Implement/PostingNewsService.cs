using AutoMapper;
using BussinessObjects.Enumeration;
using BussinessObjects.Models;
using DTOS.News;
using DTOS.PostingDetail;
using Microsoft.AspNetCore.Hosting;
using Repository.Interface;
using Service.Interface;

namespace Service.Implement
{
    public class PostingNewsService : IPostingNewsService
    {
        private readonly IPostingDetailRepository _postingDetailRepository;
        private readonly IPostingNewsRepository _postingNewsRepository;
        private readonly IMapper _mapper;


        public PostingNewsService(IPostingNewsRepository postingNewsRepository, IPostingDetailRepository postingDetailRepository, IMapper mapper) 
        {
            _postingDetailRepository = postingDetailRepository;
            _postingNewsRepository = postingNewsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NewsMonthView>> GetAllNewsEachMonth()
        {
            var news = await _postingNewsRepository.GetAllNewsEachMonth();
            return news;
        }

        public async Task<ResponseNewsDetail> CreateNews(IWebHostEnvironment webHostEnvironment, CreateNewsModel createNewsModel)
        {
            var createNewsEntity = _mapper.Map<PostingNews>(createNewsModel);
            await _postingNewsRepository.CreateNews(createNewsEntity);
            var responseNewDetail = _mapper.Map<ResponseNewsDetail>(createNewsEntity);
            foreach (var fileImage in createNewsModel.fileImages)
            {
                String urlImage = await Helper.ImageHandler.UploadImageToFileReturnURL(webHostEnvironment, fileImage, EnumTypeFolderImage.news.ToString(), Guid.NewGuid().ToString("N"));
                var postingDetailEntity = new PostingDetail
                {
                    PostingNewsID = createNewsEntity.NewsID,
                    URLPosting = urlImage,
                };
                await _postingDetailRepository.CreatePostingDetail(postingDetailEntity);
                responseNewDetail.Details.Add(_mapper.Map<ResponsePostingDetail>(postingDetailEntity));
            }
            return responseNewDetail;
        }

        public async Task<IEnumerable<ResponseNewsDetail>> GetAllNewsPosting()
        {
            var responseNews = _postingNewsRepository.GetAllPostingNews().Result.ToList();
            var responsePostingDetail = await _postingDetailRepository.GetAllPostingDetail();
            
            foreach (var responseNew in responseNews)
            {
                responseNew.Details = responsePostingDetail.Where(x => x.PostingNewsID == responseNew.NewsID);
            }

            return _mapper.Map<IEnumerable<ResponseNewsDetail>>(responseNews);

        }

    }
}
