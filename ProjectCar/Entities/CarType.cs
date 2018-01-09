using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCar.Entities
{
    public class CarType
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public virtual List<Car> Cars { get; set; }
    }
}