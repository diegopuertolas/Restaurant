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

Console.Write("Precio Máximo: ");
var maxPrice = Console.ReadLine();

if (!decimal.TryParse(maxPrice, out decimal price))
{
    Console.WriteLine("Debes introducir un decimal.");
    return;
}

var found = false;
foreach (var product in restaurantMenu)
{
    if (product.Price <= price)
    {
        product.ShowDescription();
        found = true;
    }
}

if (!found)
{
    Console.WriteLine("No se han encontrado productos.");
}