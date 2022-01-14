﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Vcmng.Infrastructure.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        [BsonRequired]
        public string Description { get; set; }

        [BsonRequired]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }

        [BsonRequired]
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}
