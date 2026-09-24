using Restaurant.Models;

// Creamos tres entrantes y mostramos la descripción de cada uno.
var bravas = new Starter("Patatas Bravas", 5.99m, 2, false);
var calamares = new Starter("Calamares", 8.99m, 2, false);
var ensaladillaRusa = new Starter("Ensaladilla Rusa", 7.99m, 1, true);

bravas.ShowDescription();
calamares.ShowDescription();
ensaladillaRusa.ShowDescription();