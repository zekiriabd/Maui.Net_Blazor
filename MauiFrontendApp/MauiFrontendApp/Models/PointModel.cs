﻿using System.ComponentModel.DataAnnotations;

namespace MauiFrontendApp.Models
{
    public class PointModel
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public DateTime Date { get; set; }

        [Range(0, 20, ErrorMessage = "Point must be between 0 and 20")]
        public decimal Point { get; set; }
    }
}
