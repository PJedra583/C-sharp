using Tutorial4.Database;
using Tutorial4.Models;

namespace Tutorial4.Endpoints;

public static class VisitEndpoints
{
    public static void MapVisitEndpoints(this WebApplication app)
    {
        //Zwracanie listy
        app.MapGet("/visits/{id_animal}", (int id) =>
        {
            Animal animal = AnimalShelter.Animals.Find(a => a.Id == id);
            List<Visit> list_of_visit_to_return = new List<Visit>();
            if (animal != null)
            {
                foreach (var VARIABLE in AnimalVisits.Visits)
                {
                    if (VARIABLE.VisitingAnimal.Equals(animal))
                    {
                        list_of_visit_to_return.Add(VARIABLE);
                    }
                }
                return Results.Ok(list_of_visit_to_return);
            }
            else
            {
                return Results.NotFound();
            }
        });

        //Dodanie wizyty
        app.MapPost("/visits", (Visit v) =>
        {
           AnimalVisits.Visits.Add(v);
           return Results.Ok();
        });
    }
}