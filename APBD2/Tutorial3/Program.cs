using Tutorial3;
using Tutorial3.Containers;

public class Program
{
    public static void Main(string[] args)
    {
        Container a = new FreezingContainer("Freezing", 2.0, 10, 1, 20, 100.4, "KON-F-1", 50.0);
        Container b = new FreezingContainer("Freezing", 2.0, 200, 1, 20, 100.4, "KON-F-1", 50.0);
        Container c = new GasContainer(20, 200, 15, 300, "KON-G-2", 200);

        Containerowiec statek = new Containerowiec(200,40);
        Containerowiec statek2 = new Containerowiec(500, 1300);
        statek.ZaladujKontenerowiec(a);
        Console.WriteLine(statek.Containers.Count());
        statek.Przenies(a,statek2);
        Console.WriteLine("================");
        Console.WriteLine(statek.Containers.Count());
        Console.WriteLine(statek2.Containers.Count());
        // statek.ZaladujKontenerowiec(b);

    }
}