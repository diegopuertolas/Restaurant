namespace Restaurant.Models;

public class Entrante : Product
{
    public int SharedBy { get; set; }
    public bool IsCold { get; set; }

    public Entrante(string name, decimal price, int sharedBy, bool isCold) 
        : base(name, price)
    {
        SharedBy = sharedBy;
        IsCold = isCold;
    }

    public override void ShowDescription()
    {
        Console.WriteLine($"Nombre: {Name} - Precio: {Price} - Ración para {SharedBy} personas - {(IsCold ? "Frío" : "Caliente")}");
    }
}