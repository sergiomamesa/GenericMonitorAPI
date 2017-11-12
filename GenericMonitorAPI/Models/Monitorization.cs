using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GenericMonitorAPI.Context
{
    [Table("Monitorizations")]
    public class Monitorization : IMonitorizable
    {
        [Key]
        public int Key { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime CreationDate { get; private set; }

        public Monitorization()
        {
            CreationDate = DateTime.Now;
        }
    }
}