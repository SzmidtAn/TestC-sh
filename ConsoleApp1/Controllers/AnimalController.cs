using ConsoleApp1.DTOs;
using ConsoleApp1.Entities;
using ConsoleApp1.Repo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Controllers
{
    [ApiController]
    [Route("api/animals")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepo _repo;

        public AnimalController(IAnimalRepo repo)
        {
            _repo = repo;
        }


        // GET /api/animal
        [HttpGet]
        [Route("")]
        public IActionResult GetAnimals()
        {
            var animals = _repo
                .GetAll();
            var animals2 = animals.Select(v => new AnimalIDTO
                {
                    Id = v.Id,
                    Type = v.Type,
                    Name = v.Name,
                })
                .OrderBy(x => x.Name)
                ;
            return Ok(animals);
        }

        // GET /api/animal/:id
        [HttpGet("{id}")]
        public IActionResult GetAnimalByID(int id)
        {
            Animal animal = _repo.GetByID(id);
            if (animal is null) 
            {
                return NotFound("Could not find animal with ID " + id);
            }

            AnimalIDTO animalIdto = MapAnimalToAnimallDTO(animal);
            return Ok(animalIdto);
        }

        [HttpPost("")]
        public IActionResult CreateAnimal([FromBody]CreateAnimalIDTO createAnimalIdto)
        {
            Animal createAnimal = _repo.CreateAnimal(createAnimalIdto);
            AnimalIDTO animalIdto = MapAnimalToAnimallDTO(createAnimal);

            return CreatedAtAction(
                nameof(GetAnimalByID),
                new { id = animalIdto.Id },
                animalIdto);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateAnimal([FromBody] Animal animal, int id)
        {
            Animal updatedAnimal = _repo.UpdateAnimal(animal, id);
            AnimalIDTO animalIdto = MapAnimalToAnimallDTO(updatedAnimal);
            return Ok(animalIdto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            _repo.DeleteAnimal(id);
            return NoContent();
        }

        private AnimalIDTO MapAnimalToAnimallDTO(Animal animal)
        {
            return new AnimalIDTO
            {
                Id = animal.Id,
                Name = animal.Name,
                Type = animal.Type,
            };
        }
    }
}
