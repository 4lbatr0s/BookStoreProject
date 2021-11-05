using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
         public CreateBookModel Model {get; set;}
         public int Id {get; set;}
        private readonly BookStoreDBContext _dbContext;
        private readonly IMapper _mapper;
        public CreateBookCommand(BookStoreDBContext dBContext, IMapper mapper)
        {
            _dbContext = dBContext;
            _mapper = mapper;
        }

        public void Handle()
        {
             //linq
            var book = _dbContext.Books.SingleOrDefault(x=> x.Id == Id);

            if(book is not null)
            {  
                throw new InvalidOperationException("Kitap zaten mevcut");
            } 
            book = _mapper.Map<Book>(Model); //model ile gelen veriyi book objesine maple, convert et.  
            
            // new Book();
            //mapping sayesinde bunlara gerek kalmadı.
            // book.Title = Model.Title;
            // book.PageCount = Model.PageCount;
            // book.GenreId = Model.GenreId;
            // book.PublishDate = Model.PublishDate;

            
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges(); //her degisiklik yaptıktan sonra context save edilmelidir.
        }

        public class CreateBookModel
        { //bilgileri resource haliyle alıyoruz.
            public string Title {get; set;} 
            public int PageCount {get; set;} 
            public DateTime PublishDate {get; set;} 
            public int GenreId {get; set;} 
        }


    }


     
}