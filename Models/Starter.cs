namespace Restaurant.Models;

public class Starter : Product
{
    public int SharedBy { get; set; }
    public bool IsCold { get; set; }

    public Starter(string name, decimal price, int sharedBy, bool isCold) 
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