using Microsoft.AspNetCore.Mvc;
using whatWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace whatWebApi.Controllers
{
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly DbHelper _db;
        public AuthorsController(EF_DataContext _context)
        {
            _db = new DbHelper(_context);
        }
        // GET: api/<LibraryController>
        [HttpGet]
        [Route("api/[controller]/GetAuthors")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<AuthorModel> data = _db.GetAuthors();
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
        [Route("api/[controller]/GetAuthorsById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                AuthorModel data = _db.GetAuthorsById(id);
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
        [Route("api/[controller]/SaveAuthor")]
        public IActionResult Post([FromBody] AuthorModel authorModel)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveAuthor(authorModel);
                return Ok(ResponseHandler.GetAppResponse(type, authorModel));

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }

        // PUT api/<LibraryController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateAuthor")]
        public IActionResult Put([FromBody] AuthorModel authorModel)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveAuthor(authorModel);
                return Ok(ResponseHandler.GetAppResponse(type, authorModel));

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }

        // DELETE api/<LibraryController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteAuthor/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteAuthor(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Успешно удалено!"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }
    }
}
