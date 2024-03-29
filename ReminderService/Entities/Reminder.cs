﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Reminder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReminderId { get; set; }

        [Required]
        public string? ReminderName { get; set; }

        public string? ReminderDescription { get; set; }
            
        public string? ReminderType { get; set; }

        [Required]
        public string? ReminderCreatedBy { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? ReminderCreationDate { get; set; } = DateTime.UtcNow;

        //[JsonIgnore]
        //public ICollection<Note>? Notes { get; set; }

        //[ForeignKey("User")]
        //public int UserId { get; set; }

        //[JsonIgnore]
        //public User? User { get; set; }
    }
}

