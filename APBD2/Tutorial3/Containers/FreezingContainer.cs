using System.ComponentModel;

namespace Tutorial3.Containers;

public class FreezingContainer : Container 
{
    public string Rodzaj;
    public double Temperatura;
    public FreezingContainer(string rodzaj, double temperatura, double cargoWeight, double height,double weight,double depthInCm,string serial,double maxLadownoscWKg) 
        : base(cargoWeight, height, weight,depthInCm, serial, maxLadownoscWKg)
    {
        Rodzaj = rodzaj;
        Temperatura = temperatura;
    }
    
}