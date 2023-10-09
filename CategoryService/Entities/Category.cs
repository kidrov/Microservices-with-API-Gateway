using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? CategoryId { get; set; }

        [BsonElement("CategoryName")]
        public string? CategoryName { get; set; }

        [BsonElement("CategoryDescription")]
        public string? CategoryDescription { get; set; }

        [BsonElement("CategoryCreatedBy")]
        public string? CategoryCreatedBy { get; set; }

        [BsonElement("CategoryCreationDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CategoryCreationDate { get; set; }

        //[BsonElement("Notes")]
        //public List<Note> Notes { get; set; }

        //[BsonElement("UserId")]
        //public string UserId { get; set; }

        //[BsonIgnore]
        //public User User { get; set; }
    }
}
