using System;
using System.Collections.Generic;
using ConsoleApp1.Entities;

using ConsoleApp1.DTOs;
using ConsoleApp1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            animal.AnimalTypeID = createAnimalIdto.AnimalTypeID;

            _context.Animals.Add(animal);
            _context.SaveChanges();

            return animal;
        }

        public void DeleteAnimal(int id)
        {
            _context.Animals.Remove(GetById(id));
            _context.SaveChanges();
        }

        public List<Animal> GetAll()
        {
            
            return _context.Animals.Include(a => a.AnimalType).ToList();
        }

        public Animal GetById(int id)
        {
            Animal animal = _context.Animals.Find(id);
            return animal;
        }

        public Animal UpdateAnimal(Animal animal,int id)
        {
            Animal existingAnimal = _context.Animals.FirstOrDefault(x => x.Id == id);
            if (existingAnimal is not null)
            {
                existingAnimal.Name = animal.Name;
                existingAnimal.AnimalTypeID = animal.AnimalTypeID;
            }
    
            _context.SaveChanges();
            return existingAnimal;
        }

    }
    }
