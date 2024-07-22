namespace Tutorial4.Models;

public class Visit
{
    public DateTime DateOfVisit { get; set; }
    public Animal VisitingAnimal { get; set; }
    public String Description { get; set; }
    public Double Price { get; set; }
    public Visit(DateTime dateOfVisit, Animal visitingAnimal, string description, double price)
    {
        DateOfVisit = dateOfVisit;
        VisitingAnimal = visitingAnimal;
        Description = description;
        Price = price;
    }

    
}