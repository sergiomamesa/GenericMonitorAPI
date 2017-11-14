using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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