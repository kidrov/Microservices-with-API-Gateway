using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace KeepNote.Controllers
{
    [ApiController]
    [Route("api/note")] // Base route for NoteController
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpPost]
        public IActionResult CreateNote(Note note)
        {
            // Call the NoteService to create a note
            var createdNote = _noteService.CreateNote(note);
            return Created("", createdNote); // 201 Created
        }

        [HttpDelete("{noteId}")]
        public IActionResult DeleteNote(string noteId)
        {
            // Call the NoteService to delete a note
            var result = _noteService.DeleteNote(noteId);
            if (result)
            {
                return Ok(); // 200 OK
            }
            return NotFound(); // 404 Not Found
        }

        [HttpPut("{noteId}")]
        public IActionResult UpdateNote(string noteId, Note note)
        {
            // Call the NoteService to update a note
            var result = _noteService.UpdateNote(noteId, note);
            if (result)
            {
                return Ok(); // 200 OK
            }
            return NotFound(); // 404 Not Found
        }

        //[HttpGet("{userId}")]
        //public IActionResult GetNotesByUserId(string userId)
        //{
        //    // Call the NoteService to get notes by user ID
        //    var notes = _noteService.GetAllNotesByUserId(userId);
        //    return Ok(notes); // 200 OK
        //}
    }
}
