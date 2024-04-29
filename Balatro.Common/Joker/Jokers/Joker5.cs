namespace Balatro.Common;

//test joker that adds +5 mult
public record Joker5 : CardBase, IJoker
{
    public Joker5()
    {
        Name = "Plain Joker";
        Description = "Plain old Joker that adds 5 to the current Mult.";
    }


    public void CalculateHand(GameState state)
    {
        state.CurrentScore.Mult += 5;
    }

    public void CalculateStartRound(GameState state)
    {
    }
    public void CalculateEndRound(GameState state)
    {
    }
}
