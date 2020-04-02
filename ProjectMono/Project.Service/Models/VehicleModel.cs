using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Service
{
   [Table("Vehicle")]
    public class VehicleModel
    {
        public int Id { get; set; }
       // public int MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public VehicleMake MakeId { get; set; }

    }
}