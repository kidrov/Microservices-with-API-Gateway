using System.Collections.Generic;
using Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DAL
{
    public class NoteRepository : INoteRepository
    {
        private readonly IMongoCollection<Note> _notes;

        public NoteRepository(IMongoDatabase database)
        {
            _notes = database.GetCollection<Note>("Notes");
        }

        public Note CreateNote(Note note)
        {
            _notes.InsertOne(note);
            return note;
        }

        public bool DeleteNote(string noteId)
        {
            var filter = Builders<Note>.Filter.Eq(n => n.NoteId, int.Parse(noteId));
            var result = _notes.DeleteOne(filter);
            return result.DeletedCount > 0;
        }

        //public List<Note> GetAllNotesByUserId(string userId)
        //{
        //    var filter = Builders<Note>.Filter.Eq(n => n.UserId, int.Parse(userId));
        //    return _notes.Find(filter).ToList();
        //}

        public Note GetNoteByNoteId(string noteId)
        {
            var filter = Builders<Note>.Filter.Eq(n => n.NoteId, int.Parse(noteId));
            return _notes.Find(filter).FirstOrDefault();
        }

        public bool UpdateNote(string noteId, Note note)
        {
            var filter = Builders<Note>.Filter.Eq(n => n.NoteId, int.Parse(noteId));
            var result = _notes.ReplaceOne(filter, note);
            return result.ModifiedCount > 0;
        }

    }
}
