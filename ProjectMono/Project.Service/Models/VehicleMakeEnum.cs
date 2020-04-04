using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Project.Service.Models
{
  public enum Make_ID
    {
        [Description("BMW Group")] BMW = 1,
        [Description("Mercedes-Benz company")] MERCEDES = 2,
        [Description("Toyota motor")] TOYOTA = 3,
        [Description("Mazda motor")] MAZDA = 4,
        [Description("Lexus - Rekusasu")] LEXUS = 5
    }
}
