namespace Balatro.Common;

//test joker that adds +5 mult
public record GoldJoker : CardBase, IJoker
{
    public GoldJoker()
    {
        Name = "Gold Joker"; 
        Description = "This Joker awards 4 dollars at the start and end of each round.";
    }


    public void CalculateHand(GameState state)
    {
    }

    public void CalculateStartRound(GameState state)
    {
        state.Money += 4;
    }
    public void CalculateEndRound(GameState state)
    {
        state.Money += 4;
    }
}
