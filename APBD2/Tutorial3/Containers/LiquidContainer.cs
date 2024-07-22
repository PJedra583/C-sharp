using Tutorial3.Interfaces;

namespace Tutorial3.Containers;

public class LiquidContainer : Container,IHazardNotifier
{
    public bool Bezpieczny;
    public LiquidContainer(bool bezpieczny,double cargoWeight, double height,double weight,double depthInCm,string serial,double maxLadownoscWKg) 
        : base(cargoWeight, height, weight,depthInCm, serial, maxLadownoscWKg)
    {
        Bezpieczny = bezpieczny;
    }
    
    public override void Load(double cargoWeight)
    {
        base.Load(cargoWeight);
        Check();
    }

    public void Check()
    {
        if (Bezpieczny)
        {
            if (Max_ladownosc_w_kg*0.9<CargoWeight)
            {
                CargoWeight = Max_ladownosc_w_kg * 0.9;
                Console.Write("Próbowano przekroczyć standardy ładowania");
            }
        }
        else
        {
            if (Max_ladownosc_w_kg*0.5<CargoWeight)
            {
                CargoWeight = Max_ladownosc_w_kg * 0.5;
                Console.Write("Próbowano przekroczyć standardy ładowania" + Series_number);
            }
        }
    }
}