using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCar.Models
{
    public class CarTypeDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public List<CarDetailViewModel> Cars { get; set; }
    }
}
