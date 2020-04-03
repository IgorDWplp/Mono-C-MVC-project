using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Models
{
   public class SqlRepositry : IMonoRepositry
    {

        private readonly AppDbContext context;

        public SqlRepositry(AppDbContext context)
        {
            this.context = context;
        }

    }
}
