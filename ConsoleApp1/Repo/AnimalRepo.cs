using System;
using System.Collections.Generic;
using ConsoleApp1.Entities;

using ConsoleApp1.DTOs;
using ConsoleApp1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Repo
{
    
    public class AnimalRepo : IAnimalRepo
    {
        private ApplicationContext _context;
        //private ApplicationContext _db;

        public AnimalRepo(ApplicationContext context)
        {
            _context = context;
        }

        public Animal CreateAnimal(CreateAnimalIDTO createAnimalIdto)
        {
            Animal animal = new Animal();

            animal.Name = createAnimalIdto.Name;
            animal.Type = createAnimalIdto.Type;

            _context.Animals.Add(animal);
            _context.SaveChanges();

            return animal;
        }

        public void DeleteAnimal(int id)
        {
            _context.Animals.Remove(GetByID(id));
            _context.SaveChanges();
        }

        public List<Animal> GetAll()
        {
            return _context.Animals.ToList();
        }

        public Animal GetByID(int id)
        {
            Animal animal = _context.Animals.Find(id);
            return animal;
        }

        public Animal UpdateAnimal(Animal animal,int id)
        {
            Animal existingAnimal = _context.Animals.FirstOrDefault(x => x.Id == id);
            if (existingAnimal is not null)
            {
                existingAnimal.Type = animal.Type;
                existingAnimal.Name = animal.Name;
            }
    
            _context.SaveChanges();
            return existingAnimal;
        }

    }
    }
