using Project.Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Service
{
   [Table("VehicleModel")]
    public class VehicleModel
    {
        public int Id { get; set; }
       // public int MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        //public Make_ID MakeId { get; set; }

        //public ICollection<VehicleMake> vehicleMakes { get; set; }

        public int MakeId { get; set; }
        //[Column("FK_Vehicle_Make")]
        //public int VehicleMake { get; set; }

    }
}