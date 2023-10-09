using System;
using System.Collections.Generic;
using DAL; 
using Entities;
using Exceptions;
using Service;

namespace Service
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository; 
       

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public Note CreateNote(Note note)
        {
            // Business logic and validation (if needed)
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note), "Note cannot be null.");
            }

            
            return _noteRepository.CreateNote(note);
        }

        public bool DeleteNote(string noteId) 
        {
            
            return _noteRepository.DeleteNote(noteId);
        }

        //public List<Note> GetAllNotesByUserId(string userId)
        //{
            
        //    return _noteRepository.GetAllNotesByUserId(userId);
        //}

        public Note GetNoteByNoteId(string noteId) 
        {
            
            return _noteRepository.GetNoteByNoteId(noteId);
        }

        public bool UpdateNote(string noteId, Note note)
        {
            // Check if the note exists
            var existingNote = _noteRepository.GetNoteByNoteId(noteId);
            if (existingNote == null)
            {
                throw new NoteNotFoundException($"Note with ID {noteId} not found.");
            }

            
            return _noteRepository.UpdateNote(noteId, note);
        }
    }
}
