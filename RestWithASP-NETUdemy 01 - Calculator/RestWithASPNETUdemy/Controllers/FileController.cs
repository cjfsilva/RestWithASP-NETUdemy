using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using Swashbuckle.AspNetCore.Annotations;

namespace RestWithASPNETUdemy.Controllers

{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FileController : Controller
    {
        private IFileBusiness _fileBusiness;

        public FileController(IFileBusiness fileBusiness)
        {
            _fileBusiness = fileBusiness;
        }

        // POST api/v1/login
        [HttpGet]
        [SwaggerResponse((200), Type = typeof(byte []))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IActionResult GetPDFFile()
        {
            byte[] buffer = _fileBusiness.GetPDFFile();
            if (buffer != null)
            {
                HttpContext.Response.ContentType = "application/pdf";
                HttpContext.Response.Headers.Add("content-lenght", buffer.Length.ToString());             
                HttpContext.Response.Body.Write(buffer, 0, buffer.Length);
            }
            return new ContentResult();
        }
    }    
}
