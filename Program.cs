using Restaurant.Models;

var cocacola = new Drink("Cocacola", 2m, false);
var cervezaAmbar = new Drink("1/3 Ambar", 1.80m, true);
var solomillo = new PrincipalDish("Solomillo", 15.99m, ["Solomillo", "Patatas", "Ensaladas"]);
var entrecot = new PrincipalDish("Entrecot", 15.99m, ["Entrecot", "Patatas", "Pimientos"]);
var tartaQueso = new Dessert("Tarta Queso", 6.99m, true);
var helado = new Dessert("Helado Magnum", 1.50m, true);
var bravas = new Starter("Patatas Bravas", 5.99m, 2, false);
var calamares = new Starter("Calamares", 8.99m, 2, false);

var restaurantMenu = new List<Product>
{
    cocacola,
    cervezaAmbar,
    solomillo,
    entrecot,
    tartaQueso,
    helado,
    bravas,
    calamares
};


Console.WriteLine("=== Carta ===");

var position = 1;
foreach (var product in restaurantMenu)
{   
    Console.Write($"{position}: ");
    position++;
    product.ShowDescription();
}

Console.WriteLine();
Console.Write("Eliga un producto: ");
var entry = Console.ReadLine();

if (!int.TryParse(entry, out int number))
{
    Console.WriteLine("Debes introducir un número entero.");
} else if (number > restaurantMenu.Count || number <= 0)
{
    Console.WriteLine("Ese producto no existe.");
} else 
{
    number--;
    Console.Write("Has elegido: ");
    restaurantMenu[number].ShowDescription();
}