using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrete
{
	public class FloorInformation : BaseModel
	{
        public int Number { get; set; }
        public ICollection<SlotInformation> SlotInformations { get; set; }
    }
}
