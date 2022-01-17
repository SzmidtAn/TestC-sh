using ConsoleApp1.DTOs;
using ConsoleApp1.Entities;

namespace ConsoleApp1.DTOs
{
    public class AnimalIDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public BasicAnimalTypeDTO AnimalType { get; set; }

    }
}

public static class AnimalDTOExtensions
{
    public static AnimalIDTO ToAnimalDTO(this Animal animal)
    {
        return new AnimalIDTO
        {
            Id = animal.Id,
            Name = animal.Name,
            AnimalType = animal.AnimalType.ToBasicAnimalTypeDTO(),
        };
    }

    public static List<AnimalIDTO> ToAnimalDTOs(this List<Animal> animals)
    {
        return animals.Select(a => a.ToAnimalDTO()).ToList();
    }
}

