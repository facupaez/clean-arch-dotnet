using System;
using AppVenta.Infraestructura.Datos.Contextos;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Creando DB si no existe...");
        VentaContexto db = new VentaContexto();
        db.Database.EnsureCreated();
        Console.WriteLine("DB creada!");
        Console.ReadKey();
    }
}
