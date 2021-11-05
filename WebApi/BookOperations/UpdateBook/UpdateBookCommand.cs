using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model {get; set;}
        public int BookId {get; set;}
        private readonly BookStoreDBContext _dbContext;
        private readonly IMapper _mapper; //mapping.

        public UpdateBookCommand(BookStoreDBContext dBContext, IMapper mapper)
        {
            _dbContext = dBContext;
            _mapper = mapper;
        }

        public void Handle()
        {
             var book = _dbContext.Books.SingleOrDefault(x=> x.Id== BookId); //fetch the book with the same id.

            if(book is null)
            {
                throw new InvalidOperationException("Kitap mevcut degil");
            }
             book = _mapper.Map<Book>(Model);

            //we are going to use ternary operator to check whether updatedBook's values equal to  book's or not.
            //Use Mapper instead.

            // book.GenreId = Model.GenreId !=default ? Model.GenreId : book.GenreId;
            // book.PageCount = Model.PageCount !=default ? Model.PageCount : book.PageCount;
            // book.Title = Model.Title !=default ? Model.Title : book.Title;
            // book.PublishDate = Model.PublishDate !=default ? Model.PublishDate : book.PublishDate;
            _dbContext.SaveChanges();
        }

        public class UpdateBookModel
        { //bilgileri resource haliyle alıyoruz.
            public string Title {get; set;} 
            public int PageCount {get; set;} 
            public DateTime PublishDate {get; set;} 
            public int GenreId {get; set;} 
        }
    }
}