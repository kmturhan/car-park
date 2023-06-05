using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrete
{
	public class SlotInformation : BaseModel
	{
        public ICollection<Translation> Translation { get; set; }
    }
}
