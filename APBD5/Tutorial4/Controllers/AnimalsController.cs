using Microsoft.AspNetCore.Mvc;
using Tutorial4.Database;

namespace Tutorial4.Controllers;

[ApiController]
[Route("/animals-controller")]
public class AnimalsController : ControllerBase
{
<<<<<<< HEAD
    // This Code is actually not used. Consider checking AnimalEndpoints.
    // [HttpGet]
    // public IActionResult GetAnimals()
    // {
    //     var animals = AnimalShelter.Animals;
    //     return Ok(animals);
    // }
    //
    // [HttpGet("{id}")]
    // public IActionResult GetAnimalById(int id)
    // {
    //     return Ok(id);
    // }
    //
    // [HttpPost]
    // public IActionResult AddAnimal()
    // {
    //     return Created();
    // }
=======
    [HttpGet]
    public IActionResult GetAnimals()
    {
        var animals = AnimalShelter.Animals;
        return Ok(animals);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetAnimalById(int id)
    {
        return Ok(id);
    }

    [HttpPost]
    public IActionResult AddAnimal()
    {
        return Created();
    }
>>>>>>> baac5c9a7fc0cc7dfdaa8f6d37830c5e52807650
}