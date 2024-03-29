﻿using System.ComponentModel.DataAnnotations;

namespace OctagonPlatform.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The City's name is required")]
        [StringLength(20)]
        public string Name { get; set; }

        [Display(Name = "State")]
        public int StateId { get; set; }

        public State State { get; set; }

    }
}