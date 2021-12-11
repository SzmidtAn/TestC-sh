using System.Collections.Generic;
using ConsoleApp1.DTOs;
using ConsoleApp1.Entities;

namespace ConsoleApp1.Repo
{
    public interface IAnimalRepo
    {
        List<Animal> GetAll();

        Animal GetByID(int id);

        Animal CreateAnimal(CreateAnimalIDTO animal);

        Animal UpdateAnimal(Animal animal, int id);

        void DeleteAnimal(int id);
    }
}