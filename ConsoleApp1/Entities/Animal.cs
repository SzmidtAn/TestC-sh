using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Entities
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Type { get; set; }
        
        [Required]
        public string Name { get; set; }
        
    }
}