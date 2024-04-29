namespace Balatro.Common;


public record Consumable : CardBase
{
    public Consumable(string Name, string Description)
    {
        this.Name = Name;
        this.Description = Description;
    }
}
