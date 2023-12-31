﻿using Enums;

namespace Locations
{
    public interface ILocation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Location { get; set; }
        public LocationsTypeEnums Type { get; set; }
    }
}