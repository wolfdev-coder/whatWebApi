using Microsoft.AspNetCore.Mvc;
using whatWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace whatWebApi.Controllers
{
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly DbHelper _db;
        public GenreController(EF_DataContext _context)
        {
            _db = new DbHelper(_context);
        }
        // GET: api/<LibraryController>
        [HttpGet]
        [Route("api/[controller]/GetGenres")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<GenresModel> data = _db.GetGenres();
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
                GenresModel data = _db.GetGenreById(id);
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
        [Route("api/[controller]/SaveGenre")]
        public IActionResult Post([FromBody] GenresModel genresModel)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveGenre(genresModel);
                return Ok(ResponseHandler.GetAppResponse(type, genresModel));

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }

        // PUT api/<LibraryController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateGenre")]
        public IActionResult Put([FromBody] GenresModel genresModel)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveGenre(genresModel);
                return Ok(ResponseHandler.GetAppResponse(type, genresModel));

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }

        // DELETE api/<LibraryController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteGenre/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteGenre(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Успешно удалено!"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }
    }
}
