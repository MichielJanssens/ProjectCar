using ProjectCar.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCar.Models
{
    public class CarEditViewModel
    {
        public int Id { get; set; }
        public DateTime Purchase { get; set; }
        public string LicensePlate { get; set; }
        public string Colour { get; set; }
        public string Owner { get; set; }
        public int? OwnerId { get; set; }
        public string CarType { get; set; }
        public int? CarTypeId { get; set; }
        public List<SelectListItem> Owners { get; set; }
        public List<SelectListItem> CarTypes { get; set; }
    }
}
