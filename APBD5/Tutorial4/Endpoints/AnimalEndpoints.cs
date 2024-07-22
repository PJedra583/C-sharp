using Tutorial4.Database;
using Tutorial4.Models;

namespace Tutorial4.Endpoints;

public static class AnimalEndpoints
{
    public static void MapAnimalEndpoints(this WebApplication app)
    {
        //Zwracanie listy
        app.MapGet("/animals", () =>
        {
            // 200 - Ok
            // 201 - Created
            // 400 - Bad request
            // 401 - Unauthorized
            // 403 - Forbidden
            // 404 - Not Found
            if (AnimalShelter.Animals != null && AnimalShelter.Animals.Count > 0)
            {
                return Results.Ok(AnimalShelter.Animals);
            }
            else
            {
                return Results.NotFound();
            }
        });

        //Pobieranie zwierzęcia
        app.MapGet("/animals/{id}", (int id) =>
        {
            Animal animal = AnimalShelter.Animals.Find(a => a.Id == id);
            if (animal != null)
            {
                return Results.Ok(animal);
            }
            else
            {
                return Results.NotFound();
            }
        });


        app.MapPost("/animals", (Animal animal) =>
        {
            if (AnimalShelter.Animals.Exists(a => a.Id == animal.Id))
            {
                return Results.BadRequest("Animal with given ID already exists!");
            }
            else
            {
                AnimalShelter.Animals.Add(animal);
                return Results.Created($"/animals/{animal.Id}", animal);
            }
        });
        app.MapPut("/animals/{id}", (int id, string name,string category,double weight,string haircolor) =>
        {
            int index = -1;
            for (int i = 0; i < AnimalShelter.Animals.Count; i++)
            {
                if (AnimalShelter.Animals[i].Id == id)
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                AnimalShelter.Animals[index].Name = name;
                AnimalShelter.Animals[index].Category = category;
                AnimalShelter.Animals[index].Weight = weight;
                AnimalShelter.Animals[index].Hair_color = haircolor;
                return Results.Ok(AnimalShelter.Animals[index]);
            }
            else
            {
                return Results.NotFound();
            }
        });
        app.MapDelete("/animals/{id}", (int id) =>
        {
            Animal animalToRemove = AnimalShelter.Animals.Find(a => a.Id == id);
<<<<<<< HEAD
=======
    
>>>>>>> baac5c9a7fc0cc7dfdaa8f6d37830c5e52807650
            if (animalToRemove != null)
            {
                AnimalShelter.Animals.Remove(animalToRemove);
                return Results.Ok();
            }
<<<<<<< HEAD
=======
            
>>>>>>> baac5c9a7fc0cc7dfdaa8f6d37830c5e52807650
            return Results.NotFound();
        });
    }
}