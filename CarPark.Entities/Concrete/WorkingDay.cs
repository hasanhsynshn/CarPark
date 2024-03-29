﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrete
{
  public class WorkingDay: BaseModel
    {
        
        public int MyProperty { get; set; }
        public ICollection<Translation> Translations { get; set; }
        public ICollection<WorkingHour> WorkingHours { get; set; }
    }
}
