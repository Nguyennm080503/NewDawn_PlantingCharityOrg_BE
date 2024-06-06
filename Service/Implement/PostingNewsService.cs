using AutoMapper;
using BussinessObjects.Models;
using DTOS.News;
using Microsoft.AspNetCore.Hosting;
using Repository.Interface;
using Service.Helper.ImageHandler;
using Service.Interface;

namespace Service.Implement
{
    public class PostingNewsService : IPostingNewsService
    {
        private readonly IImageHandler _imageHandler;
        private readonly IPostingNewsRepository _postingNewsRepository;
        private readonly IMapper _mapper;


        public PostingNewsService(IImageHandler imageHandler, IPostingNewsRepository postingNewsRepository, IMapper mapper)
        {
            _imageHandler = imageHandler;
            _postingNewsRepository = postingNewsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NewsMonthView>> GetAllNewsEachMonth()
        {
            var news = await _postingNewsRepository.GetAllNewsEachMonth();
            return news;
        }

        public async Task<ResponseNewsDetail> CreateNews(IWebHostEnvironment webHostEnvironment, CreateNewsModel createNewsModel, int userIdLogin)
        {
            var createNewsEntity = _mapper.Map<PostingNews>(createNewsModel);
            String urlImage = _imageHandler.UploadImageToFileReturnURL(createNewsModel.fileImage);
            createNewsEntity.DateCreate = DateTime.UtcNow;
            createNewsEntity.OwnerCreateID = userIdLogin;
            createNewsEntity.Thumbnail = urlImage;
            createNewsEntity.Status = 0;
            await _postingNewsRepository.CreateNews(createNewsEntity);
            var responseNewDetail = _mapper.Map<ResponseNewsDetail>(createNewsEntity);

            //var postingDetailEntity = new PostingDetail
            //{
            //    PostingNewsID = createNewsEntity.NewsID,
            //    URLPosting = urlImage,
            //};
            //await _postingDetailRepository.CreatePostingDetail(postingDetailEntity);
            //responseNewDetail.Details.Add(_mapper.Map<ResponsePostingDetail>(postingDetailEntity));

            return responseNewDetail;
        }

        public async Task<IEnumerable<NewsType>> GetAllNewsPosting()
        {
            var responseNews = await _postingNewsRepository.GetAllPostingNews();
            //var responsePostingDetail = await _postingDetailRepository.GetAllPostingDetail();

            //foreach (var responseNew in responseNews)
            //{
            //    responseNew.Details = responsePostingDetail.Where(x => x.PostingNewsID == responseNew.NewsID);
            //}

            return _mapper.Map<IEnumerable<NewsType>>(responseNews);

        }

        public async Task<IEnumerable<NewsType>> GetAllNewsByType(int typeID)
        {
            return await _postingNewsRepository.GetAllNewsByType(typeID);
        }

        public async Task<ResponseNewsDetail> GetNewsDetail(int newsID)
        {
            return _mapper.Map<ResponseNewsDetail>( await _postingNewsRepository.GetNewsDetailById(newsID));
        }

        public async Task DeleteNews(int id)
        {
            await _postingNewsRepository.DeleteNewsById(id);
        }
    }
}
