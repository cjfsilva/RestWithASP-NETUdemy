using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Business;
namespace RestWithASPNETUdemy.Controllers

{
    [ApiVersion("1")]
    //[Route("api/[controller]/v{version:apiVersion}")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonBusiness _personBusiness;

        public PersonController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        // GET api/person
        [HttpGet]
       public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        // GET api/person/{id}
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST api/person
        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personBusiness.Create(person));
        }

        // PUT api/person/{id}
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            var updatedPerson = _personBusiness.Update(person);
            if (updatedPerson == null) return NoContent();
            return new ObjectResult(updatedPerson);
        }

        // DELETE api/person/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }

    }    
}
