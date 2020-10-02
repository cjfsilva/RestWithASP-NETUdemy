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

    public class Person2Controller : Controller
    {
        private readonly IPerson2Business _person2Business;

        public Person2Controller(IPerson2Business person2Business)
        {
            _person2Business = person2Business;
        }

        // GET api/Person2
        [HttpGet]
        [SwaggerResponse((200), Type = typeof(List<Person2VO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize(Policy = "Bearer")]
        //[Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]

        public IActionResult Get()
        {
            return Ok(_person2Business.FindAll());
        }

        [HttpGet("find-by-name")]
        [SwaggerResponse((200), Type = typeof(List<Person2VO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize(Policy = "Bearer")]
        //[Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]

        public IActionResult GetByName([FromQuery] string firstName, [FromQuery] string lastName)
        {
            return new OkObjectResult(_person2Business.FindByName(firstName, lastName));
        }

        [HttpGet("find-with-paged-search/{sortDirection}/{pageSize}/{page}")]
        [SwaggerResponse((200), Type = typeof(List<Person2VO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize(Policy = "Bearer")]
        //[Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]

        public IActionResult GetPagedSearch([FromQuery] string name, string sortDirection, int pageSize, int page)
        {
            return new OkObjectResult(_person2Business.FindWithPagedSearch(name, sortDirection, pageSize, page));
        }

        // GET api/Person/{id}
        [HttpGet("{id}")]
        [SwaggerResponse((200), Type = typeof(Person2VO))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var person2 = _person2Business.FindById(id);
            if (person2 == null) return NotFound();
            return Ok(person2);
        }

        // POST api/Person2
        [HttpPost]
        [SwaggerResponse((201), Type = typeof(Person2VO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]Person2VO person2)
        {
            if (person2 == null) return BadRequest();
            return new ObjectResult(_person2Business.Create(person2));
        }

        // PUT api/Person2
        [HttpPut]
        [SwaggerResponse((202), Type = typeof(Person2VO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody]Person2VO person2)
        {
            if (person2 == null) return BadRequest();
            var updatedPerson2 = _person2Business.Update(person2);
            if (updatedPerson2 == null) return NoContent();
            return new ObjectResult(updatedPerson2);
        }

        // PATCH api/Person2
        [HttpPatch]
        [SwaggerResponse((202), Type = typeof(Person2VO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Patch([FromBody] Person2VO person2)
        {
            if (person2 == null) return BadRequest();
            var updatedPerson2 = _person2Business.Update(person2);
            if (updatedPerson2 == null) return NoContent();
            return new ObjectResult(updatedPerson2);
        }

        // DELETE api/Person2/{id}
        [HttpDelete("{id}")]
        [SwaggerResponse((204), Type = typeof(Person2VO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            _person2Business.Delete(id);
            return NoContent();
        }

    }
}
