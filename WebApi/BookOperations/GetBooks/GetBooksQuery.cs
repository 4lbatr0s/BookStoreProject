using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDBContext _dbContext;
        //dependency injection.
        public GetBooksQuery(BookStoreDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        
        
        public List<BooksViewModel> Handle()
        {
             var bookList = _dbContext.Books.OrderBy(x=>x.Id).ToList<Book>();
             List<BooksViewModel> viewModel = new List<BooksViewModel>();
             foreach (var book in bookList)
             {
                 viewModel.Add(new BooksViewModel(){
                     Title = book.Title,
                     Genre = ((GenreEnum)book.GenreId).ToString(),
                     PublishDate = book.PublishDate.ToString("'dd/MM/yy'"),
                     PageCount = book.PageCount
                 });
             } 
             return viewModel;
        }
    }

        //resource.
    public class BooksViewModel
    {
        public string Title {get; set;} 
        public int PageCount {get; set;} 
        public string PublishDate {get; set;} 
        public string Genre {get; set;} 
    }
}