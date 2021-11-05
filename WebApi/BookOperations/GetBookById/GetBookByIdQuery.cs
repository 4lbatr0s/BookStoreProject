using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBooks;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBookById
{
    
    public class  GetBookByIdQuery
    {
        public int Id { get; set; }
         private readonly BookStoreDBContext _dbContext;

        public GetBookByIdQuery(BookStoreDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id ==Id).SingleOrDefault<Book>();
            if(book is null)
                throw new InvalidOperationException("Kitap bulunamadı!");
            BookDetailViewModel viewModel = new BookDetailViewModel();
            viewModel.Title = book.Title;
            viewModel.Genre = ((GenreEnum)book.GenreId).ToString();
            viewModel.PublishDate = book.PublishDate.Date.ToString();
            viewModel.PageCount = book.PageCount;
            
            return viewModel;
        }
        
    }

    public class BookDetailViewModel
    {
        public string Title {get; set;} 
        public int PageCount {get; set;} 
        public string PublishDate {get; set;} 
        public string Genre {get; set;} 
    }
}