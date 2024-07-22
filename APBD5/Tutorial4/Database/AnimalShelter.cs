using Tutorial4.Models;

namespace Tutorial4.Database;

public class AnimalShelter
{
    public static List<Animal> Animals { get; set; } = new List<Animal>()
    {
        new Animal("Pimpek","Pies",10.9,"#173849"),
        new Animal("Gacuś","Kot",15.9,"Black and white"),
        new Animal("Fafik","Pies",12.0,"Brown")
    };
}