namespace Restaurant.Models;

public class Dessert : Product
{
    public bool HasSugar { get; set; }

    public Dessert (string name, decimal price, bool hasSugar)
        : base(name, price)
    {
        HasSugar = hasSugar;
    }

    public override void ShowDescription()
    {
        Console.WriteLine($"Nombre: {Name} - Precio: {Price} - {(HasSugar ? "Contiene Azucar" : "Sin Azucar")}");
    }
}