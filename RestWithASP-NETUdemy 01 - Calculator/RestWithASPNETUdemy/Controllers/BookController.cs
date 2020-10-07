using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using Tapioca.HATEOAS;

namespace RestWithASPNETUdemy.Controllers

{
    [ApiVersion("1")]
    //[Route("api/[controller]/v{version:apiVersion}")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class BookController : Controller
    {
        private readonly IBookBusiness _bookBusiness;

        public BookController(IBookBusiness BookBusiness)
        {
            _bookBusiness = BookBusiness;
        }

        // GET api/Books
        [HttpGet]
        [SwaggerResponse((200))]
        //[SwaggerResponse((200), Type = typeof(List<BookVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize(Policy = "Bearer")]
        [Authorize("Bearer")]
        
        [TypeFilter(typeof(HyperMediaFilter))]

        public IActionResult Get()
        {
            return new ObjectResult(_bookBusiness.FindAll());
        }

        // GET api/Books/{id}
        [HttpGet("{id}")]
        [SwaggerResponse((200))]
        //[SwaggerResponse((200), Type = typeof(BookVO))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var books = _bookBusiness.FindById(id);
            if (books == null) return NotFound();
            return new OkObjectResult(books);
        }

        // POST api/Books
        [HttpPost]
        [SwaggerResponse((201))]
        //[SwaggerResponse((201), Type = typeof(BookVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]BookVO book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(_bookBusiness.Create(book));
        }

        // PUT api/Books
        [HttpPut]
        [SwaggerResponse((202))]
        //[SwaggerResponse((202), Type = typeof(BookVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody]BookVO book)
        {
            if (book == null) return BadRequest();
            var updatedBooks = _bookBusiness.Update(book);
            if (updatedBooks == null) return NoContent();
            return new ObjectResult(updatedBooks);
        }

        // PATCH api/Books
        [HttpPatch]
        [SwaggerResponse((202))]
        //[SwaggerResponse((202), Type = typeof(BookVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Patch([FromBody] BookVO book)
        {
            if (book == null) return BadRequest();
            var updatedBooks = _bookBusiness.Update(book);
            if (updatedBooks == null) return NoContent();
            return new ObjectResult(updatedBooks);
        }

        // DELETE api/Books/{id}
        [HttpDelete("{id}")]
        [SwaggerResponse((204))]
        //[SwaggerResponse((204), Type = typeof(BookVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            _bookBusiness.Delete(id);
            return NoContent();
        }

    }
}
