using Microsoft.AspNetCore.Mvc;
using whatWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace whatWebApi.Controllers
{
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly DbHelper _db;
        public BooksController(EF_DataContext _context)
        {
            _db = new DbHelper(_context);
        }
        // GET: api/<LibraryController>
        [HttpGet]
        [Route("api/[controller]/GetBooks")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<BookModel> data = _db.GetBooks();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET api/<LibraryController>/5
        [HttpGet]
        [Route("api/[controller]/GetBooksById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                BookModel data = _db.GetBooksById(id);
                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<LibraryController>
        [HttpPost]
        [Route("api/[controller]/SaveBook")]
        public IActionResult Post([FromBody] BookModel bookModel)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveBook(bookModel);
                return Ok(ResponseHandler.GetAppResponse(type, bookModel));

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }

        // PUT api/<LibraryController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateBook")]
        public IActionResult Put([FromBody] BookModel bookModel)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveBook(bookModel);
                return Ok(ResponseHandler.GetAppResponse(type, bookModel));

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }

        // DELETE api/<LibraryController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteBook/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteBook(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Успешно удалено!"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }
    }
}
