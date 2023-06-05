using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrete
{
	public class BaseModel
	{
		[BsonId]
		public ObjectId Id { get; set; }
	}
}
