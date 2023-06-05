using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrete
{
	public class WorkingDay : BaseModel
	{
        public ICollection<Translation> Translation { get; set; }
        public ICollection<WorkingHour> WorkingHour { get; set; }
    }
}
