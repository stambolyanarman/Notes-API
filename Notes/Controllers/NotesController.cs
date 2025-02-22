using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notes.DTOs;
using Notes.Interfaces;

namespace Notes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _service;
        public NotesController(INotesService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNoteRequest requestModel)
        {
            await _service.CreateNote(requestModel);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetNotesRequest request)
        {
            return Ok(await _service.GetNotes(request));
        }

    }
}
