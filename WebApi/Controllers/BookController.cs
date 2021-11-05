using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBookById;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApi.Controllers
{
    [ApiController] //promises a http response.
    [Route("[controller]s")] //decides the return url

    public class BookController:ControllerBase
    {
        private readonly BookStoreDBContext _context;

        //dependency injection
        public BookController(BookStoreDBContext context)
        {
            _context =context;

        } 
    
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result); 
        }

        [HttpGet("{id}")]
        public IActionResult GetBookByGenreId(int id)
        {
            BookDetailViewModel result;

            try
            {
                GetBookByIdQuery query = new GetBookByIdQuery(_context);
                query.Id = id;
                result = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
  
            return Ok(result);

        } 


        [HttpPost]
        //IActionResult --> a return value is a must.
        public IActionResult AddBook([FromBody] CreateBookModel newBook) //book comes from body part of the html request.
        {
            CreateBookCommand command = new CreateBookCommand(_context); 
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }

            return Ok();
        }


        //HTTP Put
        [HttpPut("{id}")]

        public IActionResult AddBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
           UpdateBookCommand command = new UpdateBookCommand(_context);
           command.Model = updatedBook;
           try
           {
                command.Model = updatedBook;
                command.BookId = id;
                command.Handle();
           }
           catch (Exception ex)
           {
               
               return BadRequest(ex.Message);
           }
            return Ok();
            
        }


        //DELETE

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                command.Handle();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
        
    
}
