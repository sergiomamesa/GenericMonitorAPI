﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GenericMonitorAPI.Models
{
    public class UserRole
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [Key, Column(Order = 1)]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}