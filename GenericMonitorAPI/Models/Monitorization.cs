using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GenericMonitorAPI.Models;

namespace GenericMonitorAPI.Context
{
    [Table("Monitorizations")]
    public class Monitorization : IMonitorizable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime CreationDate { get; set; }

        public Monitorization()
        {
            CreationDate = DateTime.Now;
        }
    }
}