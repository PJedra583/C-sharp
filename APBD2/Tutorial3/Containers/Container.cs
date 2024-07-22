using Tutorial3.Exceptions;
using Tutorial3.Interfaces;

namespace Tutorial3.Containers;

public abstract class Container : IContainer
{
    public double CargoWeight { get; set; }
    public double Height { get; set; }
    
    public double Weight { get; set; }

    public double Depth_in_cm { get; set; }

    public string Series_number;

    public string getSeries(string serial)
    {
        if (serial.Length >=7)
        {
            if (serial.Substring(0, 3) == "KON")
            {
                return Series_number;
            }
        }

        throw new Exception("Numer seryjny nie spełnia wymogów!");
    }
    public double Max_ladownosc_w_kg { get; set; }

    protected Container(double cargoWeight, double height,double weight,double depthInCm,string serial,double maxLadownoscWKg)
    {
        CargoWeight = cargoWeight;
        Height = height;
        Weight = weight;
        Depth_in_cm = depthInCm;
        Series_number = getSeries(serial);
        Max_ladownosc_w_kg = maxLadownoscWKg;
    }

    public void Unload()
    {
        CargoWeight = 0;
    }

    public virtual void Load(double cargoWeight)
    {
        if (Max_ladownosc_w_kg<cargoWeight)
        {
            throw new OverfillException();
        }
        
    }

    public string inf_container()
    {
        return
            "Cargoweight: " + this.CargoWeight +
            " Height: " + this.Height +
            " Weight: " + this.Weight +
            " Glebokosc: " + this.Depth_in_cm +
            " Max_ladownosc" + this.Max_ladownosc_w_kg +
            " Numer: " + this.Series_number;


    }
}