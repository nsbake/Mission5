using System;
using System.ComponentModel.DataAnnotations;

namespace Mission4.Models
{
    public class Rating
    {
        [Key][Required]
        public string RatingID { get; set; }
    }
}
