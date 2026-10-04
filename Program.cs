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

var order = new List<Product>();

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
            AddProductToOrder(restaurantMenu, order);
            break;
        case 3:
            Console.WriteLine();
            ShowOrder(order);
            break;
        case 4:
            Console.WriteLine();
            DeleteProductInOrder(order);
            break;
        case 5:
            Console.WriteLine();
            EndOrder(order);
            break;
        case 6:
            Console.WriteLine();
            SearchProduct(restaurantMenu);
            break;
        case 7:
            Console.WriteLine();
            ProductsPerPrice(restaurantMenu);
            break;
        case 8:
            Console.WriteLine();
            MostExpensiveProduct(restaurantMenu);
            break;
        case 0:
            Console.WriteLine("Saliendo del programa...");
            break;
        default:
            Console.WriteLine("\nOpción no válida. Incluya un número del 0 al 8.");
            break;
    }
} while (option != 0);

static void ShowOptions()
{  
    Console.WriteLine("\n=================");
    Console.WriteLine("   RESTAURANTE   ");
    Console.WriteLine("=================");
    Console.WriteLine("\n1. Ver carta");
    Console.WriteLine("2. Añadir productos al pedido");
    Console.WriteLine("3. Ver pedido");
    Console.WriteLine("4. Eliminar producto del pedido");
    Console.WriteLine("5. Terminar pedido.");
    Console.WriteLine("6. Buscar producto");
    Console.WriteLine("7. Producto por precio");
    Console.WriteLine("8. Producto más caro");
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

static void ShowOrder(List<Product> order)
{
    if (order.Count == 0)
    {
        Console.WriteLine("El pedido está vacío.");
    }
    else
    {
        Console.WriteLine("=== Pedido ===");
        var position = 1;
        foreach (var product in order)
        {
            Console.Write($"{position++} --> ");
            Console.WriteLine($"{product.Name}    {product.Price}");
        }
        Console.WriteLine("-------------");
        SumProductPrice(order);
    }
}

static Product ChooseProductInMenu(List<Product> menu)
{
    ShowMenu(menu);
    
    while(true) 
    {
        Console.Write("\nEliga un producto: ");
        var input = Console.ReadLine();
        if (int.TryParse(input, out int decision) && decision >= 1 || decision <= menu.Count)
        {
            var selectedProduct = menu[decision - 1];
            selectedProduct.ShowDescription();
            return selectedProduct;
        }

        Console.WriteLine($"Opción no válida. Debe introducir un número del 1 al {menu.Count}.");
    }
}

static Product ChooseProductInOrder(List<Product> order)
{
    ShowOrder(order);

    while(true)
    {
        Console.Write("\nEliga un producto: ");
        var input = Console.ReadLine();

        if (int.TryParse(input, out int decision) && decision >= 1 && decision <= order.Count)
        {
            var selectedProduct = order[decision - 1];
            selectedProduct.ShowDescription();
            return selectedProduct;
        }

        Console.WriteLine($"Opción no válida. Debe introducir un número del 1 al {order.Count}.");
    }
}

static void AddProductToOrder(List<Product> menu, List<Product> order)
{
    var product = ChooseProductInOrder(menu);
    order.Add(product);
    Console.WriteLine($"{product.Name} añadido al pedido.");
}

static void DeleteProductInOrder(List<Product> order)
{
    if (order.Count == 0)
    {
        Console.WriteLine("El pedido está vacio.");
        return;
    }
    var product = ChooseProductInOrder(order);
    order.Remove(product);
    Console.WriteLine($"{product.Name} eliminado del pedido.");
}

static void EndOrder(List<Product> order)
{
    if (order.Count == 0)
    {
        Console.WriteLine("No se puede cerrar el ticket, el pedido está vacio.");
        return;
    }

    Console.WriteLine("=== TICKET ===");
    var sum = 0m;
    foreach (var product in order)
    {
        Console.WriteLine($"{product.Name}   {product.Price}");
        sum += product.Price;
    }
    Console.WriteLine("\n-----------");
    Console.WriteLine($"Productos:  {order.Count}");
    Console.WriteLine($"TOTAL:      {sum}");

    order.Clear();
}

static void SumProductPrice(List<Product> menu)
{
    decimal sum = 0;
    foreach (var product in menu)
    {
        sum += product.Price;
    }
    Console.WriteLine($"TOTAL:    {sum}");
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