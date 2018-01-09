using ProjectCar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCar.Models
{
    public class CarDetailViewModel
    {
        public int Id { get; set; }
        public DateTime Purchase { get; set; }
        public string LicensePlate { get; set; }
        public virtual Owner Owner { get; set; }
        public string Colour { get; set; }
        public virtual CarType CarType { get; set; }
    }
}
