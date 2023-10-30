using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Village
{
    public interface ILocation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
