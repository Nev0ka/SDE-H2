using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Village
{
    public class House : ILocation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int OwnerID { get; set; }

        public House(int id, int ownerId, string villagerName, int value) 
        {
            ID = id;
            OwnerID = ownerId;
            Name = villagerName + "'s house";
            Value = value;
        }
    }
}
