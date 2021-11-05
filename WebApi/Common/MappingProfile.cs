using AutoMapper;
using WebApi.BookOperations.GetBookById;
using WebApi.BookOperations.GetBooks;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApi.Common
{

    public class MappingProfile : Profile //configleri MappingProfile sınıfından çek.
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>(); //CreateBookModel, Book objesine dönüştürülebilsin.
            CreateMap<UpdateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest=>dest.Genre, opt => opt.MapFrom(src =>((GenreEnum)src.GenreId).ToString()));
        
        }
    }
}