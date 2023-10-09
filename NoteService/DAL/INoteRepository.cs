using Entities;
using System.Collections.Generic;

namespace DAL
{
    public interface INoteRepository
    {
        Note CreateNote(Note note);
        bool UpdateNote(string noteId, Note note);
        bool DeleteNote(string noteId);
        Note GetNoteByNoteId(string noteId);

        //List<Note> GetAllNotesByUserId(string userId);
    }
}
