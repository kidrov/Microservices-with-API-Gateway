using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [BsonId]
        public int NoteId { get; set; }

        [Required]
        [BsonElement("NoteTitle")]
        public string? NoteTitle { get; set; }

        [BsonElement("NoteContent")]
        public string? NoteContent { get; set; }

        [BsonElement("NoteStatus")]
        public string? NoteStatus { get; set; }

        //[BsonElement("CreatedAt")]
        //[BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        //public DateTime? CreatedAt { get; set; }

        //[ForeignKey("CategoryId")]
        //[BsonElement("CategoryId")]
        //public int? CategoryId { get; set; }

        //[ForeignKey("ReminderId")]
        //[BsonElement("ReminderId")]
        //public int? ReminderId { get; set; }

        //[Required]
        //[BsonElement("CreatedBy")]
        //public string? CreatedBy { get; set; }

        //[JsonIgnore]
        //[BsonElement("Category")]
        //public Category? Category { get; set; }

        //[JsonIgnore]
        //[BsonElement("Reminder")]
        //public Reminder? Reminder { get; set; }

        //[ForeignKey("UserId")]
        //[BsonElement("UserId")]
        //public int UserId { get; set; }

        //[JsonIgnore]
        //public User? User { get; set; }
    }
}
