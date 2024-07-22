using Tutorial3.Exceptions;
using Tutorial3.Interfaces;

namespace Tutorial3.Containers;

public class GasContainer : Container, IHazardNotifier
{
    public GasContainer(double cargoWeight, double height,double weight,double depthInCm,string serial,double maxLadownoscWKg) 
        : base(cargoWeight, height, weight,depthInCm, serial, maxLadownoscWKg)
    {
        
    }
    public void Check()
    {
        if (CargoWeight>Max_ladownosc_w_kg)
        {
            throw new OverfillException();
        }
    }

    public void Unload()
    {
        CargoWeight *= 0.05;
    }

    public void Load(double cargoWeight)
    {
        base.Load(cargoWeight);
        Check();
    }
}