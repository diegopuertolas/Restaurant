namespace Restaurant.Models;

public class Drink : Product
{
    public bool IsAlcoholic { get; set; }

    public Drink(string name, decimal price, bool isAlcoholic)
        : base(name, price)
    {
        IsAlcoholic = isAlcoholic;
    }

    public override void ShowDescription()
    {
        Console.WriteLine($"Nombre: {Name} - Precio: {Price} - {(IsAlcoholic ? "Alcohólica" : "No Alcohólica")}");
    }
}