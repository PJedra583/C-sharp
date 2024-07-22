using System.Runtime.InteropServices.JavaScript;
using Tutorial3.Containers;

namespace Tutorial3;

public class Containerowiec
{
    public List<Container> Containers;
    public double Predkosc_Max;
    public double Waga_Max_w_tonach;
    public Containerowiec(double predkosc_max,double Waga_max_w_tonach)
    {
        Containers = new();
        Predkosc_Max = predkosc_max;
        Waga_Max_w_tonach = Waga_max_w_tonach;
    }

    public void ZaladujKontenerowiec(Container container)
    {
        double sum = 0;
        foreach (var var in Containers)
        {
            sum += var.CargoWeight;
        }
        sum += container.CargoWeight;
        if (sum > Waga_Max_w_tonach)
        {
            Console.Write("Nie udalo sie zaladowac statku");
        }
        else
        {
            Containers.Add(container);
        }
    }
    public void ZaladujKontenerowiec(Container[] containers)
    {
        foreach (var VARIABLE in containers)
        {
            ZaladujKontenerowiec(VARIABLE);
        }
    }

    public void Usun_kontener(Container c)
    {
        Containers.Remove(c);
    }

    public void Zastap_kontener(Container c,string number)
    {
        List<Container> containers2 = new();
        foreach (var VARIABLE in Containers)
        {
            containers2.Add(VARIABLE);
        }
        foreach (var VARIABLE in containers2)
        {
            if (number == VARIABLE.Series_number)
            {
                Containers.Remove(VARIABLE);
                Containers.Add(c);
            }
        }
    }

    public void Przenies(Container c, Containerowiec c2)
    {
        Containers.Remove(c);
        c2.Containers.Add(c);
    }

    public string inf_statek()
    {
        string s = "";
        foreach (var VARIABLE in Containers)
        {
            s += VARIABLE.inf_container();
            s += '\n';
        }
        return s + " predkosc_max: " + this.Predkosc_Max +  "waga: " + this.Waga_Max_w_tonach;
    }
}