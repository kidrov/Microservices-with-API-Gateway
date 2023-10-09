using Entities;
using System;
using System.Collections.Generic;

namespace Service
{
    public interface INoteService
    {
        Note CreateNote(Note note);
        bool DeleteNote(string noteId);
        Note GetNoteByNoteId(string noteId);

        //List<Note> GetAllNotesByUserId(string userId);
        bool UpdateNote(string noteId, Note note);
    }
}
