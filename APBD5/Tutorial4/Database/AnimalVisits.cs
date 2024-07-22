using Tutorial4.Models;
namespace Tutorial4.Database;

public class AnimalVisits
{
    public static List<Visit> Visits = new List<Visit>()
    {
        new Visit(new DateTime(2024,04,13),AnimalShelter.Animals[0],"Zjadł sznurówkę",100.0 ),
        new Visit(new DateTime(2024,04,13),AnimalShelter.Animals[1],"Kastracja",200.0 ),
        new Visit(new DateTime(2024,04,15),AnimalShelter.Animals[0],"Zjadł drugą sznurówke",200.0 )    

    };
    
}