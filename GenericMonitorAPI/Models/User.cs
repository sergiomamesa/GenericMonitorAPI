using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenericMonitorAPI.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Token { get; private set; }
        public DateTime CreationDate { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

        public User()
        {
            CreationDate = DateTime.Now;
        }

        public string GenerateNewToken()
        {
            Token = Guid.NewGuid().ToString();
            return Token;
        }
    }
}