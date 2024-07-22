using Tutorial4.Database;
namespace Tutorial4.Models;

public class Animal
{
    private static int counter = 0;
    public Animal(string name, string category, double weight, string hairColor)
    {
        Id = counter++;
        Name = name;
        Category = category;
        Weight = weight;
        Hair_color = hairColor;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Weight { get; set; }
    public string Hair_color { get; set;}
    
<<<<<<< HEAD
    public override bool Equals(object obj)
    {
        if (obj is Animal animal)
        {
            if (this.Id == animal.Id && this.Category.Equals(animal.Category) && this.Hair_color.Equals(animal.Hair_color) 
                && this.Weight == animal.Weight && this.Name.Equals(animal.Name))
            {
                return true;
            }
        }
        return false;
    }
    public override string ToString()
    {
        return Id + "  " + Name + "  " + Category + "  " + Hair_color + "  " + Weight;
    }
=======
>>>>>>> baac5c9a7fc0cc7dfdaa8f6d37830c5e52807650
}