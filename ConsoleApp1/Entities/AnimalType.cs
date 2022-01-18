using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ConsoleApp1.Entities;

public sealed class AnimalType: BaseEntity
{
    [Required]
    public string Name { get; set; }

    public ICollection<Animal> Animals { get; set; }

    public AnimalType()
    {
        Animals = new List<Animal>();
    }
}
