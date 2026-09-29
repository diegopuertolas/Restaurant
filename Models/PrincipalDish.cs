namespace Restaurant.Models;

public class PrincipalDish : Product
{
    public List<string> Ingredients { get; set; }

    public PrincipalDish(string name, decimal price, List<string> ingredients)
        : base(name, price)
    {
        Ingredients = ingredients;
    }

    public override void ShowDescription()
    {
        Console.WriteLine($"Nombre: {Name} - Precio: {Price} - Ingredientes: {string.Join(", ", Ingredients)}.");
    }
}