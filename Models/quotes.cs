using System;
using System.ComponentModel.DataAnnotations;

namespace quotes.Models
{
    public abstract class BaseEntity {}
    public class Quotes : BaseEntity
    {
        [Required]
        [MinLength(5)]
        public string content{get; set;}

        [Required]
        [MinLength(2)]
        public string name{get; set;}

        [Required]
        public DateTime created_at{get; set;}

        [Required]
        public DateTime updated_at{get; set;}
    }
}