using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Common;
using WebApi.DBOperations;



namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {   public int BookId { get; set; }
        private readonly BookStoreDBContext _dBContext;
        public DeleteBookCommand(BookStoreDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public void Handle()
        {
             var book = _dBContext.Books.SingleOrDefault(x=>x.Id==BookId);

            if(book is null)
                throw new InvalidOperationException("Kitap mevcut degil!"); //if the book does not exist
            
            _dBContext.Books.Remove(book);
            _dBContext.SaveChanges();
        }
    }
}