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

var option = -1;
do
{   
    ShowOptions();
    option = ChooseOption();

    switch (option)
    {
        case 1:
            Console.WriteLine(); 
            ShowMenu(restaurantMenu);
            break;
        case 2:
            Console.WriteLine();
            ChooseProduct(restaurantMenu);
            break;
        case 3:
            Console.WriteLine();
            SearchProduct(restaurantMenu);
            break;
        case 4:
            Console.WriteLine();
            ProductsPerPrice(restaurantMenu);
            break;
        case 5:
            Console.WriteLine();
            MostExpensiveProduct(restaurantMenu);
            break;
        case 0:
            Console.WriteLine("Saliendo del programa...");
            break;
        default:
            Console.WriteLine("\nOpción no válida. Incluya un número del  al 5.");
            break;
    }
} while (option != 0);

static void ShowOptions()
{  
    Console.WriteLine("\n=================");
    Console.WriteLine("   RESTAURANTE   ");
    Console.WriteLine("=================");
    Console.WriteLine("\n1. Ver carta");
    Console.WriteLine("2. Elegir producto");
    Console.WriteLine("3. Buscar producto");
    Console.WriteLine("4. Productos por precio");
    Console.WriteLine("5. Producto más caro");
    Console.WriteLine("0. Salir");
    Console.Write("\nElige una opción: ");   
}

static int ChooseOption()
{
    var input = Console.ReadLine();

    if (!int.TryParse(input, out int decision))
    {
        return -1;
    }        
    return decision;
}

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
    Console.Write("\nEliga un producto: ");
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
    Console.Write("\nBusca un producto: ");
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
            Console.Write("\nHas elegido: ");
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
    var sortedMenu = new List<Product>(menu);
    sortedMenu.Sort((a, b) => a.Price.CompareTo(b.Price));
    foreach (var product in sortedMenu)
    {
        product.ShowDescription();
    }
}

static void MostExpensiveProduct(List<Product> menu)
{
    var mostExpensive = menu[0];

    foreach (var product in menu)
    {
        if (product.Price > mostExpensive.Price)
        {
            mostExpensive = product;
        }
    }

    Console.WriteLine("=== Producto más caro ===");
    mostExpensive.ShowDescription();
}