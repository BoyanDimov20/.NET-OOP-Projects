﻿using CashdeskManager.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CashdeskManager.Models
{
    public class CashMachineOpened
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int CustomersServiced { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
