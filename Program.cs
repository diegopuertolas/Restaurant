using Restaurant.Models;

var cocacola = new Drink("Cocacola", 2m, false);
var cervezaAmbar = new Drink("1/3 Ambar", 1.80m, true);
var solomillo = new PrincipalDish("Solomillo", 15.99m, ["Solomillo", "Patatas", "Ensaladas"]);
var entrecot = new PrincipalDish("Entrecot", 18.99m, ["Entrecot", "Patatas", "Pimientos"]);
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

ShowMenu(restaurantMenu);
Console.WriteLine();

ChooseProduct(restaurantMenu);
Console.WriteLine();

SearchProduct(restaurantMenu);
Console.WriteLine();

ProductsPerPrice(restaurantMenu);
Console.WriteLine();

MostExpensiveProduct(restaurantMenu);


static void ShowMenu(List<Product> menu)
{
    Console.WriteLine("=== CARTA ===");
    
    var position = 1;
    foreach (var product in menu)
    {   
        Console.Write($"{position++} --> ");
        product.ShowDescription();
    }
}

static void ChooseProduct(List<Product> menu)
{
    ShowMenu(menu);
    Console.Write("Eliga un producto: ");
    var input = Console.ReadLine();
    if (!int.TryParse(input, out int decision) || decision < 1 || decision > menu.Count)
    {
        Console.WriteLine("No hay un producto asignado a este número.");
    } else {
        menu[decision - 1].ShowDescription();
    }
}

static void SearchProduct(List<Product> menu)
{
    ShowMenu(menu);
    Console.Write("Busca un producto: ");
    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Debes escribir el nombre de un producto.");
        return;
    }

    var inputModified = input.Trim().ToLower();

    var found = false;
    foreach (var product in menu)
    {
        if (inputModified.Equals(product.Name.Trim().ToLower()))
        {
            Console.Write("Has elegido: ");
            product.ShowDescription();
            found = true;
            break;
        }
    }

    if (!found)
    {
        Console.WriteLine("No existe ese producto.");
    }
}

static void ProductsPerPrice(List<Product> menu)
{
    menu.Sort((a, b) => a.Price.CompareTo(b.Price));
    foreach (var product in menu)
    {
        product.ShowDescription();
    }
}

static void MostExpensiveProduct(List<Product> menu)
{
    var mostExpesinve = menu[0];

    foreach (var product in menu)
    {
        if (product.Price > mostExpesinve.Price)
        {
            mostExpesinve = product;
        }
    }

    Console.WriteLine("=== Producto más caro ===");
    mostExpesinve.ShowDescription();
}