using LibraryBLL.DTOs.Requests;
using LibraryBLL.DTOs.Responses;
using LibraryDAL.Entities;
using AutoMapper;

namespace LibraryBLL.Mappings
{
    public class LibraryMappingProfile : Profile
    {
        public LibraryMappingProfile()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => CountAverageRating(src.Ratings)))
                .ForMember(dest => dest.ReviewsNumber, opt => opt.MapFrom(src => src.Reviews.Count));

            CreateMap<Book, BookDetailsDTO>()
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => CountAverageRating(src.Ratings)));
            
            CreateMap<Review, ReviewDTO>();

            CreateMap<SaveBookDTO, Book>();
            CreateMap<SaveReviewDTO, Review>();
            CreateMap<RateBookDTO, Rating>();
        }
        private decimal CountAverageRating(List<Rating> ratings)
        {
            if (ratings.Count == 0)
                return 0;
            return (decimal)ratings.Average(rating => rating.Score);
        }
    }
}
